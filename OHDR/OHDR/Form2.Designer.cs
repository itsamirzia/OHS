namespace OHDR
{
    partial class Form2
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
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnUploadCSVFile = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnDownloadData = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label20 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtMainPanelLebel = new System.Windows.Forms.TextBox();
            this.cmbBarcode = new System.Windows.Forms.ComboBox();
            this.cmbEnableSearch = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTearTime = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPrefix = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRegistrationType = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtThemeColor = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtHeaderSize = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtOrganisedSize = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRightSideBanner = new System.Windows.Forms.TextBox();
            this.btnRightSideBannerUpload = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLeftSideBanner = new System.Windows.Forms.TextBox();
            this.btnLeftSideBannerUpload = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOrganised = new System.Windows.Forms.TextBox();
            this.btnOrganised = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBanner = new System.Windows.Forms.TextBox();
            this.btnHeaderUpload = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label19 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtTextArea = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtBarcodeArea = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtBadgeArea = new System.Windows.Forms.TextBox();
            this.btnSaveNContinue = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.cmbEnabeSideBanner = new System.Windows.Forms.ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.txtIconImage = new System.Windows.Forms.TextBox();
            this.btnIconUpload = new System.Windows.Forms.Button();
            this.btnClearData = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(385, 699);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Uploaded Data";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(15, 688);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(922, 390);
            this.dataGridView1.TabIndex = 1;
            // 
            // btnUploadCSVFile
            // 
            this.btnUploadCSVFile.Location = new System.Drawing.Point(503, 623);
            this.btnUploadCSVFile.Margin = new System.Windows.Forms.Padding(6);
            this.btnUploadCSVFile.Name = "btnUploadCSVFile";
            this.btnUploadCSVFile.Size = new System.Drawing.Size(209, 44);
            this.btnUploadCSVFile.TabIndex = 2;
            this.btnUploadCSVFile.Text = "Upload csv File";
            this.btnUploadCSVFile.UseVisualStyleBackColor = true;
            this.btnUploadCSVFile.Click += new System.EventHandler(this.btnUploadCSVFile_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // btnDownloadData
            // 
            this.btnDownloadData.Location = new System.Drawing.Point(271, 623);
            this.btnDownloadData.Margin = new System.Windows.Forms.Padding(6);
            this.btnDownloadData.Name = "btnDownloadData";
            this.btnDownloadData.Size = new System.Drawing.Size(220, 44);
            this.btnDownloadData.TabIndex = 3;
            this.btnDownloadData.Text = "Download Data";
            this.btnDownloadData.UseVisualStyleBackColor = true;
            this.btnDownloadData.Click += new System.EventHandler(this.btnDownloadData_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "Compelete Data";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbEnabeSideBanner);
            this.panel1.Controls.Add(this.label24);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.txtMainPanelLebel);
            this.panel1.Controls.Add(this.cmbBarcode);
            this.panel1.Controls.Add(this.cmbEnableSearch);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txtTearTime);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtPrefix);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtRegistrationType);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtThemeColor);
            this.panel1.Location = new System.Drawing.Point(946, 415);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(868, 663);
            this.panel1.TabIndex = 16;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(90, 27);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(514, 55);
            this.label20.TabIndex = 74;
            this.label20.Text = "Miscellaneous Settings";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(113, 507);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(179, 25);
            this.label12.TabIndex = 81;
            this.label12.Text = "Main Panel Label";
            // 
            // txtMainPanelLebel
            // 
            this.txtMainPanelLebel.Location = new System.Drawing.Point(399, 507);
            this.txtMainPanelLebel.Name = "txtMainPanelLebel";
            this.txtMainPanelLebel.Size = new System.Drawing.Size(323, 31);
            this.txtMainPanelLebel.TabIndex = 80;
            // 
            // cmbBarcode
            // 
            this.cmbBarcode.FormattingEnabled = true;
            this.cmbBarcode.Items.AddRange(new object[] {
            "TRUE",
            "FALSE"});
            this.cmbBarcode.Location = new System.Drawing.Point(399, 382);
            this.cmbBarcode.Name = "cmbBarcode";
            this.cmbBarcode.Size = new System.Drawing.Size(323, 33);
            this.cmbBarcode.TabIndex = 79;
            // 
            // cmbEnableSearch
            // 
            this.cmbEnableSearch.FormattingEnabled = true;
            this.cmbEnableSearch.Items.AddRange(new object[] {
            "TRUE",
            "FALSE"});
            this.cmbEnableSearch.Location = new System.Drawing.Point(399, 319);
            this.cmbEnableSearch.Name = "cmbEnableSearch";
            this.cmbEnableSearch.Size = new System.Drawing.Size(323, 33);
            this.cmbEnableSearch.TabIndex = 78;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(113, 444);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(222, 25);
            this.label11.TabIndex = 77;
            this.label11.Text = "Tear Time in Seconds";
            // 
            // txtTearTime
            // 
            this.txtTearTime.Location = new System.Drawing.Point(399, 444);
            this.txtTearTime.Name = "txtTearTime";
            this.txtTearTime.Size = new System.Drawing.Size(323, 31);
            this.txtTearTime.TabIndex = 76;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(113, 382);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(165, 25);
            this.label10.TabIndex = 75;
            this.label10.Text = "Enable Barcode";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(113, 319);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(153, 25);
            this.label9.TabIndex = 74;
            this.label9.Text = "Enable Search";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(113, 257);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(245, 25);
            this.label8.TabIndex = 73;
            this.label8.Text = "Prefix Registration Code";
            // 
            // txtPrefix
            // 
            this.txtPrefix.Location = new System.Drawing.Point(399, 257);
            this.txtPrefix.Name = "txtPrefix";
            this.txtPrefix.Size = new System.Drawing.Size(323, 31);
            this.txtPrefix.TabIndex = 72;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(113, 197);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(181, 25);
            this.label7.TabIndex = 71;
            this.label7.Text = "Registration Type";
            // 
            // txtRegistrationType
            // 
            this.txtRegistrationType.Location = new System.Drawing.Point(399, 197);
            this.txtRegistrationType.Name = "txtRegistrationType";
            this.txtRegistrationType.Size = new System.Drawing.Size(323, 31);
            this.txtRegistrationType.TabIndex = 70;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(113, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 25);
            this.label6.TabIndex = 69;
            this.label6.Text = "Theme Color";
            // 
            // txtThemeColor
            // 
            this.txtThemeColor.Location = new System.Drawing.Point(399, 134);
            this.txtThemeColor.Name = "txtThemeColor";
            this.txtThemeColor.Size = new System.Drawing.Size(323, 31);
            this.txtThemeColor.TabIndex = 68;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(26, 378);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(191, 25);
            this.label14.TabIndex = 60;
            this.label14.Text = "Panel Header Size";
            // 
            // txtHeaderSize
            // 
            this.txtHeaderSize.Location = new System.Drawing.Point(312, 378);
            this.txtHeaderSize.Name = "txtHeaderSize";
            this.txtHeaderSize.Size = new System.Drawing.Size(323, 31);
            this.txtHeaderSize.TabIndex = 59;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(26, 440);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(220, 25);
            this.label13.TabIndex = 58;
            this.label13.Text = "Panel Organised Size";
            // 
            // txtOrganisedSize
            // 
            this.txtOrganisedSize.Location = new System.Drawing.Point(312, 440);
            this.txtOrganisedSize.Name = "txtOrganisedSize";
            this.txtOrganisedSize.Size = new System.Drawing.Size(323, 31);
            this.txtOrganisedSize.TabIndex = 57;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label25);
            this.panel2.Controls.Add(this.txtIconImage);
            this.panel2.Controls.Add(this.btnIconUpload);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtRightSideBanner);
            this.panel2.Controls.Add(this.btnRightSideBannerUpload);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtLeftSideBanner);
            this.panel2.Controls.Add(this.btnLeftSideBannerUpload);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtHeaderSize);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.txtOrganised);
            this.panel2.Controls.Add(this.txtOrganisedSize);
            this.panel2.Controls.Add(this.btnOrganised);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtBanner);
            this.panel2.Controls.Add(this.btnHeaderUpload);
            this.panel2.Location = new System.Drawing.Point(35, 53);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(902, 518);
            this.panel2.TabIndex = 17;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(3, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(344, 55);
            this.label18.TabIndex = 28;
            this.label18.Text = "Image Settings";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 315);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(260, 25);
            this.label5.TabIndex = 27;
            this.label5.Text = "Upload Right Side Banner";
            // 
            // txtRightSideBanner
            // 
            this.txtRightSideBanner.Location = new System.Drawing.Point(312, 312);
            this.txtRightSideBanner.Name = "txtRightSideBanner";
            this.txtRightSideBanner.Size = new System.Drawing.Size(323, 31);
            this.txtRightSideBanner.TabIndex = 26;
            // 
            // btnRightSideBannerUpload
            // 
            this.btnRightSideBannerUpload.BackColor = System.Drawing.Color.White;
            this.btnRightSideBannerUpload.BackgroundImage = global::OHDR.Properties.Resources.upload;
            this.btnRightSideBannerUpload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRightSideBannerUpload.Location = new System.Drawing.Point(653, 310);
            this.btnRightSideBannerUpload.Name = "btnRightSideBannerUpload";
            this.btnRightSideBannerUpload.Size = new System.Drawing.Size(46, 34);
            this.btnRightSideBannerUpload.TabIndex = 25;
            this.btnRightSideBannerUpload.UseVisualStyleBackColor = false;
            this.btnRightSideBannerUpload.Click += new System.EventHandler(this.btnRightSideBannerUpload_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 253);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(246, 25);
            this.label4.TabIndex = 24;
            this.label4.Text = "Upload Left Side Banner";
            // 
            // txtLeftSideBanner
            // 
            this.txtLeftSideBanner.Location = new System.Drawing.Point(312, 250);
            this.txtLeftSideBanner.Name = "txtLeftSideBanner";
            this.txtLeftSideBanner.Size = new System.Drawing.Size(323, 31);
            this.txtLeftSideBanner.TabIndex = 23;
            // 
            // btnLeftSideBannerUpload
            // 
            this.btnLeftSideBannerUpload.BackColor = System.Drawing.Color.White;
            this.btnLeftSideBannerUpload.BackgroundImage = global::OHDR.Properties.Resources.upload;
            this.btnLeftSideBannerUpload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLeftSideBannerUpload.Location = new System.Drawing.Point(653, 248);
            this.btnLeftSideBannerUpload.Name = "btnLeftSideBannerUpload";
            this.btnLeftSideBannerUpload.Size = new System.Drawing.Size(46, 34);
            this.btnLeftSideBannerUpload.TabIndex = 22;
            this.btnLeftSideBannerUpload.UseVisualStyleBackColor = false;
            this.btnLeftSideBannerUpload.Click += new System.EventHandler(this.btnLeftSideBannerUpload_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(280, 25);
            this.label3.TabIndex = 21;
            this.label3.Text = "Upload Organised By Image";
            // 
            // txtOrganised
            // 
            this.txtOrganised.Location = new System.Drawing.Point(312, 188);
            this.txtOrganised.Name = "txtOrganised";
            this.txtOrganised.Size = new System.Drawing.Size(323, 31);
            this.txtOrganised.TabIndex = 20;
            // 
            // btnOrganised
            // 
            this.btnOrganised.BackColor = System.Drawing.Color.White;
            this.btnOrganised.BackgroundImage = global::OHDR.Properties.Resources.upload;
            this.btnOrganised.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOrganised.Location = new System.Drawing.Point(653, 186);
            this.btnOrganised.Name = "btnOrganised";
            this.btnOrganised.Size = new System.Drawing.Size(46, 34);
            this.btnOrganised.TabIndex = 19;
            this.btnOrganised.UseVisualStyleBackColor = false;
            this.btnOrganised.Click += new System.EventHandler(this.btnOrganised_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(219, 25);
            this.label2.TabIndex = 18;
            this.label2.Text = "Upload Banner Image";
            // 
            // txtBanner
            // 
            this.txtBanner.Location = new System.Drawing.Point(312, 130);
            this.txtBanner.Name = "txtBanner";
            this.txtBanner.Size = new System.Drawing.Size(323, 31);
            this.txtBanner.TabIndex = 17;
            // 
            // btnHeaderUpload
            // 
            this.btnHeaderUpload.BackColor = System.Drawing.Color.White;
            this.btnHeaderUpload.BackgroundImage = global::OHDR.Properties.Resources.upload;
            this.btnHeaderUpload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHeaderUpload.Location = new System.Drawing.Point(653, 128);
            this.btnHeaderUpload.Name = "btnHeaderUpload";
            this.btnHeaderUpload.Size = new System.Drawing.Size(46, 34);
            this.btnHeaderUpload.TabIndex = 16;
            this.btnHeaderUpload.UseVisualStyleBackColor = false;
            this.btnHeaderUpload.Click += new System.EventHandler(this.btnHeaderUpload_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label19);
            this.panel3.Controls.Add(this.label17);
            this.panel3.Controls.Add(this.txtTextArea);
            this.panel3.Controls.Add(this.label16);
            this.panel3.Controls.Add(this.txtBarcodeArea);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.txtBadgeArea);
            this.panel3.Location = new System.Drawing.Point(943, 53);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(871, 344);
            this.panel3.TabIndex = 18;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(93, 38);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(423, 55);
            this.label19.TabIndex = 73;
            this.label19.Text = "Print Area Settings";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(98, 156);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(105, 25);
            this.label17.TabIndex = 72;
            this.label17.Text = "Text Area";
            // 
            // txtTextArea
            // 
            this.txtTextArea.Location = new System.Drawing.Point(384, 156);
            this.txtTextArea.Name = "txtTextArea";
            this.txtTextArea.Size = new System.Drawing.Size(323, 31);
            this.txtTextArea.TabIndex = 71;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(98, 215);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(143, 25);
            this.label16.TabIndex = 70;
            this.label16.Text = "Barcode Area";
            // 
            // txtBarcodeArea
            // 
            this.txtBarcodeArea.Location = new System.Drawing.Point(384, 215);
            this.txtBarcodeArea.Name = "txtBarcodeArea";
            this.txtBarcodeArea.Size = new System.Drawing.Size(323, 31);
            this.txtBarcodeArea.TabIndex = 69;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(98, 275);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(125, 25);
            this.label15.TabIndex = 68;
            this.label15.Text = "Badge Area";
            // 
            // txtBadgeArea
            // 
            this.txtBadgeArea.Location = new System.Drawing.Point(384, 275);
            this.txtBadgeArea.Name = "txtBadgeArea";
            this.txtBadgeArea.Size = new System.Drawing.Size(323, 31);
            this.txtBadgeArea.TabIndex = 67;
            // 
            // btnSaveNContinue
            // 
            this.btnSaveNContinue.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveNContinue.Location = new System.Drawing.Point(12, 1087);
            this.btnSaveNContinue.Name = "btnSaveNContinue";
            this.btnSaveNContinue.Size = new System.Drawing.Size(2436, 129);
            this.btnSaveNContinue.TabIndex = 83;
            this.btnSaveNContinue.Text = "Save and Continue";
            this.btnSaveNContinue.UseVisualStyleBackColor = true;
            this.btnSaveNContinue.Click += new System.EventHandler(this.btnSaveNContinue_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(1979, 209);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 33;
            this.dataGridView2.Size = new System.Drawing.Size(439, 363);
            this.dataGridView2.TabIndex = 84;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(1969, 53);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(479, 55);
            this.label21.TabIndex = 74;
            this.label21.Text = "Datewise User Count";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(1979, 147);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(239, 25);
            this.label22.TabIndex = 85;
            this.label22.Text = "Total Registered User =";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(2224, 146);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(24, 25);
            this.label23.TabIndex = 86;
            this.label23.Text = "0";
            // 
            // cmbEnabeSideBanner
            // 
            this.cmbEnabeSideBanner.FormattingEnabled = true;
            this.cmbEnabeSideBanner.Items.AddRange(new object[] {
            "TRUE",
            "FALSE"});
            this.cmbEnabeSideBanner.Location = new System.Drawing.Point(399, 563);
            this.cmbEnabeSideBanner.Name = "cmbEnabeSideBanner";
            this.cmbEnabeSideBanner.Size = new System.Drawing.Size(323, 33);
            this.cmbEnabeSideBanner.TabIndex = 83;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(113, 563);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(197, 25);
            this.label24.TabIndex = 82;
            this.label24.Text = "Enable SideBanner";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(26, 76);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(190, 25);
            this.label25.TabIndex = 63;
            this.label25.Text = "Upload Icon Image";
            // 
            // txtIconImage
            // 
            this.txtIconImage.Location = new System.Drawing.Point(312, 76);
            this.txtIconImage.Name = "txtIconImage";
            this.txtIconImage.Size = new System.Drawing.Size(323, 31);
            this.txtIconImage.TabIndex = 62;
            // 
            // btnIconUpload
            // 
            this.btnIconUpload.BackColor = System.Drawing.Color.White;
            this.btnIconUpload.BackgroundImage = global::OHDR.Properties.Resources.upload;
            this.btnIconUpload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnIconUpload.Location = new System.Drawing.Point(653, 74);
            this.btnIconUpload.Name = "btnIconUpload";
            this.btnIconUpload.Size = new System.Drawing.Size(46, 34);
            this.btnIconUpload.TabIndex = 61;
            this.btnIconUpload.UseVisualStyleBackColor = false;
            this.btnIconUpload.Click += new System.EventHandler(this.btnIconUpload_Click);
            // 
            // btnClearData
            // 
            this.btnClearData.Location = new System.Drawing.Point(724, 623);
            this.btnClearData.Margin = new System.Windows.Forms.Padding(6);
            this.btnClearData.Name = "btnClearData";
            this.btnClearData.Size = new System.Drawing.Size(209, 44);
            this.btnClearData.TabIndex = 87;
            this.btnClearData.Text = "Clear Data";
            this.btnClearData.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2540, 1256);
            this.Controls.Add(this.btnClearData);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.btnSaveNContinue);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnDownloadData);
            this.Controls.Add(this.btnUploadCSVFile);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnUploadCSVFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnDownloadData;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtMainPanelLebel;
        private System.Windows.Forms.ComboBox cmbBarcode;
        private System.Windows.Forms.ComboBox cmbEnableSearch;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtTearTime;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPrefix;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtRegistrationType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtThemeColor;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtHeaderSize;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtOrganisedSize;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRightSideBanner;
        private System.Windows.Forms.Button btnRightSideBannerUpload;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLeftSideBanner;
        private System.Windows.Forms.Button btnLeftSideBannerUpload;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtOrganised;
        private System.Windows.Forms.Button btnOrganised;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBanner;
        private System.Windows.Forms.Button btnHeaderUpload;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtTextArea;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtBarcodeArea;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtBadgeArea;
        private System.Windows.Forms.Button btnSaveNContinue;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox cmbEnabeSideBanner;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtIconImage;
        private System.Windows.Forms.Button btnIconUpload;
        private System.Windows.Forms.Button btnClearData;
    }
}