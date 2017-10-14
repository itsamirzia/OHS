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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        public int counter = 0;
        public void doenable()
        {
            timer1.Enabled = true;
            timer1.Interval = Convert.ToInt32(ConfigurationManager.AppSettings["TearTime"].ToString());
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            Icon icon = Icon.ExtractAssociatedIcon(Application.StartupPath + "\\" + ConfigurationManager.AppSettings["IconImage"].ToString());
            this.Icon = icon;
            label1.ForeColor=label2.ForeColor = Settings1.Default.OHS;
        }
        public void Closeme()
        {
            this.Close();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            counter++;
            if (counter == 1)
            {
                timer1.Enabled = false;
                Closeme();
            }
        }
    }
}
