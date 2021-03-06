﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
namespace OHDR
{
    public partial class DataPuller : Form
    {
       
        public DataPuller()
        {
            InitializeComponent();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
        int expactedTime = 0;
        private void DataPuller_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            lblProccessing.Text = progressBar1.Value + "%";
            string response = OnlineOfflineSyncup.GetOnlineData(1, true);
            if (!string.IsNullOrEmpty(response))
            {
                int maxValue = Convert.ToInt32(response);
                if (maxValue > 0)
                {
                    expactedTime = (3 * maxValue) / 5;
                    progressBar1.Maximum = maxValue;
                    progressBar1.Minimum = 0;
                    OnlineOfflineSyncup.reverseRequestCounter = maxValue;
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void t1_Tick(object sender, EventArgs e)
        {
            //t1.Enabled = false;
            DataTable dt = new DataTable();
            db.SQLQuery(ref db.conn, ref dt, "select * from register");
            int percentValue = 0;

            percentValue = ((dt.Rows.Count*100)/ progressBar1.Maximum);

            if (percentValue >= 100)
            {
                    progressBar1.Value = progressBar1.Maximum;
                    lblProccessing.Text = "100% - Completed";
                    lblTimeElapsed.Text = "Time remaining 0 Seconds";
                    System.Threading.Thread.Sleep(5000);
                    this.Close();
            }
            else
            {
                    progressBar1.Value = dt.Rows.Count;
                    lblProccessing.Text = percentValue.ToString() + "% Records Processed";
                    lblTimeElapsed.Text = "Estimated Time remaining " + expactedTime / 60 + " Minutes and "+expactedTime%60+" Seconds";
                if (expactedTime <= 3)
                {
                    lblTimeElapsed.Text = "Estimated Time remaining " + expactedTime / 60 + " Minutes and " + expactedTime % 60 + " Seconds\r\nSystem is taking longer time then expected. You might be running with slow internet connection.";
                }
                else
                {
                    expactedTime -= 3;
                }
                    OnlineOfflineSyncup.UpdateOfflineDatabase();
                    OnlineOfflineSyncup.ReverseUpdateOfflineDatabase();
            }
        }
    }
}
