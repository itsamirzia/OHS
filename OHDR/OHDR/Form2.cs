using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace OHDR
{
    public partial class Form2 : Form
    {
        public DataTable dt = new DataTable();
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Icon icon = Icon.ExtractAssociatedIcon(Application.StartupPath + "\\" + ConfigurationManager.AppSettings["IconImage"].ToString());
            this.Icon = icon;
            dataGridView1.DataSource = null;

            db.SQLQuery(ref db.conn, ref dt, "select * from register");
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filepath = string.Empty;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filepath = openFileDialog1.FileName;
            }
            if (!filepath.ToUpper().Contains("CSV"))
            {
                MessageBox.Show("please select csv file");
                return;
            }
            if (db.ExecuteSQLQuery(ref db.conn, "load data local infile '" + filepath.Replace("\\","/") + "' ignore into table register fields  TERMINATED by ',' ENCLOSED BY '\"' lines TERMINATED by '\r\n' ignore 1 lines"))
            {
                MessageBox.Show("Uploaded Successfuly");
                Form2_Load(sender, e);
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           

            //if (radioButton1.Checked == true)
            //{
            //    f1.panel7.Visible = true;
            //    f1.EnableDisable(true);
            //    f1.Refresh();
            //    //f1.myTxtbx.Visible = button3.Visible = button7.Visible = button4.Visible = true;
            //}
            //else
            //{
            //    f1.panel7.Visible = true;
            //    //f1.EnableDisable(false);
            //}

        }
        public static Excel.Application xlApp = null;
        public static object MisValue = null;
        public static Excel.Workbook xlWorkbook = null;
        //public static string ExcelVisible = ConfigurationManager.AppSettings["ExcelVisible"].ToString();
        private void button2_Click_1(object sender, EventArgs e)
        {
            xlApp = new Excel.Application();
            MisValue = System.Reflection.Missing.Value;
            xlWorkbook = xlApp.Workbooks.Add();
            Excel.Worksheet xlsheet_Summary = (Excel.Worksheet)xlWorkbook.Worksheets.Add();
            xlsheet_Summary.Name = "Data";
            Excel.Range orange = (Excel.Range)xlsheet_Summary.get_Range((Excel.Range)xlsheet_Summary.Cells[2, 1], (Excel.Range)xlsheet_Summary.Cells[1+dt.Rows.Count, dt.Columns.Count]);
            dynamic[,] myArray = new string[dt.Rows.Count, dt.Columns.Count];
            int row = 0;
            xlsheet_Summary.Cells[1, 1] = "First Name";
            xlsheet_Summary.Cells[1, 1].font.color = Color.Blue;
            //xlsheet_Summary.Cells[1, 1].border.color = Color.Black;
            xlsheet_Summary.Cells[1, 2] = "Last Name";
            xlsheet_Summary.Cells[1, 2].font.color = Color.Blue;
            //xlsheet_Summary.Cells[1, 2].border.color = Color.Black;
            xlsheet_Summary.Cells[1, 3] = "Designation";
            xlsheet_Summary.Cells[1, 3].font.color = Color.Blue;
            //xlsheet_Summary.Cells[1, 3].border.color = Color.Black;
            xlsheet_Summary.Cells[1, 4] = "Company Name";
            xlsheet_Summary.Cells[1, 4].font.color = Color.Blue;
            //xlsheet_Summary.Cells[1, 4].border.color = Color.Black;
            xlsheet_Summary.Cells[1, 5] = "Mobile";
            xlsheet_Summary.Cells[1, 5].font.color = Color.Blue;
            //xlsheet_Summary.Cells[1, 5].border.color = Color.Black;
            xlsheet_Summary.Cells[1, 6] = "Email";
            xlsheet_Summary.Cells[1, 6].font.color = Color.Blue;
            //xlsheet_Summary.Cells[1, 6].border.color = Color.Black;
            xlsheet_Summary.Cells[1, 7] = "Registered_Time";
            xlsheet_Summary.Cells[1, 7].font.color = Color.Blue;
            //xlsheet_Summary.Cells[1, 7].border.color = Color.Black;
            xlsheet_Summary.Cells[1, 8] = "Registration_Type";
            xlsheet_Summary.Cells[1, 8].font.color = Color.Blue;
            //xlsheet_Summary.Cells[1, 8].border.color = Color.Black;
            xlsheet_Summary.Cells[1, 9] = "EmpCode";
            xlsheet_Summary.Cells[1, 9].font.color = Color.Blue;
            //xlsheet_Summary.Cells[1, 9].border.color = Color.Black;

            foreach (DataRow dr in dt.Rows)
            {
                for (int iCol = 0; iCol < dt.Columns.Count; iCol++)
                {
                    myArray[row, iCol] = dr[iCol].ToString();
                
                }
                row++;
            }
            orange.set_Value(Type.Missing, myArray);
            orange.Borders.Color = Color.Black;
            orange.Columns.AutoFit();
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                xlWorkbook.SaveAs(saveFileDialog1.FileName+System.DateTime.Now.ToString("MMddHHmmss") + ".xls", Excel.XlFileFormat.xlWorkbookDefault, MisValue, MisValue, MisValue, MisValue, Excel.XlSaveAsAccessMode.xlExclusive, MisValue, MisValue, MisValue, MisValue, MisValue);
            }
            //xlWorkbook.SaveAs( System.DateTime.Now.AddDays(0).ToString("ddMMyyyy") + ".xls", Excel.XlFileFormat.xlWorkbookDefault, MisValue, MisValue, MisValue, MisValue, Excel.XlSaveAsAccessMode.xlExclusive, MisValue, MisValue, MisValue, MisValue, MisValue);
            xlWorkbook.Close(false, MisValue, MisValue);
            xlApp.Quit();
            releaseObject(xlApp);

            MessageBox.Show("Data Saved");
        }
        public static void releaseObject(object ob)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(ob);
                ob = null;
            }
            catch (Exception ex)
            {

                ob = null;
                Console.WriteLine("exception in releasing object" + ex.Message);
            }

        }
    
    }
}
