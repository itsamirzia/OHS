using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace OHDR
{
    public partial class admin : Form
    {
        public bool isclose;
        public admin()
        {
            InitializeComponent();
            textBox1.ForeColor = textBox2.ForeColor = button1.BackColor = Settings1.Default.OHS;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if ((textBox1.Text.ToString().ToUpper() == "SHAARIQUE") && (textBox2.Text.ToString() == "SHA123"))
            {
                isclose = true;
            }
            else
            { isclose = false; }

            this.Close();
        }

        private void admin_Load(object sender, EventArgs e)
        {
            Icon icon = Icon.ExtractAssociatedIcon(Application.StartupPath + "\\" + ConfigurationManager.AppSettings["IconImage"].ToString());
            this.Icon = icon;
        }
    }
}
