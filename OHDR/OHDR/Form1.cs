using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

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
        private System.ComponentModel.Container components;
        private System.Windows.Forms.Button printButton;
        private Font printFont;
        private Font printFontVisitor;
        private StreamReader streamToPrint;
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

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics v = e.Graphics;
            DrawRoundRect(v, Pens.Red, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1, 10);
            //Without rounded corners
            //e.Graphics.DrawRectangle(Pens.Blue, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1);
            base.OnPaint(e);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            Graphics v = e.Graphics;
            DrawRoundRect(v, Pens.Red, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1, 10);
            //Without rounded corners
            //e.Graphics.DrawRectangle(Pens.Blue, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1);
            base.OnPaint(e);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Graphics v = e.Graphics;
            DrawRoundRect(v, Pens.Red, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1, 10);
            //Without rounded corners
            //e.Graphics.DrawRectangle(Pens.Blue, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1);
            base.OnPaint(e);
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
            { MessageBox.Show("All details are mendatory."); return; }
            DataTable dt = new DataTable();
            db.SQLQuery(ref db.conn, ref dt, "select * from register where email_id regexp '"+textBox6.Text.ToLower().ToString()+"'");
            if (dt.Rows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Your Detail is alredy present with us.", "Would you like to continue with old data.", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result.ToString().ToUpper()=="YES")
                {

                }
                else
                { MessageBox.Show("To replace your old. Contact with the administrator."); return; }
            }
            db.ExecuteSQLQuery(ref db.conn, "insert into register values ('"+textBox1.Text.ToString().ToUpper()+ "','" + textBox2.Text.ToString().ToUpper() + "','" + textBox3.Text.ToString().ToUpper() + "','" + textBox4.Text.ToString().ToUpper() + "','" + textBox5.Text.ToString().ToUpper() + "','" + textBox6.Text.ToString().ToLower() + "',now())");
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
                    printFontVisitor = new Font("Arial Black", 40, FontStyle.Bold);
                    PrintDocument printDocument = new PrintDocument();

                    // We ALWAYS want true here, as we will implement the 
                    // margin limitations later in code.
                    printDocument.OriginAtMargins = true;
                   // printDocument.DefaultPageSettings.Margins(100, 100, 100, 100);
                    // Set some preferences, our method should print a box with any 
                    // combination of these properties being true/false.
                    printDocument.DefaultPageSettings.Landscape = false;
                    //PaperSize ps = new PaperSize("Custom", 800, 816);
                    //printDocument.DefaultPageSettings.PaperSize = ps;
                    //printDocument.DefaultPageSettings.PaperSize.Width = (int)(100 / 25.4) * 102;

                    printDocument.PrintPage += new PrintPageEventHandler
                       (this.pd_PrintPage);
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
            MessageBox.Show("Thank you for the registration");
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = "";
            // MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["conn"].ToString());

        }
        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            ev.Graphics.PageUnit = GraphicsUnit.Millimeter;
            float linesPerPage = 4;

            int count = 0;

            string line = null;
            Rectangle displayRectangle =
            new Rectangle(2,40,98,45);
            Rectangle displayRectangle2 =
            new Rectangle(2, 85, 98, 15);
            StringFormat format1 = new StringFormat(StringFormatFlags.NoClip);
            format1.Alignment = StringAlignment.Center;
            format1.LineAlignment = StringAlignment.Center;
            string single = "";
            while (count < linesPerPage-1 &&
               ((line = streamToPrint.ReadLine()) != null))
            {
                single += line + Environment.NewLine + Environment.NewLine;
                count++;
            }
            ev.Graphics.DrawString(single, printFont, Brushes.Black, displayRectangle, format1);
            ev.Graphics.DrawString("VISITOR", printFontVisitor, Brushes.Black,displayRectangle2, format1);
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
    }
}
