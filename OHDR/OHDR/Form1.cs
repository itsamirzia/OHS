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

        private void Form1_Load(object sender, EventArgs e)
        {
            panel7.Anchor = AnchorStyles.None;
            if (Properties.Settings.Default.DisplayBGImage)
            {
                this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\" + Properties.Settings.Default.BackgroundImage);
                foreach (Panel p in Controls.OfType<Panel>())
                    foreach (Label l in p.Controls.OfType<Label>())
                        l.ForeColor = Color.White;

            }

            button4.Visible = button4.Enabled = Properties.Settings.Default.EnableKeyboardButton;
            
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
            txtSearchBox1.Text = Properties.Settings.Default.EmailSearchText;
            txtSearchBox2.Text = Properties.Settings.Default.UniqueIDSearchText;
            MainPanelLebel.Text = Properties.Settings.Default.MainPanelLebel.ToUpper();
            panel3.BackgroundImage = Image.FromFile(Application.StartupPath + "\\" + Properties.Settings.Default.HeaderImage);
            //panel2.BackgroundImage = Image.FromFile(Application.StartupPath + "\\" + Properties.Settings.Default.OrganisedByImage);
            button1.BackColor = button4.BackColor = button3.BackColor = textBox1.ForeColor = textBox2.ForeColor = textBox3.ForeColor = textBox4.ForeColor = textBox5.ForeColor = textBox6.ForeColor =  Properties.Settings.Default.ThemeColor;// "#9E2065";
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
        public string barcode;
        private void button1_Click(object sender, EventArgs e)
        {
           
            if (!isOld)
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
                {
                    MessageBox.Show("All details are mendatory.");
                    return;
                }

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
                    {
                        return;
                    }
                }
                DataTable dtMaxNumber = new DataTable();
                db.SQLQuery(ref db.conn, ref dtMaxNumber, "SELECT concat('"+Properties.Settings.Default.PrefixCustomerCode+ "',max(cast(substring_index(empcode,'" + Properties.Settings.Default.PrefixCustomerCode + "',-1) as unsigned))+1) NextRegister FROM `register` where EmpCode regexp 'OHS'");

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

            BadgePrinter.barcode = barcode;
            BadgePrinter.nameDesignationCompany = textBox1.Text + " " + textBox2.Text + Environment.NewLine + Environment.NewLine
                + textBox3.Text + Environment.NewLine + Environment.NewLine
                + textBox4.Text + Environment.NewLine + Environment.NewLine;
            BadgePrinter.registrationType = Registration_Type;
            BadgePrinter.PrintBadges();

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
                {
                    db.ExecuteSQLQuery(ref db.conn, "update register set Registered_Time=now(), IsPrinted='YES' where EmpCode='" + dt_old.Rows[0]["EmpCode"].ToString() + "'");
                }
                else
                {
                    db.ExecuteSQLQuery(ref db.conn, "update register set fname='" + textBox1.Text.ToString().ToUpper() + "',lname='" + textBox2.Text.ToString().ToUpper() + "',Designation='" + textBox3.Text.ToString().ToUpper() + "', Company='" + textBox4.Text.ToString().ToUpper() + "', Mobile='" + textBox5.Text.ToString().ToUpper() + "', Registered_Time=now(), IsPrinted='YES' where Email='" + textBox6.Text.ToString().ToLower() + "'");
                    isOld = false;
                }
            }
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = "";
            panel7.Visible  = true;
            button4.Visible = button4.Enabled = Properties.Settings.Default.EnableKeyboardButton;
            isOld = MainPanelLebel.Visible = label2.Visible = label3.Visible = label4.Visible = label5.Visible = label6.Visible = label7.Visible = textBox1.Visible = textBox2.Visible = textBox3.Visible = textBox4.Visible = textBox5.Visible = textBox6.Visible = button2.Visible = button1.Visible = false;
            txtSearchBox1.Text = Properties.Settings.Default.EmailSearchText;
            txtSearchBox2.Text = Properties.Settings.Default.UniqueIDSearchText;
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
            db.SQLQuery(ref db.conn, ref dt_old, "select * from register where (email = '" + txtSearchBox1.Text.ToLower().ToString() + "' or EmpCode = '" + txtSearchBox2.Text.ToLower().ToString() + "') and IsPrinted='YES'");
            if (dt_old.Rows.Count > 0)
            {
                MessageBox.Show(Properties.Settings.Default.BadgeText,"Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSearchBox1.Text = Properties.Settings.Default.EmailSearchText;
                txtSearchBox2.Text = Properties.Settings.Default.UniqueIDSearchText;
                return;
            }
            else
            {
                dt_old = null;
            }
            db.SQLQuery(ref db.conn, ref dt_old, "select * from register where email = '" + txtSearchBox1.Text.ToLower().ToString() + "' or EmpCode = '"+ txtSearchBox2.Text.ToLower().ToString() + "'");
            if (dt_old.Rows.Count == 1)
            {
                panel7.Visible = button4.Visible = false;
                MainPanelLebel.Visible = label2.Visible = label3.Visible = label4.Visible = label5.Visible = label6.Visible = label7.Visible = textBox1.Visible = textBox2.Visible = textBox3.Visible = textBox4.Visible = textBox5.Visible = textBox6.Visible = button2.Visible = button1.Visible = true;

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
            {
                MessageBox.Show("No data found. Contact with administrator","Waring",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSearchBox1.Text = Properties.Settings.Default.EmailSearchText;
                txtSearchBox2.Text = Properties.Settings.Default.UniqueIDSearchText;
                return;
            }

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
            //panel7.Location= new Point(524, 160);
            //panel7.Anchor = AnchorStyles.Left;
            //panel7.Anchor = AnchorStyles.Right;
        }

        private void txtSearchBox1_Enter(object sender, EventArgs e)
        {
            if (txtSearchBox1.Text == Properties.Settings.Default.EmailSearchText)
            {
                {
                    txtSearchBox1.Text = "";
                }
            }
        }

        private void txtSearchBox1_Leave(object sender, EventArgs e)
        {
            if (txtSearchBox1.Text == "")
            {
                {
                    txtSearchBox1.Text = Properties.Settings.Default.EmailSearchText;
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            panel7.Visible = true;
            button4.Visible = Properties.Settings.Default.EnableKeyboardButton;
            MainPanelLebel.Visible = label2.Visible = label3.Visible = label4.Visible = label5.Visible = label6.Visible = label7.Visible = textBox1.Visible = textBox2.Visible = textBox3.Visible = textBox4.Visible = textBox5.Visible = textBox6.Visible = button2.Visible = button1.Visible = false;
            txtSearchBox1.Text = Properties.Settings.Default.EmailSearchText;
            txtSearchBox2.Text = Properties.Settings.Default.UniqueIDSearchText;
        }

        private void txtSearchBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSearchBox2_Enter(object sender, EventArgs e)
        {
            if (txtSearchBox2.Text == Properties.Settings.Default.UniqueIDSearchText)
            {
                {
                    txtSearchBox2.Text = "";
                }
            }
        }

        private void txtSearchBox2_Leave(object sender, EventArgs e)
        {
            if (txtSearchBox2.Text == "")
            {
                {
                    txtSearchBox2.Text = Properties.Settings.Default.UniqueIDSearchText;
                }
            }
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
    }
}
