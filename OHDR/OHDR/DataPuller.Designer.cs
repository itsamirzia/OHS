namespace OHDR
{
    partial class DataPuller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.t1 = new System.Windows.Forms.Timer(this.components);
            this.lblProccessing = new System.Windows.Forms.Label();
            this.lblTimeElapsed = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 34);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(535, 41);
            this.progressBar1.TabIndex = 0;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // t1
            // 
            this.t1.Enabled = true;
            this.t1.Interval = 3000;
            this.t1.Tick += new System.EventHandler(this.t1_Tick);
            // 
            // lblProccessing
            // 
            this.lblProccessing.AutoSize = true;
            this.lblProccessing.Location = new System.Drawing.Point(12, 9);
            this.lblProccessing.Name = "lblProccessing";
            this.lblProccessing.Size = new System.Drawing.Size(76, 13);
            this.lblProccessing.TabIndex = 1;
            this.lblProccessing.Text = "Processing 0%";
            // 
            // lblTimeElapsed
            // 
            this.lblTimeElapsed.AutoSize = true;
            this.lblTimeElapsed.Location = new System.Drawing.Point(255, 9);
            this.lblTimeElapsed.Name = "lblTimeElapsed";
            this.lblTimeElapsed.Size = new System.Drawing.Size(133, 13);
            this.lblTimeElapsed.TabIndex = 2;
            this.lblTimeElapsed.Text = "Estimated Time 0 Seconds";
            // 
            // DataPuller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 82);
            this.Controls.Add(this.lblTimeElapsed);
            this.Controls.Add(this.lblProccessing);
            this.Controls.Add(this.progressBar1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DataPuller";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.DataPuller_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        public System.Windows.Forms.Timer t1;
        private System.Windows.Forms.Label lblProccessing;
        private System.Windows.Forms.Label lblTimeElapsed;
    }
}