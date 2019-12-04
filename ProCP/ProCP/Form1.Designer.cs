﻿namespace ProCP
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.gb1 = new System.Windows.Forms.GroupBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
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
            this.gbFlightInfo = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.AvailableFlights = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cmbDropOffPoint = new System.Windows.Forms.ComboBox();
            this.labelDropOffPoint = new System.Windows.Forms.Label();
            this.cmbCheckInDesk = new System.Windows.Forms.ComboBox();
            this.labelCheckInDesk = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.labelDate = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.labelNoOfBags = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.labelFlightNo = new System.Windows.Forms.Label();
            this.gbBuild = new System.Windows.Forms.GroupBox();
            this.btnSecurity = new System.Windows.Forms.Button();
            this.btnConveyor = new System.Windows.Forms.Button();
            this.btnDropoff = new System.Windows.Forms.Button();
            this.btnMain = new System.Windows.Forms.Button();
            this.btnCheckin = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.animationBox = new System.Windows.Forms.PictureBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.generalStatsTable = new System.Windows.Forms.DataGridView();
            this.pieChartBagsSecurity = new LiveCharts.WinForms.PieChart();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.PrimarySecurityChart = new LiveCharts.WinForms.CartesianChart();
            this.cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            this.panel1.SuspendLayout();
            this.gb1.SuspendLayout();
            this.gbSettings.SuspendLayout();
            this.gbFlightInfo.SuspendLayout();
            this.gbBuild.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.animationBox)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.generalStatsTable)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.gb1);
            this.panel1.Controls.Add(this.gbSettings);
            this.panel1.Controls.Add(this.gbFlightInfo);
            this.panel1.Controls.Add(this.gbBuild);
            this.panel1.Location = new System.Drawing.Point(4, 10);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(394, 790);
            this.panel1.TabIndex = 0;
            // 
            // gb1
            // 
            this.gb1.Controls.Add(this.btnStop);
            this.gb1.Controls.Add(this.btnStart);
            this.gb1.Location = new System.Drawing.Point(0, 726);
            this.gb1.Name = "gb1";
            this.gb1.Size = new System.Drawing.Size(394, 61);
            this.gb1.TabIndex = 6;
            this.gb1.TabStop = false;
            // 
            // btnStop
            // 
            this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.Location = new System.Drawing.Point(203, 20);
            this.btnStop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(151, 29);
            this.btnStop.TabIndex = 4;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(31, 20);
            this.btnStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(151, 29);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
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
            this.gbSettings.Location = new System.Drawing.Point(0, 122);
            this.gbSettings.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbSettings.Size = new System.Drawing.Size(391, 159);
            this.gbSettings.TabIndex = 5;
            this.gbSettings.TabStop = false;
            this.gbSettings.Text = "Settings";
            // 
            // btnSpeed4
            // 
            this.btnSpeed4.Location = new System.Drawing.Point(319, 110);
            this.btnSpeed4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSpeed4.Name = "btnSpeed4";
            this.btnSpeed4.Size = new System.Drawing.Size(67, 28);
            this.btnSpeed4.TabIndex = 8;
            this.btnSpeed4.Text = "4";
            this.btnSpeed4.UseVisualStyleBackColor = true;
            // 
            // btnSpeed3
            // 
            this.btnSpeed3.Location = new System.Drawing.Point(217, 110);
            this.btnSpeed3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSpeed3.Name = "btnSpeed3";
            this.btnSpeed3.Size = new System.Drawing.Size(67, 28);
            this.btnSpeed3.TabIndex = 7;
            this.btnSpeed3.Text = "3";
            this.btnSpeed3.UseVisualStyleBackColor = true;
            // 
            // btnSpeed2
            // 
            this.btnSpeed2.Location = new System.Drawing.Point(115, 110);
            this.btnSpeed2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSpeed2.Name = "btnSpeed2";
            this.btnSpeed2.Size = new System.Drawing.Size(67, 28);
            this.btnSpeed2.TabIndex = 6;
            this.btnSpeed2.Text = "2";
            this.btnSpeed2.UseVisualStyleBackColor = true;
            // 
            // btnSpeed1
            // 
            this.btnSpeed1.Location = new System.Drawing.Point(11, 110);
            this.btnSpeed1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSpeed1.Name = "btnSpeed1";
            this.btnSpeed1.Size = new System.Drawing.Size(67, 28);
            this.btnSpeed1.TabIndex = 5;
            this.btnSpeed1.Text = "1";
            this.btnSpeed1.UseVisualStyleBackColor = true;
            // 
            // cmbEmployees
            // 
            this.cmbEmployees.FormattingEnabled = true;
            this.cmbEmployees.Location = new System.Drawing.Point(275, 29);
            this.cmbEmployees.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbEmployees.Name = "cmbEmployees";
            this.cmbEmployees.Size = new System.Drawing.Size(73, 26);
            this.cmbEmployees.TabIndex = 4;
            // 
            // cmbCapacity
            // 
            this.cmbCapacity.FormattingEnabled = true;
            this.cmbCapacity.Location = new System.Drawing.Point(84, 29);
            this.cmbCapacity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbCapacity.Name = "cmbCapacity";
            this.cmbCapacity.Size = new System.Drawing.Size(73, 26);
            this.cmbCapacity.TabIndex = 3;
            // 
            // labelEmployees
            // 
            this.labelEmployees.AutoSize = true;
            this.labelEmployees.Location = new System.Drawing.Point(182, 29);
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
            // gbFlightInfo
            // 
            this.gbFlightInfo.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gbFlightInfo.Controls.Add(this.btnDelete);
            this.gbFlightInfo.Controls.Add(this.AvailableFlights);
            this.gbFlightInfo.Controls.Add(this.btnAdd);
            this.gbFlightInfo.Controls.Add(this.cmbDropOffPoint);
            this.gbFlightInfo.Controls.Add(this.labelDropOffPoint);
            this.gbFlightInfo.Controls.Add(this.cmbCheckInDesk);
            this.gbFlightInfo.Controls.Add(this.labelCheckInDesk);
            this.gbFlightInfo.Controls.Add(this.dateTimePicker1);
            this.gbFlightInfo.Controls.Add(this.labelDate);
            this.gbFlightInfo.Controls.Add(this.textBox2);
            this.gbFlightInfo.Controls.Add(this.labelNoOfBags);
            this.gbFlightInfo.Controls.Add(this.textBox1);
            this.gbFlightInfo.Controls.Add(this.labelFlightNo);
            this.gbFlightInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFlightInfo.Location = new System.Drawing.Point(0, 286);
            this.gbFlightInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbFlightInfo.Name = "gbFlightInfo";
            this.gbFlightInfo.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbFlightInfo.Size = new System.Drawing.Size(394, 447);
            this.gbFlightInfo.TabIndex = 1;
            this.gbFlightInfo.TabStop = false;
            this.gbFlightInfo.Text = "Flight Information";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(5, 401);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(380, 34);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "Delete Flight";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // AvailableFlights
            // 
            this.AvailableFlights.FormattingEnabled = true;
            this.AvailableFlights.ItemHeight = 18;
            this.AvailableFlights.Location = new System.Drawing.Point(5, 244);
            this.AvailableFlights.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AvailableFlights.Name = "AvailableFlights";
            this.AvailableFlights.Size = new System.Drawing.Size(381, 130);
            this.AvailableFlights.TabIndex = 11;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(5, 189);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(380, 35);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "Add Flight ";
            this.btnAdd.UseVisualStyleBackColor = true;
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
            this.labelDropOffPoint.Location = new System.Drawing.Point(6, 148);
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
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker1.Location = new System.Drawing.Point(147, 85);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(164, 24);
            this.dateTimePicker1.TabIndex = 5;
            this.dateTimePicker1.Value = new System.DateTime(2019, 10, 14, 0, 0, 0, 0);
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
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(147, 57);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(164, 24);
            this.textBox2.TabIndex = 3;
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
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(147, 27);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(164, 24);
            this.textBox1.TabIndex = 1;
            // 
            // labelFlightNo
            // 
            this.labelFlightNo.AutoSize = true;
            this.labelFlightNo.Location = new System.Drawing.Point(5, 29);
            this.labelFlightNo.Name = "labelFlightNo";
            this.labelFlightNo.Size = new System.Drawing.Size(100, 18);
            this.labelFlightNo.TabIndex = 0;
            this.labelFlightNo.Text = "Flight Number";
            // 
            // gbBuild
            // 
            this.gbBuild.Controls.Add(this.btnSecurity);
            this.gbBuild.Controls.Add(this.btnConveyor);
            this.gbBuild.Controls.Add(this.btnDropoff);
            this.gbBuild.Controls.Add(this.btnMain);
            this.gbBuild.Controls.Add(this.btnCheckin);
            this.gbBuild.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbBuild.Location = new System.Drawing.Point(0, 0);
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
            this.btnSecurity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSecurity.Location = new System.Drawing.Point(14, 74);
            this.btnSecurity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSecurity.Name = "btnSecurity";
            this.btnSecurity.Size = new System.Drawing.Size(173, 34);
            this.btnSecurity.TabIndex = 4;
            this.btnSecurity.Text = "Security Block";
            this.btnSecurity.UseVisualStyleBackColor = true;
            this.btnSecurity.Click += new System.EventHandler(this.btnSecurity_Click);
            // 
            // btnConveyor
            // 
            this.btnConveyor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConveyor.Location = new System.Drawing.Point(284, 26);
            this.btnConveyor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnConveyor.Name = "btnConveyor";
            this.btnConveyor.Size = new System.Drawing.Size(92, 35);
            this.btnConveyor.TabIndex = 3;
            this.btnConveyor.Text = "Conveyor";
            this.btnConveyor.UseVisualStyleBackColor = true;
            this.btnConveyor.Click += new System.EventHandler(this.btnConveyor_Click);
            // 
            // btnDropoff
            // 
            this.btnDropoff.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDropoff.Location = new System.Drawing.Point(158, 26);
            this.btnDropoff.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDropoff.Name = "btnDropoff";
            this.btnDropoff.Size = new System.Drawing.Size(82, 35);
            this.btnDropoff.TabIndex = 2;
            this.btnDropoff.Text = "Drop-off";
            this.btnDropoff.UseVisualStyleBackColor = true;
            this.btnDropoff.Click += new System.EventHandler(this.btnDropoff_Click);
            // 
            // btnMain
            // 
            this.btnMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMain.Location = new System.Drawing.Point(203, 74);
            this.btnMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMain.Name = "btnMain";
            this.btnMain.Size = new System.Drawing.Size(173, 34);
            this.btnMain.TabIndex = 1;
            this.btnMain.Text = "Main Process Area";
            this.btnMain.UseVisualStyleBackColor = true;
            this.btnMain.Click += new System.EventHandler(this.btnMain_Click);
            // 
            // btnCheckin
            // 
            this.btnCheckin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckin.Location = new System.Drawing.Point(14, 26);
            this.btnCheckin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCheckin.Name = "btnCheckin";
            this.btnCheckin.Size = new System.Drawing.Size(99, 35);
            this.btnCheckin.TabIndex = 0;
            this.btnCheckin.Text = "Check-in ";
            this.btnCheckin.UseVisualStyleBackColor = true;
            this.btnCheckin.Click += new System.EventHandler(this.btnCheckin_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(404, 10);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1304, 793);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.animationBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(1296, 762);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Simulation Map";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // animationBox
            // 
            this.animationBox.Location = new System.Drawing.Point(0, -1);
            this.animationBox.Name = "animationBox";
            this.animationBox.Size = new System.Drawing.Size(1296, 764);
            this.animationBox.TabIndex = 0;
            this.animationBox.TabStop = false;
            this.animationBox.Paint += new System.Windows.Forms.PaintEventHandler(this.animationBox_Paint_1);
            this.animationBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.animationBox_MouseDown);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.generalStatsTable);
            this.tabPage3.Controls.Add(this.pieChartBagsSecurity);
            this.tabPage3.Location = new System.Drawing.Point(4, 27);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1296, 762);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "General Statistics Overview";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // generalStatsTable
            // 
            this.generalStatsTable.AllowUserToAddRows = false;
            this.generalStatsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.generalStatsTable.Location = new System.Drawing.Point(23, 16);
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
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Size = new System.Drawing.Size(1296, 762);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1710, 809);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "ProCp";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.gb1.ResumeLayout(false);
            this.gbSettings.ResumeLayout(false);
            this.gbSettings.PerformLayout();
            this.gbFlightInfo.ResumeLayout(false);
            this.gbFlightInfo.PerformLayout();
            this.gbBuild.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.animationBox)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.generalStatsTable)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

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
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label labelNoOfBags;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.ComboBox cmbCheckInDesk;
        private System.Windows.Forms.Label labelCheckInDesk;
        private System.Windows.Forms.ComboBox cmbDropOffPoint;
        private System.Windows.Forms.Label labelDropOffPoint;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ListBox AvailableFlights;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnStart;
        private LiveCharts.WinForms.CartesianChart cartesianChart1;
        private LiveCharts.WinForms.CartesianChart PrimarySecurityChart;
        private System.Windows.Forms.TabPage tabPage3;
        private LiveCharts.WinForms.PieChart pieChartBagsSecurity;
        private System.Windows.Forms.DataGridView generalStatsTable;
        private System.Windows.Forms.GroupBox gb1;
        private System.Windows.Forms.PictureBox animationBox;
    }
}

