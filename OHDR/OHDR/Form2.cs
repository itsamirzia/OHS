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

            db.SQLQuery(ref db.conn, ref dt, "select * from register");
            dataGridView1.DataSource = dt;
            label23.Text = dt.Rows.Count.ToString();
            dataGridView2.DataSource = null;
            dt = null;
            db.SQLQuery(ref db.conn, ref dt, "SELECT date_format(registered_time,'%Y-%m-%d') `DATE`, count(1) `COUNT` from register group by date_format(registered_time,'%Y-%m-%d')");
            dataGridView2.DataSource = dt;

            txtIconImage.Text = Properties.Settings.Default.IconName;
            txtBanner.Text = Properties.Settings.Default.HeaderImage;
            txtOrganised.Text = Properties.Settings.Default.OrganisedByImage;
            txtLeftSideBanner.Text = Properties.Settings.Default.LeftSideBarImage;
            txtRightSideBanner.Text = Properties.Settings.Default.RightSideBarImage;
            txtOrganisedSize.Text = Properties.Settings.Default.PanelOrganisedSize;
            txtHeaderSize.Text = Properties.Settings.Default.PanelHeaderSize;
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
            string destinationFileName = filepath.Substring(filepath.LastIndexOf('\\') + 1);
            //if(destinationFileName)
            try
            {
                if (File.Exists(Application.StartupPath + "//" + destinationFileName))
                {
                    DialogResult result = MessageBox.Show("File is already present. Would to like to overwrite?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (result.ToString().ToUpper() == "YES")
                    {
                        File.Copy(filepath, Application.StartupPath + "//" + destinationFileName, true);
                    }
                }
                else
                {
                    File.Copy(filepath, Application.StartupPath + "//" + destinationFileName);
                }
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
                        File.Delete(Application.StartupPath + "//" + destinationFileName);
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
                case "btnOrganised":
                    txtOrganised.Text = destinationFileName;
                    break;
                case "btnLeftSideBannerUpload":
                    txtLeftSideBanner.Text = destinationFileName;
                    break;
                case "btnRightSideBannerUpload":
                    txtRightSideBanner.Text = destinationFileName;
                    break;
                default:
                    File.Delete(Application.StartupPath + "//" + destinationFileName);
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
            Properties.Settings.Default.OrganisedByImage = txtOrganised.Text;
            Properties.Settings.Default.PanelHeaderSize = txtHeaderSize.Text;
            Properties.Settings.Default.PanelOrganisedSize = txtOrganisedSize.Text;
            Properties.Settings.Default.PrefixCustomerCode = txtPrefix.Text;
            Properties.Settings.Default.RegistrationType = txtRegistrationType.Text;
            Properties.Settings.Default.RightSideBarImage = txtRightSideBanner.Text;
            Properties.Settings.Default.TearTime = Convert.ToInt32(txtTearTime.Text);
            Properties.Settings.Default.TextArea = txtTextArea.Text;
            Properties.Settings.Default.ThemeColor = Color.FromArgb(Convert.ToInt32(colorCodesArray[1].Split('=')[1]), Convert.ToInt32(colorCodesArray[2].Split('=')[1]), Convert.ToInt32(colorCodesArray[3].Split('=')[1].TrimEnd(']')));

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
            if (Path.GetExtension(filepath).ToUpper() != "CSV")
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
    }
}
