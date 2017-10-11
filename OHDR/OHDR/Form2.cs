using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OHDR
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            DataTable dt = new DataTable();
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
    }
}
