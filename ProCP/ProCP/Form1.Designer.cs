namespace ProCP
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.animationBox = new System.Windows.Forms.PictureBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.generalStatsTable = new System.Windows.Forms.DataGridView();
            this.pieChartBagsSecurity = new LiveCharts.WinForms.PieChart();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.PrimarySecurityChart = new LiveCharts.WinForms.CartesianChart();
            this.cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            this.gbSettings = new System.Windows.Forms.GroupBox();
            this.btnSpeed4 = new System.Windows.Forms.Button();
            this.btnSpeed3 = new System.Windows.Forms.Button();
            this.btnSpeed2 = new System.Windows.Forms.Button();
            this.btnSpeed1 = new System.Windows.Forms.Button();
            this.cmbEmployees = new System.Windows.Forms.ComboBox();
            this.cmbCapacity = new System.Windows.Forms.ComboBox();
            this.labelEmployees = new System.Windows.Forms.Label();
            this.labelConveyorSpeed = new System.Windows.Forms.Label();
            this.labelCapacity = new System.Windows.Forms.Label();
            this.MapImportExportgroupBox = new System.Windows.Forms.GroupBox();
            this.buttonExport = new System.Windows.Forms.Button();
            this.buttonImport = new System.Windows.Forms.Button();
            this.gbStartStop = new System.Windows.Forms.GroupBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.gbBuild = new System.Windows.Forms.GroupBox();
            this.btnSecurity = new System.Windows.Forms.Button();
            this.btnConveyor = new System.Windows.Forms.Button();
            this.btnDropoff = new System.Windows.Forms.Button();
            this.btnMain = new System.Windows.Forms.Button();
            this.btnCheckin = new System.Windows.Forms.Button();
            this.gbFlightInfo = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lbFlights = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cmbDropOffPoint = new System.Windows.Forms.ComboBox();
            this.labelDropOffPoint = new System.Windows.Forms.Label();
            this.cmbCheckInDesk = new System.Windows.Forms.ComboBox();
            this.labelCheckInDesk = new System.Windows.Forms.Label();
            this.departureTime = new System.Windows.Forms.DateTimePicker();
            this.labelDate = new System.Windows.Forms.Label();
            this.textBoxNumberOfBags = new System.Windows.Forms.TextBox();
            this.labelNoOfBags = new System.Windows.Forms.Label();
            this.textBoxFlightNumber = new System.Windows.Forms.TextBox();
            this.labelFlightNo = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.animationBox)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.generalStatsTable)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.gbSettings.SuspendLayout();
            this.MapImportExportgroupBox.SuspendLayout();
            this.gbStartStop.SuspendLayout();
            this.gbBuild.SuspendLayout();
            this.gbFlightInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Controls.Add(this.gbSettings);
            this.panel1.Controls.Add(this.MapImportExportgroupBox);
            this.panel1.Controls.Add(this.gbStartStop);
            this.panel1.Controls.Add(this.gbBuild);
            this.panel1.Controls.Add(this.gbFlightInfo);
            this.panel1.Location = new System.Drawing.Point(4, 11);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1482, 867);
            this.panel1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tabControl1.ItemSize = new System.Drawing.Size(141, 35);
            this.tabControl1.Location = new System.Drawing.Point(402, 2);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1077, 862);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.animationBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 39);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(1069, 819);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Simulation Map";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // animationBox
            // 
            this.animationBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.animationBox.Location = new System.Drawing.Point(3, 2);
            this.animationBox.Name = "animationBox";
            this.animationBox.Size = new System.Drawing.Size(1063, 815);
            this.animationBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.animationBox.TabIndex = 0;
            this.animationBox.TabStop = false;
            this.animationBox.Paint += new System.Windows.Forms.PaintEventHandler(this.animationBox_Paint_1);
            this.animationBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.animationBox_MouseDown);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.generalStatsTable);
            this.tabPage3.Controls.Add(this.pieChartBagsSecurity);
            this.tabPage3.Location = new System.Drawing.Point(4, 39);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1069, 819);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "General Statistics Overview";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // generalStatsTable
            // 
            this.generalStatsTable.AllowUserToAddRows = false;
            this.generalStatsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.generalStatsTable.Location = new System.Drawing.Point(23, 16);
            this.generalStatsTable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.generalStatsTable.Name = "generalStatsTable";
            this.generalStatsTable.ReadOnly = true;
            this.generalStatsTable.RowHeadersWidth = 51;
            this.generalStatsTable.RowTemplate.Height = 24;
            this.generalStatsTable.RowTemplate.ReadOnly = true;
            this.generalStatsTable.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.generalStatsTable.Size = new System.Drawing.Size(653, 65);
            this.generalStatsTable.TabIndex = 4;
            // 
            // pieChartBagsSecurity
            // 
            this.pieChartBagsSecurity.Location = new System.Drawing.Point(743, 16);
            this.pieChartBagsSecurity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pieChartBagsSecurity.Name = "pieChartBagsSecurity";
            this.pieChartBagsSecurity.Size = new System.Drawing.Size(260, 276);
            this.pieChartBagsSecurity.TabIndex = 3;
            this.pieChartBagsSecurity.Text = "Bags in security";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.PrimarySecurityChart);
            this.tabPage2.Controls.Add(this.cartesianChart1);
            this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.Location = new System.Drawing.Point(4, 39);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Size = new System.Drawing.Size(1069, 819);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Statistics";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // PrimarySecurityChart
            // 
            this.PrimarySecurityChart.Location = new System.Drawing.Point(61, 405);
            this.PrimarySecurityChart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PrimarySecurityChart.Name = "PrimarySecurityChart";
            this.PrimarySecurityChart.Size = new System.Drawing.Size(645, 314);
            this.PrimarySecurityChart.TabIndex = 1;
            this.PrimarySecurityChart.Text = "cartesianChart2";
            // 
            // cartesianChart1
            // 
            this.cartesianChart1.Location = new System.Drawing.Point(61, 50);
            this.cartesianChart1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cartesianChart1.Name = "cartesianChart1";
            this.cartesianChart1.Size = new System.Drawing.Size(645, 314);
            this.cartesianChart1.TabIndex = 0;
            this.cartesianChart1.Text = "cartesianChart1";
            // 
            // gbSettings
            // 
            this.gbSettings.Controls.Add(this.btnSpeed4);
            this.gbSettings.Controls.Add(this.btnSpeed3);
            this.gbSettings.Controls.Add(this.btnSpeed2);
            this.gbSettings.Controls.Add(this.btnSpeed1);
            this.gbSettings.Controls.Add(this.cmbEmployees);
            this.gbSettings.Controls.Add(this.cmbCapacity);
            this.gbSettings.Controls.Add(this.labelEmployees);
            this.gbSettings.Controls.Add(this.labelConveyorSpeed);
            this.gbSettings.Controls.Add(this.labelCapacity);
            this.gbSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSettings.Location = new System.Drawing.Point(5, 588);
            this.gbSettings.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbSettings.Size = new System.Drawing.Size(393, 145);
            this.gbSettings.TabIndex = 5;
            this.gbSettings.TabStop = false;
            this.gbSettings.Text = "Settings";
            // 
            // btnSpeed4
            // 
            this.btnSpeed4.BackColor = System.Drawing.Color.SkyBlue;
            this.btnSpeed4.FlatAppearance.BorderSize = 0;
            this.btnSpeed4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSpeed4.Location = new System.Drawing.Point(319, 110);
            this.btnSpeed4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSpeed4.Name = "btnSpeed4";
            this.btnSpeed4.Size = new System.Drawing.Size(67, 28);
            this.btnSpeed4.TabIndex = 8;
            this.btnSpeed4.Text = "4";
            this.btnSpeed4.UseVisualStyleBackColor = false;
            // 
            // btnSpeed3
            // 
            this.btnSpeed3.BackColor = System.Drawing.Color.SkyBlue;
            this.btnSpeed3.FlatAppearance.BorderSize = 0;
            this.btnSpeed3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSpeed3.Location = new System.Drawing.Point(217, 110);
            this.btnSpeed3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSpeed3.Name = "btnSpeed3";
            this.btnSpeed3.Size = new System.Drawing.Size(67, 28);
            this.btnSpeed3.TabIndex = 7;
            this.btnSpeed3.Text = "3";
            this.btnSpeed3.UseVisualStyleBackColor = false;
            // 
            // btnSpeed2
            // 
            this.btnSpeed2.BackColor = System.Drawing.Color.SkyBlue;
            this.btnSpeed2.FlatAppearance.BorderSize = 0;
            this.btnSpeed2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSpeed2.Location = new System.Drawing.Point(115, 110);
            this.btnSpeed2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSpeed2.Name = "btnSpeed2";
            this.btnSpeed2.Size = new System.Drawing.Size(67, 28);
            this.btnSpeed2.TabIndex = 6;
            this.btnSpeed2.Text = "2";
            this.btnSpeed2.UseVisualStyleBackColor = false;
            // 
            // btnSpeed1
            // 
            this.btnSpeed1.BackColor = System.Drawing.Color.SkyBlue;
            this.btnSpeed1.FlatAppearance.BorderSize = 0;
            this.btnSpeed1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSpeed1.Location = new System.Drawing.Point(11, 110);
            this.btnSpeed1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSpeed1.Name = "btnSpeed1";
            this.btnSpeed1.Size = new System.Drawing.Size(67, 28);
            this.btnSpeed1.TabIndex = 5;
            this.btnSpeed1.Text = "1";
            this.btnSpeed1.UseVisualStyleBackColor = false;
            // 
            // cmbEmployees
            // 
            this.cmbEmployees.FormattingEnabled = true;
            this.cmbEmployees.Location = new System.Drawing.Point(275, 30);
            this.cmbEmployees.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbEmployees.Name = "cmbEmployees";
            this.cmbEmployees.Size = new System.Drawing.Size(73, 26);
            this.cmbEmployees.TabIndex = 4;
            // 
            // cmbCapacity
            // 
            this.cmbCapacity.FormattingEnabled = true;
            this.cmbCapacity.Location = new System.Drawing.Point(84, 30);
            this.cmbCapacity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbCapacity.Name = "cmbCapacity";
            this.cmbCapacity.Size = new System.Drawing.Size(73, 26);
            this.cmbCapacity.TabIndex = 3;
            // 
            // labelEmployees
            // 
            this.labelEmployees.AutoSize = true;
            this.labelEmployees.Location = new System.Drawing.Point(181, 30);
            this.labelEmployees.Name = "labelEmployees";
            this.labelEmployees.Size = new System.Drawing.Size(82, 18);
            this.labelEmployees.TabIndex = 2;
            this.labelEmployees.Text = "Employees";
            // 
            // labelConveyorSpeed
            // 
            this.labelConveyorSpeed.AutoSize = true;
            this.labelConveyorSpeed.Location = new System.Drawing.Point(7, 81);
            this.labelConveyorSpeed.Name = "labelConveyorSpeed";
            this.labelConveyorSpeed.Size = new System.Drawing.Size(118, 18);
            this.labelConveyorSpeed.TabIndex = 1;
            this.labelConveyorSpeed.Text = "Conveyor Speed";
            // 
            // labelCapacity
            // 
            this.labelCapacity.AutoSize = true;
            this.labelCapacity.Location = new System.Drawing.Point(7, 31);
            this.labelCapacity.Name = "labelCapacity";
            this.labelCapacity.Size = new System.Drawing.Size(65, 18);
            this.labelCapacity.TabIndex = 0;
            this.labelCapacity.Text = "Capacity";
            // 
            // MapImportExportgroupBox
            // 
            this.MapImportExportgroupBox.Controls.Add(this.buttonExport);
            this.MapImportExportgroupBox.Controls.Add(this.buttonImport);
            this.MapImportExportgroupBox.Location = new System.Drawing.Point(1, 737);
            this.MapImportExportgroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MapImportExportgroupBox.Name = "MapImportExportgroupBox";
            this.MapImportExportgroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MapImportExportgroupBox.Size = new System.Drawing.Size(395, 62);
            this.MapImportExportgroupBox.TabIndex = 7;
            this.MapImportExportgroupBox.TabStop = false;
            this.MapImportExportgroupBox.Tag = "";
            this.MapImportExportgroupBox.Text = "MapImportExport";
            // 
            // buttonExport
            // 
            this.buttonExport.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonExport.BackgroundImage")));
            this.buttonExport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonExport.FlatAppearance.BorderSize = 0;
            this.buttonExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExport.Location = new System.Drawing.Point(201, 6);
            this.buttonExport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(61, 63);
            this.buttonExport.TabIndex = 4;
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // buttonImport
            // 
            this.buttonImport.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonImport.BackgroundImage")));
            this.buttonImport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonImport.FlatAppearance.BorderSize = 0;
            this.buttonImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonImport.Location = new System.Drawing.Point(131, 12);
            this.buttonImport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Size = new System.Drawing.Size(51, 50);
            this.buttonImport.TabIndex = 6;
            this.buttonImport.UseVisualStyleBackColor = true;
            this.buttonImport.Click += new System.EventHandler(this.buttonImport_Click);
            // 
            // gbStartStop
            // 
            this.gbStartStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbStartStop.Controls.Add(this.btnStop);
            this.gbStartStop.Controls.Add(this.btnStart);
            this.gbStartStop.Location = new System.Drawing.Point(3, 802);
            this.gbStartStop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbStartStop.Name = "gbStartStop";
            this.gbStartStop.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbStartStop.Size = new System.Drawing.Size(395, 62);
            this.gbStartStop.TabIndex = 6;
            this.gbStartStop.TabStop = false;
            this.gbStartStop.Text = "Start/Stop";
            // 
            // btnStop
            // 
            this.btnStop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnStop.BackgroundImage")));
            this.btnStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnStop.FlatAppearance.BorderSize = 0;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.Location = new System.Drawing.Point(199, 8);
            this.btnStop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(64, 69);
            this.btnStop.TabIndex = 4;
            this.btnStop.UseVisualStyleBackColor = true;
            // 
            // btnStart
            // 
            this.btnStart.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnStart.BackgroundImage")));
            this.btnStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnStart.FlatAppearance.BorderSize = 0;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(123, 8);
            this.btnStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(61, 60);
            this.btnStart.TabIndex = 6;
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // gbBuild
            // 
            this.gbBuild.Controls.Add(this.btnSecurity);
            this.gbBuild.Controls.Add(this.btnConveyor);
            this.gbBuild.Controls.Add(this.btnDropoff);
            this.gbBuild.Controls.Add(this.btnMain);
            this.gbBuild.Controls.Add(this.btnCheckin);
            this.gbBuild.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbBuild.Location = new System.Drawing.Point(5, 2);
            this.gbBuild.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbBuild.Name = "gbBuild";
            this.gbBuild.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbBuild.Size = new System.Drawing.Size(391, 117);
            this.gbBuild.TabIndex = 0;
            this.gbBuild.TabStop = false;
            this.gbBuild.Text = "Build Type";
            // 
            // btnSecurity
            // 
            this.btnSecurity.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnSecurity.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSecurity.BackgroundImage")));
            this.btnSecurity.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSecurity.FlatAppearance.BorderSize = 0;
            this.btnSecurity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSecurity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSecurity.Location = new System.Drawing.Point(84, 39);
            this.btnSecurity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSecurity.Name = "btnSecurity";
            this.btnSecurity.Size = new System.Drawing.Size(68, 61);
            this.btnSecurity.TabIndex = 4;
            this.btnSecurity.UseVisualStyleBackColor = false;
            this.btnSecurity.Click += new System.EventHandler(this.btnSecurity_Click);
            // 
            // btnConveyor
            // 
            this.btnConveyor.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnConveyor.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnConveyor.BackgroundImage")));
            this.btnConveyor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnConveyor.FlatAppearance.BorderSize = 0;
            this.btnConveyor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConveyor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConveyor.Location = new System.Drawing.Point(232, 41);
            this.btnConveyor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnConveyor.Name = "btnConveyor";
            this.btnConveyor.Size = new System.Drawing.Size(68, 61);
            this.btnConveyor.TabIndex = 3;
            this.btnConveyor.UseVisualStyleBackColor = false;
            this.btnConveyor.Click += new System.EventHandler(this.btnConveyor_Click);
            // 
            // btnDropoff
            // 
            this.btnDropoff.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnDropoff.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDropoff.BackgroundImage")));
            this.btnDropoff.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDropoff.FlatAppearance.BorderSize = 0;
            this.btnDropoff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDropoff.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDropoff.Location = new System.Drawing.Point(158, 39);
            this.btnDropoff.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDropoff.Name = "btnDropoff";
            this.btnDropoff.Size = new System.Drawing.Size(68, 61);
            this.btnDropoff.TabIndex = 2;
            this.btnDropoff.UseVisualStyleBackColor = false;
            this.btnDropoff.Click += new System.EventHandler(this.btnDropoff_Click);
            // 
            // btnMain
            // 
            this.btnMain.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnMain.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMain.BackgroundImage")));
            this.btnMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMain.FlatAppearance.BorderSize = 0;
            this.btnMain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMain.Location = new System.Drawing.Point(306, 39);
            this.btnMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMain.Name = "btnMain";
            this.btnMain.Size = new System.Drawing.Size(68, 61);
            this.btnMain.TabIndex = 1;
            this.btnMain.UseVisualStyleBackColor = false;
            this.btnMain.Click += new System.EventHandler(this.btnMain_Click);
            // 
            // btnCheckin
            // 
            this.btnCheckin.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnCheckin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCheckin.BackgroundImage")));
            this.btnCheckin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCheckin.FlatAppearance.BorderSize = 0;
            this.btnCheckin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckin.Location = new System.Drawing.Point(11, 39);
            this.btnCheckin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCheckin.Name = "btnCheckin";
            this.btnCheckin.Size = new System.Drawing.Size(68, 61);
            this.btnCheckin.TabIndex = 0;
            this.btnCheckin.UseVisualStyleBackColor = false;
            this.btnCheckin.Click += new System.EventHandler(this.btnCheckin_Click);
            // 
            // gbFlightInfo
            // 
            this.gbFlightInfo.BackColor = System.Drawing.Color.Transparent;
            this.gbFlightInfo.Controls.Add(this.btnDelete);
            this.gbFlightInfo.Controls.Add(this.lbFlights);
            this.gbFlightInfo.Controls.Add(this.btnAdd);
            this.gbFlightInfo.Controls.Add(this.cmbDropOffPoint);
            this.gbFlightInfo.Controls.Add(this.labelDropOffPoint);
            this.gbFlightInfo.Controls.Add(this.cmbCheckInDesk);
            this.gbFlightInfo.Controls.Add(this.labelCheckInDesk);
            this.gbFlightInfo.Controls.Add(this.departureTime);
            this.gbFlightInfo.Controls.Add(this.labelDate);
            this.gbFlightInfo.Controls.Add(this.textBoxNumberOfBags);
            this.gbFlightInfo.Controls.Add(this.labelNoOfBags);
            this.gbFlightInfo.Controls.Add(this.textBoxFlightNumber);
            this.gbFlightInfo.Controls.Add(this.labelFlightNo);
            this.gbFlightInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbFlightInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFlightInfo.Location = new System.Drawing.Point(5, 123);
            this.gbFlightInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbFlightInfo.Name = "gbFlightInfo";
            this.gbFlightInfo.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbFlightInfo.Size = new System.Drawing.Size(395, 461);
            this.gbFlightInfo.TabIndex = 1;
            this.gbFlightInfo.TabStop = false;
            this.gbFlightInfo.Text = "Flight Information";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(203, 324);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(184, 34);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "Delete Flight";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lbFlights
            // 
            this.lbFlights.FormattingEnabled = true;
            this.lbFlights.ItemHeight = 18;
            this.lbFlights.Location = new System.Drawing.Point(8, 195);
            this.lbFlights.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbFlights.Name = "lbFlights";
            this.lbFlights.Size = new System.Drawing.Size(381, 112);
            this.lbFlights.TabIndex = 11;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(8, 323);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(189, 35);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "Add Flight ";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cmbDropOffPoint
            // 
            this.cmbDropOffPoint.FormattingEnabled = true;
            this.cmbDropOffPoint.Location = new System.Drawing.Point(147, 146);
            this.cmbDropOffPoint.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbDropOffPoint.Name = "cmbDropOffPoint";
            this.cmbDropOffPoint.Size = new System.Drawing.Size(164, 26);
            this.cmbDropOffPoint.TabIndex = 9;
            // 
            // labelDropOffPoint
            // 
            this.labelDropOffPoint.AutoSize = true;
            this.labelDropOffPoint.Location = new System.Drawing.Point(5, 148);
            this.labelDropOffPoint.Name = "labelDropOffPoint";
            this.labelDropOffPoint.Size = new System.Drawing.Size(101, 18);
            this.labelDropOffPoint.TabIndex = 8;
            this.labelDropOffPoint.Text = "Drop-off Point";
            // 
            // cmbCheckInDesk
            // 
            this.cmbCheckInDesk.FormattingEnabled = true;
            this.cmbCheckInDesk.Location = new System.Drawing.Point(147, 114);
            this.cmbCheckInDesk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbCheckInDesk.Name = "cmbCheckInDesk";
            this.cmbCheckInDesk.Size = new System.Drawing.Size(164, 26);
            this.cmbCheckInDesk.TabIndex = 7;
            // 
            // labelCheckInDesk
            // 
            this.labelCheckInDesk.AutoSize = true;
            this.labelCheckInDesk.Location = new System.Drawing.Point(5, 118);
            this.labelCheckInDesk.Name = "labelCheckInDesk";
            this.labelCheckInDesk.Size = new System.Drawing.Size(106, 18);
            this.labelCheckInDesk.TabIndex = 6;
            this.labelCheckInDesk.Text = "Check-in Desk";
            // 
            // departureTime
            // 
            this.departureTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.departureTime.Location = new System.Drawing.Point(147, 85);
            this.departureTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.departureTime.Name = "departureTime";
            this.departureTime.Size = new System.Drawing.Size(164, 24);
            this.departureTime.TabIndex = 5;
            this.departureTime.Value = new System.DateTime(2019, 10, 14, 0, 0, 0, 0);
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Location = new System.Drawing.Point(5, 87);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(110, 18);
            this.labelDate.TabIndex = 4;
            this.labelDate.Text = "Departure Time";
            // 
            // textBoxNumberOfBags
            // 
            this.textBoxNumberOfBags.Location = new System.Drawing.Point(147, 57);
            this.textBoxNumberOfBags.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxNumberOfBags.Name = "textBoxNumberOfBags";
            this.textBoxNumberOfBags.Size = new System.Drawing.Size(164, 24);
            this.textBoxNumberOfBags.TabIndex = 3;
            // 
            // labelNoOfBags
            // 
            this.labelNoOfBags.AutoSize = true;
            this.labelNoOfBags.Location = new System.Drawing.Point(5, 58);
            this.labelNoOfBags.Name = "labelNoOfBags";
            this.labelNoOfBags.Size = new System.Drawing.Size(116, 18);
            this.labelNoOfBags.TabIndex = 2;
            this.labelNoOfBags.Text = "Number of Bags";
            // 
            // textBoxFlightNumber
            // 
            this.textBoxFlightNumber.Location = new System.Drawing.Point(147, 27);
            this.textBoxFlightNumber.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxFlightNumber.Name = "textBoxFlightNumber";
            this.textBoxFlightNumber.Size = new System.Drawing.Size(164, 24);
            this.textBoxFlightNumber.TabIndex = 1;
            // 
            // labelFlightNo
            // 
            this.labelFlightNo.AutoSize = true;
            this.labelFlightNo.Location = new System.Drawing.Point(5, 30);
            this.labelFlightNo.Name = "labelFlightNo";
            this.labelFlightNo.Size = new System.Drawing.Size(100, 18);
            this.labelFlightNo.TabIndex = 0;
            this.labelFlightNo.Text = "Flight Number";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1487, 877);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.Text = "ProCp";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.animationBox)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.generalStatsTable)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.gbSettings.ResumeLayout(false);
            this.gbSettings.PerformLayout();
            this.MapImportExportgroupBox.ResumeLayout(false);
            this.gbStartStop.ResumeLayout(false);
            this.gbBuild.ResumeLayout(false);
            this.gbFlightInfo.ResumeLayout(false);
            this.gbFlightInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.GroupBox gbFlightInfo;
        private System.Windows.Forms.GroupBox gbBuild;
        private System.Windows.Forms.GroupBox gbSettings;
        private System.Windows.Forms.Button btnSpeed4;
        private System.Windows.Forms.Button btnSpeed3;
        private System.Windows.Forms.Button btnSpeed2;
        private System.Windows.Forms.Button btnSpeed1;
        private System.Windows.Forms.ComboBox cmbEmployees;
        private System.Windows.Forms.ComboBox cmbCapacity;
        private System.Windows.Forms.Label labelEmployees;
        private System.Windows.Forms.Label labelConveyorSpeed;
        private System.Windows.Forms.Label labelCapacity;
        private System.Windows.Forms.Button btnSecurity;
        private System.Windows.Forms.Button btnConveyor;
        private System.Windows.Forms.Button btnDropoff;
        private System.Windows.Forms.Button btnMain;
        private System.Windows.Forms.Button btnCheckin;
        private System.Windows.Forms.Label labelFlightNo;
        private System.Windows.Forms.TextBox textBoxNumberOfBags;
        private System.Windows.Forms.Label labelNoOfBags;
        private System.Windows.Forms.TextBox textBoxFlightNumber;
        private System.Windows.Forms.DateTimePicker departureTime;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.ComboBox cmbCheckInDesk;
        private System.Windows.Forms.Label labelCheckInDesk;
        private System.Windows.Forms.ComboBox cmbDropOffPoint;
        private System.Windows.Forms.Label labelDropOffPoint;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ListBox lbFlights;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnStart;
        private LiveCharts.WinForms.CartesianChart cartesianChart1;
        private LiveCharts.WinForms.CartesianChart PrimarySecurityChart;
        private System.Windows.Forms.TabPage tabPage3;
        private LiveCharts.WinForms.PieChart pieChartBagsSecurity;
        private System.Windows.Forms.DataGridView generalStatsTable;
        private System.Windows.Forms.GroupBox gbStartStop;
        private System.Windows.Forms.GroupBox MapImportExportgroupBox;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.Button buttonImport;
        private System.Windows.Forms.PictureBox animationBox;
    }
}

