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
    }
}
