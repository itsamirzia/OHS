using System;
using System.ComponentModel;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Data;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using Newtonsoft.Json;
using System.Text;
using System.Collections.Generic;
using CoreScanner;

namespace OHDR
{
    //public class PrintDoc : PrintDocument
    //{
    //    // there are other properties you can enter here
    //    // for instance, page orientation, size, font, etc.

    //    private string textout;

    //    public string PrintText
    //    {
    //        get { return textout; }
    //        set { textout = value; }
    //    }

    //    // you will also need to add any appropriate class ctor
    //    // experiment with the PrintDocument class to learn more
    //}
    
    public partial class Form1 : Form
    {
        public bool isOld = false;
        public static bool IsVisible;
        public string barcode;
        public static string Registration_Type = Properties.Settings.Default.RegistrationType.ToString().ToUpper();
        public static DataTable dt_old = new DataTable();

        public Form1()
        {            
            InitializeComponent();
        }

        public void DrawRoundRect(Graphics g, Pen p, float X, float Y, float width, float height, float radius)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddLine(X + radius, Y, X + width - (radius * 2), Y);
            gp.AddArc(X + width - (radius * 2), Y, radius * 2, radius * 2, 270, 90);
            gp.AddLine(X + width, Y + radius, X + width, Y + height - (radius * 2));
            gp.AddArc(X + width - (radius * 2), Y + height - (radius * 2), radius * 2, radius * 2, 0, 90);
            gp.AddLine(X + width - (radius * 2), Y + height, X + radius, Y + height);
            gp.AddArc(X, Y + height - (radius * 2), radius * 2, radius * 2, 90, 90);
            gp.AddLine(X, Y + height - (radius * 2), X, Y + radius);
            gp.AddArc(X, Y, radius * 2, radius * 2, 180, 90);
            gp.CloseFigure();
            g.DrawPath(p, gp);
            gp.Dispose();
        }
        protected override void WndProc(ref Message m)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_MOVE = 0xF010;

            switch (m.Msg)
            {
                case WM_SYSCOMMAND:
                    int command = m.WParam.ToInt32() & 0xfff0;
                    if (command == SC_MOVE)
                        return;
                    break;
            }
            base.WndProc(ref m);
        }
        private void PrintTheBadge( )
        {
            BadgePrinter.barcode = barcode;
            BadgePrinter.nameDesignationCompany = textBox1.Text + " " + textBox2.Text + Environment.NewLine + Environment.NewLine
                + textBox3.Text + Environment.NewLine + Environment.NewLine
                + textBox4.Text + Environment.NewLine + Environment.NewLine;
            BadgePrinter.registrationType = Registration_Type;
            BadgePrinter.PrintBadges();

            db.ExecuteSQLQuery(ref db.conn, "update register set Registered_Time=now(), IsPrinted='YES' where EmpCode='" + barcode + "'");
            DataTable dt = new DataTable();
            db.SQLQuery(ref db.conn, ref dt, "select * from register where EmpCode='"+barcode+"'");
            if(dt.Rows.Count>0)
            {
                if (!OnlineOfflineSyncup.UpdateOnlinePrintStatus(barcode, dt.Rows[0]["Registered_Time"].ToString(), dt.Rows[0]["IsPrinted"].ToString()))
                {
                    db.SQLQuery(ref db.conn, ref dt, "insert into retry_print_status values ('" + Properties.Settings.Default.EventID.ToString() + "','" + barcode + "','" + dt.Rows[0]["Registered_Time"].ToString() + "','" + dt.Rows[0]["IsPrinted"].ToString() + "')");
                }
            }
            System.Threading.Thread.Sleep(3000);

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.DisplayBGImage)
            {
                this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\" + Properties.Settings.Default.BackgroundImage);
                foreach (Panel p in Controls.OfType<Panel>())
                    foreach (Label l in p.Controls.OfType<Label>())
                        l.ForeColor = Color.White;

            }
            if (Properties.Settings.Default.EnableSearch)
                panel1.Visible = true;
            else
                panel1.Visible = false;

            panel2.Visible = true;
            Taskbar.Hide();
            Icon icon = Icon.ExtractAssociatedIcon(Application.StartupPath + "\\" + Properties.Settings.Default.IconName);
            this.Icon = icon;
            if (Properties.Settings.Default.EnableSideBanner)
            {
                pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\" + Properties.Settings.Default.LeftSideBarImage);
                pictureBox2.Image = Image.FromFile(Application.StartupPath + "\\" + Properties.Settings.Default.RightSideBarImage);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            txtBarcodeSearch.Text = Properties.Settings.Default.EmailSearchText;
            panel3.BackgroundImage = Image.FromFile(Application.StartupPath + "\\" + Properties.Settings.Default.HeaderImage);
            txtSearchBox1.BackColor = textBox1.ForeColor = textBox2.ForeColor = textBox3.ForeColor = textBox4.ForeColor = textBox5.ForeColor = textBox6.ForeColor = Color.White;// "#9E2065";
            button3.BackColor = txtSearchBox1.ForeColor = lblMessage.ForeColor = textBox1.BackColor = textBox2.BackColor = textBox3.BackColor = textBox4.BackColor = textBox5.BackColor = textBox6.BackColor = Properties.Settings.Default.ThemeColor;
            pnlThankYou.BackgroundImage = Image.FromFile(Application.StartupPath + "\\" + Properties.Settings.Default.TearWindowImage);
            pnlThankYou.Visible = false;

            
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            Graphics v = e.Graphics;
            Pen p = new Pen(Properties.Settings.Default.ThemeColor);
            DrawRoundRect(v, p, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1, 10);
            //Without rounded corners
            //e.Graphics.DrawRectangle(Pens.Blue, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1);
            base.OnPaint(e);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
 
        



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }

        private void textBox6_Validating(object sender, CancelEventArgs e)
        {
            System.Text.RegularExpressions.Regex rEMail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");

            //txtmail is name/object of textbox
            if (textBox6.Text.Length > 0)
            {

                //rEMail is object of Regex class located in System.Text.RegularExpressions
                if (!rEMail.IsMatch(textBox6.Text))
                {
                    MessageBox.Show("E-Mail expected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox6.SelectAll();
                    e.Cancel = true;
                }
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            admin a = new admin();
            a.ShowDialog();
            if (!a.isclose)
            {
                e.Cancel = true;
            }
            else
            {
                Taskbar.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            admin a = new admin();
            a.ShowDialog();
            if (a.isclose)
            {
                Administrator f2 = new Administrator();
                    f2.ShowDialog();
                
            }
        }



        private void button3_Click_1(object sender, EventArgs e)
        {
            dt_old.Clear();
            db.SQLQuery(ref db.conn, ref dt_old, "select * from register where email regexp '" + txtBarcodeSearch.Text.ToLower().ToString() + "'");
            if (dt_old.Rows.Count > 0)
            {

                textBox1.Text = dt_old.Rows[0][0].ToString();
                textBox4.Text = dt_old.Rows[0][1].ToString();
                textBox2.Text = dt_old.Rows[0][2].ToString();
                textBox5.Text = dt_old.Rows[0][3].ToString();
                textBox3.Text = dt_old.Rows[0][4].ToString();
                textBox6.Text = dt_old.Rows[0][5].ToString();
                isOld = true;
                barcode = dt_old.Rows[0][8].ToString();
                txtBarcodeSearch.Text = "";
                return;
            }
            else
            { MessageBox.Show("Data Not Found."); txtBarcodeSearch.Text = ""; return; }
            
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = "";
            isOld = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
                if (IsVisible)
                    pnlThankYou.Visible = true;
                else
                    pnlThankYou.Visible = false;
            
             
            timer1.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            admin a = new admin();
            a.ShowDialog();
            if (a.isclose)
            {
                if (IsVisible)
                    IsVisible = false;
                else
                    IsVisible = true;
                timer1.Enabled = true;
            }
            //Form1_Load(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
            //panel7.Location= new Point(524, 160);
            //panel7.Anchor = AnchorStyles.Left;
            //panel7.Anchor = AnchorStyles.Right;
        }

        private void txtSearchBox1_Enter(object sender, EventArgs e)
        {
            if (txtBarcodeSearch.Text == Properties.Settings.Default.EmailSearchText)
            {
                {
                    txtBarcodeSearch.Text = "";
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            pnlThankYou.Visible = true;
            //button4.Visible = Properties.Settings.Default.EnableKeyboardButton;
            label2.Visible = label3.Visible = label4.Visible = label5.Visible = label6.Visible = label7.Visible = textBox1.Visible = textBox2.Visible = textBox3.Visible = textBox4.Visible = textBox5.Visible = textBox6.Visible = false;
            txtBarcodeSearch.Text = Properties.Settings.Default.EmailSearchText;
            //txtSearchBox2.Text = Properties.Settings.Default.UniqueIDSearchText;
        }

        private void txtSearchBox2_Enter(object sender, EventArgs e)
        {
            
        }

        private void txtSearchBox2_Leave(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                var path64 = @"C:\Windows\winsxs\amd64_microsoft-windows-osk_31bf3856ad364e35_6.1.7600.16385_none_06b1c513739fb828\osk.exe";
                var path32 = @"C:\windows\system32\osk.exe";
                var path = (Environment.Is64BitOperatingSystem) ? path64 : path32;
                Process.Start(path);

                
            }
            catch (Exception)
            {
                try
                {
                    Process process = Process.Start(new ProcessStartInfo(
                ((Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\osk.exe"))));
                }
                catch (Exception ex2)
                {

                    MessageBox.Show(ex2.Message);
                }
            }
        }
        
        private void timer2_Tick(object sender, EventArgs e)
        {
            System.Threading.ThreadStart ts = new System.Threading.ThreadStart(OnlineOfflineSyncup.UpdatePrintStatus);
            System.Threading.Thread th = new System.Threading.Thread(ts);
            th.Start();
            //OnlineOfflineSyncup.UpdatePrintStatus();
            System.Threading.ThreadStart ts1 = new System.Threading.ThreadStart(OnlineOfflineSyncup.UpdateFailedPrintStatus);
            System.Threading.Thread th1 = new System.Threading.Thread(ts1);
            th1.Start();
            //OnlineOfflineSyncup.UpdateFailedPrintStatus();
            System.Threading.ThreadStart ts2 = new System.Threading.ThreadStart(OnlineOfflineSyncup.UpdateLatestRecords);
            System.Threading.Thread th2 = new System.Threading.Thread(ts2);
            th2.Start();
            //OnlineOfflineSyncup.UpdateLatestRecords();
        }


        private void Form1_ResizeBegin(object sender, EventArgs e)
        {

        }

        private void txtBarcodeSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtBarcodeSearch.Text.Length == 8)
            {
                printMyBadge();
                timer3.Enabled = true;
            }
        }
        private void printMyBadge()
        {
            string sqlQuery = "select * from register where EmpCode='" + txtBarcodeSearch.Text.Trim() + "' and IsPrinted='FALSE'";
            DataTable dt = new DataTable();
            db.SQLQuery(ref db.conn, ref dt, sqlQuery);
            if (dt.Rows.Count > 0)
            {
                panel2.Visible = false;

                pnlThankYou.Visible = true;
                txtBarcodeSearch.Enabled = false;
                panel1.Visible = false;                
                string pscanData = txtBarcodeSearch.Text.Trim();
                txtBarcodeSearch.Text = "";
                this.Cursor = Cursors.WaitCursor;
                barcode = pscanData;

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

                    this.Invoke(new MethodInvoker(() =>
                    {
                        textBox1.Text = firstName;
                        textBox4.Text = lastName;
                        textBox2.Text = designation;
                        textBox5.Text = company;
                        textBox3.Text = mobile;
                        textBox6.Text = email;
                    }));

                }
                PrintTheBadge();
            }
            else
            {
                textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = txtBarcodeSearch.Text = "";
                lblMessage.Text = "Please Scan Your Barcode";
                txtBarcodeSearch.Enabled = true;
                txtSearchBox1.Visible = button3.Visible = true;
                this.ActiveControl = txtBarcodeSearch;
                this.Cursor = Cursors.Default;
                MessageBox.Show("Badge is already printed or User not registered. Contact with administrator", "Warning", MessageBoxButtons.OK);
            }
        }

        private void txtBarcodeSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtBarcodeSearch.Text.Length == 8)
            {
                printMyBadge();
                timer3.Enabled = true;
            }
        }

        private void txtSearchBox1_TextChanged(object sender, EventArgs e)
        {
           

        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            string sqlQuery = "select * from register where EmpCode='" + txtSearchBox1.Text.Trim() + "' or Mobile='" + txtSearchBox1.Text.Trim() + "' or Email='" + txtSearchBox1.Text.Trim() + "'";
            DataTable dt = new DataTable();
            db.SQLQuery(ref db.conn, ref dt, sqlQuery);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["IsPrinted"].ToString().ToUpper() == "FALSE")
                {
                    this.Cursor = Cursors.WaitCursor;
                    this.Invoke(new MethodInvoker(() =>
                    {
                        textBox1.Text = dt.Rows[0][0].ToString();
                        textBox2.Text = dt.Rows[0][1].ToString();
                        textBox3.Text = dt.Rows[0][2].ToString();
                        textBox4.Text = dt.Rows[0][3].ToString();
                        textBox5.Text = dt.Rows[0][4].ToString();
                        textBox6.Text = dt.Rows[0][5].ToString();
                    }));
                    txtBarcodeSearch.Text = dt.Rows[0]["EmpCode"].ToString();
                    
                }
                else
                {
                    textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = "";
                    MessageBox.Show("Badge is already printed", "Information", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("User not found", "Warning", MessageBoxButtons.OK);
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            txtSearchBox1.Text = textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = txtBarcodeSearch.Text = "";
            panel2.Visible = true;
            txtBarcodeSearch.Enabled = true;
            pnlThankYou.Visible = false;
            panel1.Visible = true;
            this.Cursor = Cursors.Default;
            this.ActiveControl = txtBarcodeSearch;
            timer3.Enabled = false;
        }
    }
}
