using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using CoreScanner;

namespace OHDR
{
    public partial class badge : Form
    {
        static CCoreScannerClass cCoreScannerClass;
        static string barcode;
        public badge()
        {
            InitializeComponent();
        }

        private void badge_Load(object sender, EventArgs e)
        {
            try
            {
                cCoreScannerClass = new CCoreScannerClass();
                //Call Open API
                short[] scannerTypes = new short[1]; // Scanner Types you are interested in
                scannerTypes[0] = 1; // 1 for all scanner types
                short numberOfScannerTypes = 1; // Size of the scannerTypes array
                int status; // Extended API return code
                cCoreScannerClass.Open(0, scannerTypes, numberOfScannerTypes, out status);
                if (status == 0)
                {
                    File.AppendAllText("Log.txt", "\r\nCoreScanner API: Open Successful");
                }
                else
                {
                    File.AppendAllText("Log.txt", "\r\nCoreScanner API: Open Failed");
                }
                short numberOfScanners = 2; // Number of scanners expect to be used
                int[] connectedScannerIDList = new int[255];
                // List of scanner IDs to be returned
                string outXML; //Scanner details output
                cCoreScannerClass.GetScanners(out numberOfScanners, connectedScannerIDList,
                out outXML, out status);
                if (outXML != null)
                {
                    File.AppendAllText("Log.txt", "\r\n" + outXML);
                }
                else
                {
                    File.AppendAllText("Log.txt", "\r\nI am before the barcode event");
                    //textBox1.Text += "\r\nWe found null values from get scanner method";
                    cCoreScannerClass.BarcodeEvent += new
                    CoreScanner._ICoreScannerEvents_BarcodeEventEventHandler(OnBarcodeEvent);
                    File.AppendAllText("Log.txt", "\r\nI am after the barcode event");
                    //System.Threading.Thread.CurrentThread.Join();
                    // Let's subscribe for events
                    int opcode = 1001; // Method for Subscribe events
                    string outXML2; // XML Output
                    string inXML = "<inArgs>" +
                    "<cmdArgs>" +
                    "<arg-int>1</arg-int>" + // Number of events you want to subscribe
                    "<arg-int>1</arg-int>" + // Comma separated event IDs
                    "</cmdArgs>" +
                    "</inArgs>";
                    cCoreScannerClass.ExecCommand(opcode, ref inXML, out outXML2, out status);
                    System.Threading.Thread.Sleep(1000);
                }
            }
            catch (Exception ex)
            {
                File.AppendAllText("Log.txt", "\r\n" + ex.Message);
            }

            //panel7.Anchor = AnchorStyles.None;
            if (Properties.Settings.Default.DisplayBGImage)
            {
                this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\" + Properties.Settings.Default.BackgroundImage);
                foreach (Panel p in Controls.OfType<Panel>())
                    foreach (Label l in p.Controls.OfType<Label>())
                        l.ForeColor = Color.White;

            }

            //button4.Visible = button4.Enabled = Properties.Settings.Default.EnableKeyboardButton;

            Taskbar.Hide();
            Icon icon = Icon.ExtractAssociatedIcon(Application.StartupPath + "\\" + Properties.Settings.Default.IconName);
            this.Icon = icon;
            if (Properties.Settings.Default.EnableSideBanner)
            {
                //pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\" + Properties.Settings.Default.LeftSideBarImage);
                //pictureBox2.Image = Image.FromFile(Application.StartupPath + "\\" + Properties.Settings.Default.RightSideBarImage);
                //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                //pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            //txtSearchBox1.Text = Properties.Settings.Default.EmailSearchText;
            //MainPanelLebel.Text = Properties.Settings.Default.MainPanelLebel.ToUpper();
            //panel3.BackgroundImage = Image.FromFile(Application.StartupPath + "\\" + Properties.Settings.Default.HeaderImage);
            //panel2.BackgroundImage = Image.FromFile(Application.StartupPath + "\\" + Properties.Settings.Default.OrganisedByImage);
            //button1.BackColor = button3.BackColor = textBox1.ForeColor = textBox2.ForeColor = textBox3.ForeColor = textBox4.ForeColor = textBox5.ForeColor = textBox6.ForeColor = Properties.Settings.Default.ThemeColor;// "#9E2065";


        }
        private void BeepTheBeeper()
        {
            // Let's beep the beeper
            int opcode = 6000; // Method for Beep the beeper
            string outXML; // Output
            int status;
            string inXML = "<inArgs>" +
            "<scannerID>1</scannerID>" + // The scanner you need to beep
            "<cmdArgs>" +
            "<arg-int>3</arg-int>" + // 4 high short beep pattern
            "</cmdArgs>" +
            "</inArgs>";
            cCoreScannerClass.ExecCommand(opcode, ref inXML, out outXML, out status);

            //File.AppendAllText("Log.txt", "\r\nBeep The Beeper Output =" + outXML.ToString());
        }
        private void OnBarcodeEvent(short eventType, ref string pscanData)
        {
            File.AppendAllText("Log.txt", "\r\nEntered into the barcode event");
            barcode = pscanData;
            File.AppendAllText("log.txt", "captured barcode value " + pscanData);
            this.Invoke((MethodInvoker)delegate
            {
                MessageBox.Show("barcode scandata is " + barcode);
            });
            string sqlQuery = "select * from register where EmpCode='" + pscanData + "' and IsPrinted='FALSE'";
            DataTable dt = new DataTable();
            db.SQLQuery(ref db.conn, ref dt, sqlQuery);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    string firstName = dr[0].ToString();
                    string lastName = dr[1].ToString();
                    string designation = dr[2].ToString();
                    string company = dr[3].ToString();
                    string mobile = dr[4].ToString();
                    string email = dr[5].ToString();
                    string registrationType = dr[7].ToString();
                    string empCode = pscanData;
                    this.Invoke((MethodInvoker)delegate
                    {
                        textBox1.Text = firstName;
                        textBox2.Text = lastName;
                        textBox3.Text = designation;
                        textBox4.Text = company;
                        textBox5.Text = mobile;
                        textBox6.Text = email;
                    });
                    PrintTheBadge();
                    BeepTheBeeper();
                }
            }
            else
            {
                MessageBox.Show("User not registered. Contact with administrator", "Warning", MessageBoxButtons.OK);
            }

        }
        private void PrintTheBadge()
        {
            BadgePrinter.barcode = barcode;
            BadgePrinter.nameDesignationCompany = textBox1.Text + " " + textBox2.Text + Environment.NewLine + Environment.NewLine
                + textBox3.Text + Environment.NewLine + Environment.NewLine
                + textBox4.Text + Environment.NewLine + Environment.NewLine;
            BadgePrinter.registrationType = "VISITOR";
            BadgePrinter.PrintBadges();

            Form3 f3 = new Form3();
            f3.doenable();
            f3.ShowDialog();
            db.ExecuteSQLQuery(ref db.conn, "update register set Registered_Time=now(), IsPrinted='YES' where EmpCode='" + barcode + "'");
        }
    }
}
