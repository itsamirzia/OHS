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
            Icon icon = Icon.ExtractAssociatedIcon(Application.StartupPath + "\\" + Properties.Settings.Default.IconName);
            this.Icon = icon;
            dataGridView1.DataSource = null;

            db.SQLQuery(ref db.conn, ref dt, "SELECT (@row_number:=@row_number + 1) AS RowNumber,`Fname` `First Name`, `Lname` `Last Name`, `Designation`, `Company`, `Mobile`, `Email`, `Registered_Time`, `Registration_Type`, `EmpCode` as `Pre-registered Code`, IsPrinted FROM `register`,(SELECT @row_number:=0) AS t order by EmpCode");
            dataGridView1.DataSource = dt;
            label23.Text = dt.Rows.Count.ToString();
            dataGridView2.DataSource = null;
            dt = null;
            db.SQLQuery(ref db.conn, ref dt, "SELECT date_format(registered_time,'%Y-%m-%d') `DATE`, count(1) `COUNT` from register group by date_format(registered_time,'%Y-%m-%d')");
            dataGridView2.DataSource = dt;
            cmbBarcode.Text = cmbEnabeSideBanner.Text = cmbEnableSearch.Text = cmbKeyboardButton.Text = cmbDisplayBGImage.Text = cmbEnableEmailSearch.Text = cmbUniqueIDSearch.Text = null;
            txtIconImage.Text = Properties.Settings.Default.IconName;
            txtBanner.Text = Properties.Settings.Default.HeaderImage;
            //txtOrganised.Text = Properties.Settings.Default.OrganisedByImage;
            txtLeftSideBanner.Text = Properties.Settings.Default.LeftSideBarImage;
            txtRightSideBanner.Text = Properties.Settings.Default.RightSideBarImage;
            //txtOrganisedSize.Text = Properties.Settings.Default.PanelOrganisedSize;
            cmbKeyboardButton.SelectedText = Properties.Settings.Default.EnableKeyboardButton.ToString();
            txtTextArea.Text = Properties.Settings.Default.TextArea;
            txtBarcodeArea.Text = Properties.Settings.Default.BarcodeArea;
            txtBadgeArea.Text = Properties.Settings.Default.BadgeArea;
            txtThemeColor.Text = Properties.Settings.Default.ThemeColor.ToString();
            txtRegistrationType.Text = Properties.Settings.Default.RegistrationType;
            txtPrefix.Text = Properties.Settings.Default.PrefixCustomerCode;
            cmbEnableSearch.SelectedText = Properties.Settings.Default.EnableSearch.ToString();
            cmbBarcode.SelectedText = Properties.Settings.Default.PrintBarcode.ToString();
            cmbEnabeSideBanner.SelectedText = Properties.Settings.Default.EnableSideBanner.ToString();
            txtTearTime.Text = Properties.Settings.Default.TearTime.ToString();
            txtMainPanelLebel.Text = Properties.Settings.Default.MainPanelLebel;
            cmbDisplayBGImage.SelectedText = Properties.Settings.Default.DisplayBGImage.ToString();
            txtBackgroundImage.Text = Properties.Settings.Default.BackgroundImage;
            txtBadgePrintErrorText.Text = Properties.Settings.Default.BadgeText;
            txtEmailSearchText.Text = Properties.Settings.Default.EmailSearchText;
            txtUniqueIDSearchText.Text = Properties.Settings.Default.UniqueIDSearchText;
            txtTearWindowImage.Text = Properties.Settings.Default.TearWindowImage.ToString();
        }

        

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }
        public static Excel.Application xlApp = null;
        public static object MisValue = null;
        public static Excel.Workbook xlWorkbook = null;
        //public static string ExcelVisible = ConfigurationManager.AppSettings["ExcelVisible"].ToString();

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
        
        private void btnHeaderUpload_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            uploadFile(button.Name);
        }

        private void btnIconUpload_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            uploadFile(button.Name);            
        }
        public void uploadFile(string buttonName)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png, *.ico) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png; *.ico";
            string filepath = string.Empty;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                filepath = dialog.FileName;
            }
            else
            {
                return;
            }
            string destinationFileName = filepath.Substring(filepath.LastIndexOf('\\') + 1);
            
            try
            {
                if (File.Exists(Application.StartupPath + "//" + destinationFileName))
                {
                    DialogResult result = MessageBox.Show("File is already present. Would to like to overwrite?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result.ToString().ToUpper() == "YES")
                    {
                        File.Copy(filepath, Application.StartupPath + "//" + destinationFileName, true);
                    }
                }
                else
                {
                    File.Copy(filepath, Application.StartupPath + "//" + destinationFileName);
                }
                MessageBox.Show("Uploaded Succesfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            switch (buttonName)
            {
                case "btnIconUpload":
                    if (Path.GetExtension(filepath).ToUpper() != ".ICO")
                    {
                        MessageBox.Show("please select icon file");
                        return;
                    }
                    else
                    {
                        txtIconImage.Text = destinationFileName;
                    }
                    break;
                case "btnHeaderUpload":
                    txtBanner.Text = destinationFileName;
                    break;
                case "btnLeftSideBannerUpload":
                    txtLeftSideBanner.Text = destinationFileName;
                    break;
                case "btnRightSideBannerUpload":
                    txtRightSideBanner.Text = destinationFileName;
                    break;
                case "btnBackgroundImage":
                    txtBackgroundImage.Text = destinationFileName;
                    break;
                case "btnTearWindowImage":
                    txtTearWindowImage.Text = destinationFileName;
                    break;
                default:
                    break;
            }
            
        }

        private void btnSaveNContinue_Click(object sender, EventArgs e)
        {
            string[] colorCodesArray = txtThemeColor.Text.Split(',');
            Properties.Settings.Default.BadgeArea = txtBadgeArea.Text;
            Properties.Settings.Default.BarcodeArea = txtBarcodeArea.Text;
            Properties.Settings.Default.EnableSearch = Convert.ToBoolean(cmbEnableSearch.Text);
            Properties.Settings.Default.PrintBarcode = Convert.ToBoolean(cmbBarcode.Text);
            Properties.Settings.Default.EnableSideBanner = Convert.ToBoolean(cmbEnabeSideBanner.Text);
            Properties.Settings.Default.HeaderImage = txtBanner.Text;
            Properties.Settings.Default.IconName = txtIconImage.Text;
            Properties.Settings.Default.LeftSideBarImage = txtLeftSideBanner.Text;
            Properties.Settings.Default.MainPanelLebel = txtMainPanelLebel.Text;
            Properties.Settings.Default.PrefixCustomerCode = txtPrefix.Text;
            Properties.Settings.Default.RegistrationType = txtRegistrationType.Text;
            Properties.Settings.Default.RightSideBarImage = txtRightSideBanner.Text;
            Properties.Settings.Default.TearTime = Convert.ToInt32(txtTearTime.Text);
            Properties.Settings.Default.TextArea = txtTextArea.Text;
            Properties.Settings.Default.ThemeColor = Color.FromArgb(Convert.ToInt32(colorCodesArray[1].Split('=')[1]), Convert.ToInt32(colorCodesArray[2].Split('=')[1]), Convert.ToInt32(colorCodesArray[3].Split('=')[1].TrimEnd(']')));
            Properties.Settings.Default.DisplayBGImage = Convert.ToBoolean(cmbDisplayBGImage.Text);
            Properties.Settings.Default.BackgroundImage = txtBackgroundImage.Text;
            Properties.Settings.Default.BadgeText = txtBadgePrintErrorText.Text;
            Properties.Settings.Default.EmailSearchText = txtEmailSearchText.Text;
            Properties.Settings.Default.UniqueIDSearchText = txtUniqueIDSearchText.Text;
            Properties.Settings.Default.TearWindowImage = txtTearWindowImage.Text;

            Properties.Settings.Default.EnableKeyboardButton = Convert.ToBoolean(cmbKeyboardButton.Text);

            Properties.Settings.Default.Save();


            Form1 obj1 = new Form1();
            obj1.ShowDialog();
            this.Close();
        }

        private void btnUploadCSVFile_Click(object sender, EventArgs e)
        {
            string filepath = string.Empty;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filepath = openFileDialog1.FileName;
            }
            if (Path.GetExtension(filepath).ToUpper() != ".CSV")
            {
                MessageBox.Show("please select csv file");
                return;
            }
            if (db.ExecuteSQLQuery(ref db.conn, "load data local infile '" + filepath.Replace("\\", "/") + "' ignore into table register fields  TERMINATED by ',' ENCLOSED BY '\"' lines TERMINATED by '\r\n' ignore 1 lines"))
            {
                MessageBox.Show("Uploaded Successfuly");
                Form2_Load(sender, e);
            }
        }

        private void btnDownloadData_Click(object sender, EventArgs e)
        {
            xlApp = new Microsoft.Office.Interop.Excel.Application();
            xlApp.Visible = false;
            xlApp.DisplayAlerts = false;
            xlWorkbook = xlApp.Workbooks.Add(Type.Missing);
            var worKsheeT = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkbook.ActiveSheet;
            worKsheeT.Name = "Registered User";
            db.SQLQuery(ref db.conn, ref dt, "SELECT (@row_number:=@row_number + 1) AS RowNumber,`Fname` `First Name`, `Lname` `Last Name`, `Designation`, `Company`, `Mobile`, `Email`, `Registered_Time`, `Registration_Type`, `EmpCode` as `Pre-registered Code` FROM `register`,(SELECT @row_number:=0) AS t order by EmpCode");
            for(int i=0; i<dt.Columns.Count; i++)
            {
                worKsheeT.Cells[1, i + 1] = dt.Columns[i].ColumnName.ToUpper();
                worKsheeT.Cells[1, i + 1].Interior.Color = Color.Yellow;
                worKsheeT.Cells[1, i + 1].Font.Color = Color.Black;
                worKsheeT.Cells[1, i + 1].Orientation = 0;
                worKsheeT.Cells[1, i + 1].Borders.Color = Color.Black;
            }

            Excel.Range celLrangE = (Excel.Range)worKsheeT.get_Range((Excel.Range)worKsheeT.Cells[2, 1], (Excel.Range)worKsheeT.Cells[1 + dt.Rows.Count, dt.Columns.Count]);
            celLrangE.EntireColumn.AutoFit();
            string[,] myArray = new string[dt.Rows.Count, dt.Columns.Count];
            int q = 0;
            foreach (DataRow dr in dt.Rows)
            {
                for (int k = 0; k < dt.Columns.Count; k++)
                {
                    myArray[q, k] = dr[k].ToString();
                }
                q++;
            }
            celLrangE.set_Value(Type.Missing, myArray);
            celLrangE.Borders.Color = Color.Black;
            celLrangE.Columns.AutoFit();

            Microsoft.Office.Interop.Excel.Borders border = celLrangE.Borders;
            border.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            border.Weight = 2d;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                xlWorkbook.SaveAs(saveFileDialog1.FileName + ".xlsx", Excel.XlFileFormat.xlWorkbookDefault, MisValue, MisValue, MisValue, MisValue, Excel.XlSaveAsAccessMode.xlExclusive, MisValue, MisValue, MisValue, MisValue, MisValue);                
            }
            xlWorkbook.Close();
            xlApp.Quit();
            releaseObject(xlApp);
            MessageBox.Show("Data Saved", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnOrganised_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            uploadFile(button.Name);
        }

        private void btnLeftSideBannerUpload_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            uploadFile(button.Name);
        }

        private void btnRightSideBannerUpload_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            uploadFile(button.Name);
        }

        private void btnClearData_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("It will erase all your data. Would you like to contineo?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result.ToString().ToUpper() == "YES")
            {
                if (db.ExecuteSQLQuery(ref db.conn, "create table register_" + DateTime.Now.ToString("yyyyMMddHHmmss") + "  select * from register"))
                {
                    db.ExecuteSQLQuery(ref db.conn, "truncate table register");
                    Form2_Load(sender, e);
                }
            }
        }

        private void btnBackgroundImage_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            uploadFile(button.Name);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            int rowIndex;
            if (!int.TryParse(txtRowIndex.Text, out rowIndex))
            {
                MessageBox.Show("Given input is not a number", "Abort", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            rowIndex = rowIndex - 1;

            int numberOfBadges;
            if (int.TryParse(txtToRowIndex.Text, out numberOfBadges))
            {
                int count = numberOfBadges - rowIndex;

                dt = null;
                db.SQLQuery(ref db.conn, ref dt, "select * from register where IsPrinted != 'YES' order by EmpCode limit " + rowIndex + ", "+count+"");

                progressBar1.Maximum = dt.Rows.Count;
                if (dt.Rows.Count == 0)
                {
                    label26.Text = "No records found";
                    label26.ForeColor = Color.Red;
                    txtToRowIndex.Text = string.Empty;
                }
                
                int i = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    progressBar1.Value = i + 1;
                    BadgePrinter.barcode = dr["EmpCode"].ToString();
                    BadgePrinter.nameDesignationCompany = dr["fname"].ToString() + " " + dr["lname"] + Environment.NewLine + Environment.NewLine +
                        dr["designation"] + Environment.NewLine + Environment.NewLine +
                        dr["company"] + Environment.NewLine + Environment.NewLine;
                    BadgePrinter.registrationType = txtRegistrationType.Text;
                    BadgePrinter.PrintBadges();
                    db.ExecuteSQLQuery(ref db.conn, "update ohs.register set registered_time=now(), IsPrinted='YES' where EmpCode = '"+dr["EmpCode"].ToString()+"'");
                    i++;
                    label26.Text = "Processing " + i + "/" + dt.Rows.Count + "(" + (i / dt.Rows.Count) * 100 + "%)";
                    txtToRowIndex.Text = string.Empty;
                    txtRowIndex.Text = string.Empty;
                    
                }
                Form2_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Input is not a number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnEnableUser_Click(object sender, EventArgs e)
        {
            if (!db.ExecuteSQLQuery(ref db.conn, "update register set IsPrinted='NO' where EmpCode = '" + txtProvideID.Text + "'"))
            {
                MessageBox.Show("Not able to update data", "Abort", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                txtProvideID.Text = string.Empty;
                MessageBox.Show("Updated Successfuly", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Form2_Load(sender, e);
            }


        }

        private void btnTearWindowImage_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            uploadFile(button.Name);
        }
    }
}
