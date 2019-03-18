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
            timer1.Interval = Properties.Settings.Default.TearTime * 1000;
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            Icon icon = Icon.ExtractAssociatedIcon(Application.StartupPath + "\\" + Properties.Settings.Default.IconName);
            this.Icon = icon;
            label1.ForeColor=label2.ForeColor = Properties.Settings.Default.ThemeColor;
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
