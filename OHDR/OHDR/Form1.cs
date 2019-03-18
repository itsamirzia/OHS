using System;
using System.ComponentModel;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Data;
using System.Configuration;


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
        private System.Windows.Forms.Button printButton;
        private Font printFont;
        private Font printFontVisitor;
        private StreamReader streamToPrint;
        public bool isOld = false;
        public static bool IsVisible;
        public static string Registration_Type = Properties.Settings.Default.RegistrationType.ToString().ToUpper();
        public static DataTable dt_old = new DataTable();
        //public static MySqlConnection conn = new MySqlConnection("datasource=localhost;database=omanexpoevents;user id=root;password='';allow zero datetime=true");


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

        private void Form1_Load(object sender, EventArgs e)
        {
            Icon icon = Icon.ExtractAssociatedIcon(Application.StartupPath + "\\" + Properties.Settings.Default.IconName);
            this.Icon = icon;
            //        System.ComponentModel.ComponentResourceManager resources =
            //new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            //        this.Icon = ((System.Drawing.Icon)(resources.GetObject(Application.StartupPath + "\\" + ConfigurationManager.AppSettings["IconImage"].ToString())));//Image.FromFile(Application.StartupPath + "\\" + ConfigurationManager.AppSettings["IconImage"].ToString()); 
            //panel1.BackgroundImage = Image.FromFile(Application.StartupPath+"\\"+ ConfigurationManager.AppSettings["MainLogo"].ToString());
            panel3.BackgroundImage = Image.FromFile(Application.StartupPath + "\\" + Properties.Settings.Default.HeaderImage);
            panel2.BackgroundImage = Image.FromFile(Application.StartupPath + "\\" + Properties.Settings.Default.OrganisedByImage);
            button1.BackColor = button3.BackColor = textBox1.ForeColor = textBox2.ForeColor = textBox3.ForeColor = textBox4.ForeColor = textBox5.ForeColor = textBox6.ForeColor =  Properties.Settings.Default.ThemeColor;// "#9E2065";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //Graphics v = e.Graphics;
            //DrawRoundRect(v, Pens.Red, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1, 10);
            ////Without rounded corners
            ////e.Graphics.DrawRectangle(Pens.Blue, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1);
            //base.OnPaint(e);
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
            //Graphics v = e.Graphics;
            //DrawRoundRect(v, Pens.Red, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1, 10);
            ////Without rounded corners
            ////e.Graphics.DrawRectangle(Pens.Blue, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1);
            //base.OnPaint(e);
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
        public string barcode;
        private void button1_Click(object sender, EventArgs e)
        {
           
            if (!isOld)
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
            { MessageBox.Show("All details are mendatory."); return; }

                dt_old.Clear();
            
            db.SQLQuery(ref db.conn, ref dt_old, "select * from register where email regexp '"+textBox6.Text.ToLower().ToString()+"'");
            if (dt_old.Rows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Would you like to continue with old data.", "Your Detail is alredy present with us.", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result.ToString().ToUpper()=="YES")
                {
                    textBox1.Text = dt_old.Rows[0][0].ToString();
                    textBox2.Text = dt_old.Rows[0][1].ToString();
                    textBox3.Text = dt_old.Rows[0][2].ToString();
                    textBox4.Text = dt_old.Rows[0][3].ToString();
                    isOld = true;
                        barcode = dt_old.Rows[0][8].ToString();
                    return;
                }
                else
                { //MessageBox.Show("To replace your old. Contact with the administrator."); 
                        return; }
            }
                DataTable dtMaxNumber = new DataTable();
                db.SQLQuery(ref db.conn, ref dtMaxNumber, "SELECT concat('"+Properties.Settings.Default.PrefixCustomerCode+"',max(cast(substring_index(empcode,'FHO',-1) as unsigned))+1) NextRegister FROM `register` where EmpCode regexp 'OHS'");
                if (dtMaxNumber.Rows.Count > 0)
                    barcode = dtMaxNumber.Rows[0][0].ToString();
                else
                    barcode = Properties.Settings.Default.PrefixCustomerCode+"101";
                if (!db.ExecuteSQLQuery(ref db.conn, "insert into register values ('" + textBox1.Text.ToString().ToUpper() + "','" + textBox2.Text.ToString().ToUpper() + "','" + textBox3.Text.ToString().ToUpper() + "','" + textBox4.Text.ToString().ToUpper() + "','" + textBox5.Text.ToString().ToUpper() + "','" + textBox6.Text.ToString().ToLower() + "',now(),'" + Registration_Type + "','"+dtMaxNumber.Rows[0][0]+"')"))
                {
                    MessageBox.Show("Kindly check your DB configuration or your DB server is down");
                    return;
                }
            }

            try
            {
                if (File.Exists("Temp.txt"))
                {
                    File.Delete("Temp.txt");
                   
                }
                File.WriteAllText("Temp.txt", textBox1.Text.ToUpper() + "  " + textBox2.Text.ToUpper() + "\r\n" + textBox3.Text.ToUpper() + "\r\n" + textBox4.Text.ToUpper());

                
                    
                streamToPrint = new StreamReader("Temp.txt");
                try
                {
                    printFont = new Font("Arial", 12, FontStyle.Bold);
                    printFontVisitor = new Font("Arial Black", 36, FontStyle.Bold);
                    PrintDocument printDocument = new PrintDocument();

                    // We ALWAYS want true here, as we will implement the 
                    // margin limitations later in code.
                    //printDocument.OriginAtMargins = true;
                    // printDocument.DefaultPageSettings.Margins(100, 100, 100, 100);
                    printDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                    // Set some preferences, our method should print a box with any 
                    // combination of these properties being true/false.
                    printDocument.DefaultPageSettings.Landscape = false;
                    //printDocument.DefaultPageSettings.PrintableArea.Height = 400;
                    PaperSize ps = new PaperSize("Custom", 816, 800);
                    File.WriteAllText("log.txt", "Printable Area\r\nHeight ="+printDocument.DefaultPageSettings.PrintableArea.Height + " Width=" + printDocument.DefaultPageSettings.PrintableArea.Width + " X point=" + printDocument.DefaultPageSettings.PrintableArea.X + " Y point" + printDocument.DefaultPageSettings.PrintableArea.Y+"\r\n");
                    
                    printDocument.DefaultPageSettings.PaperSize = ps;
                    //printDocument.DefaultPageSettings.PaperSize.Width = (int)(100 / 25.4) * 102;
                    //printDocument.DefaultPageSettings.PrintableArea.Height = (float)100;
                    //printDocument.PrinterSettings.PrinterName = "ZDesigner S4M-203dpi ZPL (Copy 1)";
                    printDocument.PrintPage += new PrintPageEventHandler
                       (this.pd_PrintPage);
                    //PrintController printController = new StandardPrintController();
                    //printDocument.PrintController = printController;
                    // printPreviewDialog1.Document = printDocument;
                    // printPreviewDialog1.ShowDialog();
                    printDocument.Print();
                }
                finally
                {
                    streamToPrint.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Form3 f3 = new Form3();
            f3.doenable();
            f3.ShowDialog();
            
            if (dt_old.Rows.Count > 0)
            {
                if (dt_old.Rows[0][0].ToString().ToUpper() == textBox1.Text.ToString().ToUpper() &&
                    dt_old.Rows[0][1].ToString().ToUpper() == textBox2.Text.ToString().ToUpper() &&
                    dt_old.Rows[0][2].ToString().ToUpper() == textBox3.Text.ToString().ToUpper() &&
                    dt_old.Rows[0][3].ToString().ToUpper() == textBox4.Text.ToString().ToUpper() &&
                    dt_old.Rows[0][4].ToString().ToUpper() == textBox5.Text.ToString().ToUpper() &&
                    dt_old.Rows[0][5].ToString().ToUpper() == textBox6.Text.ToString().ToUpper())
                { }
                else
                {
                    db.ExecuteSQLQuery(ref db.conn, "update register set fname='" + textBox1.Text.ToString().ToUpper() + "',lname='" + textBox2.Text.ToString().ToUpper() + "',Designation='" + textBox3.Text.ToString().ToUpper() + "', Company='" + textBox4.Text.ToString().ToUpper() + "', Mobile='" + textBox5.Text.ToString().ToUpper() + "', Registered_Time=now() where Email='" + textBox6.Text.ToString().ToLower() + "'");
                    isOld = false;
                }
            }
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = "";
            isOld = false;
            // MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["conn"].ToString());

        }
        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            ev.Graphics.PageUnit = GraphicsUnit.Millimeter;
            float linesPerPage = 3;

            int count = 0;

            string line = null;
            string[] display1 = Properties.Settings.Default.TextArea.Split(',');
            Rectangle displayRectangle =
            new Rectangle(Convert.ToInt32(display1[0]), Convert.ToInt32(display1[1]), Convert.ToInt32(display1[2]), Convert.ToInt32(display1[3]));
            File.AppendAllText("log.txt", "displayRectangle Area\r\nHeight =" + displayRectangle.Height + " Width=" + displayRectangle.Width + " X point=" + displayRectangle.X + " Y point" + displayRectangle.Y + "\r\n");

            string[] display2 = Properties.Settings.Default.BadgeArea.Split(',');
            Rectangle displayRectangle2 =
            new Rectangle(Convert.ToInt32(display2[0]), Convert.ToInt32(display2[1]), Convert.ToInt32(display2[2]), Convert.ToInt32(display2[3]));
            File.AppendAllText("log.txt", "displayRectangle2 Area\r\nHeight =" + displayRectangle2.Height + " Width=" + displayRectangle2.Width + " X point=" + displayRectangle2.X + " Y point" + displayRectangle2.Y + "\r\n");
            StringFormat format1 = new StringFormat(StringFormatFlags.NoClip);
            format1.Alignment = StringAlignment.Center;
            format1.LineAlignment = StringAlignment.Center;
            //string barcode = string.Empty;
            //if (ConfigurationManager.AppSettings["BarcodeBox"].ToString().ToUpper() == "EMAIL")
            //    barcode = textBox6.Text;
            //else
            //    barcode = textBox5.Text;
            Bitmap bitm = new Bitmap(barcode.Length * 5, 20);
            using (Graphics graphic = Graphics.FromImage(bitm))
            {

                string[] display3 = Properties.Settings.Default.BarcodeArea.Split(',');
                Rectangle displayBarcode =
                                new Rectangle(Convert.ToInt32(display3[0]), Convert.ToInt32(display3[1]), Convert.ToInt32(display3[2]), Convert.ToInt32(display3[3]));

                Font newfont = new Font("IDAutomationHC39M", 16);
                PointF point = new PointF(2f, 2f);
                SolidBrush black = new SolidBrush(Color.Black);
                SolidBrush white = new SolidBrush(Color.White);
                ev.Graphics.FillRectangle(white, 0, 0, bitm.Width/2, bitm.Height);
                ev.Graphics.DrawString("*" + barcode + "*", newfont, black, displayBarcode, format1);


            }
            string single = "";
            while (count < linesPerPage &&
               ((line = streamToPrint.ReadLine()) != null))
            {
                single += line + Environment.NewLine + Environment.NewLine;
                count++;
            }
            //ev.Graphics.DrawRectangle(Pens.Black, displayRectangle);
            //ev.Graphics.DrawRectangle(Pens.Black, displayRectangle2);
            ev.Graphics.DrawString(single, printFont, Brushes.Black, displayRectangle, format1);
            ev.Graphics.DrawString(Registration_Type, printFontVisitor, Brushes.Black,displayRectangle2, format1);
            ev.HasMorePages = false;
        }

        //private void doprint()
        //{
        //    PrintDoc printer = new PrintDoc();

        //    //set PrintText
        //    printer.PrintText = textBox1.Text+" "+ textBox2.Text + "\r\n"+ textBox3.Text + "\r\n" + textBox4.Text;

        //    printer.Print();    // very straightforward
        //}



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
            { e.Cancel = true; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            admin a = new admin();
            a.ShowDialog();
            if (a.isclose)
            {
                Form2 f2 = new Form2();
                    f2.ShowDialog();
                
            }
        }



        private void button3_Click_1(object sender, EventArgs e)
        {
            dt_old.Clear();
            db.SQLQuery(ref db.conn, ref dt_old, "select * from register where email regexp '" + txtSearchBox1.Text.ToLower().ToString() + "'");
            if (dt_old.Rows.Count > 0)
            {

                textBox1.Text = dt_old.Rows[0][0].ToString();
                textBox2.Text = dt_old.Rows[0][1].ToString();
                textBox3.Text = dt_old.Rows[0][2].ToString();
                textBox4.Text = dt_old.Rows[0][3].ToString();
                textBox5.Text = dt_old.Rows[0][4].ToString();
                textBox6.Text = dt_old.Rows[0][5].ToString();
                isOld = true;
                barcode = dt_old.Rows[0][8].ToString();
                txtSearchBox1.Text = "";
                return;
            }
            else
            { MessageBox.Show("Data Not Found."); txtSearchBox1.Text = ""; return; }
            
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = "";
            isOld = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
                if (IsVisible)
                    panel7.Visible = true;
                else
                    panel7.Visible = false;
            
             
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
            dt_old.Clear();
            db.SQLQuery(ref db.conn, ref dt_old, "select * from register where email = '" + txtSearchBox1.Text.ToLower().ToString() + "' or EmpCode = '"+ txtSearchBox2.Text.ToLower().ToString() + "'");
            if (dt_old.Rows.Count > 0)
            {
                panel7.Visible = false;
                label1.Visible = label2.Visible = label3.Visible = label4.Visible = label5.Visible = label6.Visible = label7.Visible = textBox1.Visible = textBox2.Visible = textBox3.Visible = textBox4.Visible = textBox5.Visible = textBox6.Visible = button2.Visible = true;

                textBox1.Text = dt_old.Rows[0][0].ToString();
                textBox2.Text = dt_old.Rows[0][1].ToString();
                textBox3.Text = dt_old.Rows[0][2].ToString();
                textBox4.Text = dt_old.Rows[0][3].ToString();
                textBox5.Text = dt_old.Rows[0][4].ToString();
                textBox6.Text = dt_old.Rows[0][5].ToString();
                isOld = true;
                barcode = dt_old.Rows[0][8].ToString();
                txtSearchBox1.Text = txtSearchBox2.Text = string.Empty;
                return;
            }
            else
            { MessageBox.Show("Data Not Found."); txtSearchBox1.Text = ""; return; }

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
            //panel7.Location= new Point(524, 160);
            //panel7.Anchor = AnchorStyles.Left;
            //panel7.Anchor = AnchorStyles.Right;
        }

        private void txtSearchBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtSearchBox1_Leave(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            panel7.Visible = true;
            label1.Visible = label2.Visible = label3.Visible = label4.Visible = label5.Visible = label6.Visible = label7.Visible = textBox1.Visible = textBox2.Visible = textBox3.Visible = textBox4.Visible = textBox5.Visible = textBox6.Visible = button2.Visible = false;
        }
    }
}
