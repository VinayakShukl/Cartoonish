namespace Cartoonish
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.loadBtn = new System.Windows.Forms.Button();
            this.colorBtn = new System.Windows.Forms.Button();
            this.resetBtn = new System.Windows.Forms.Button();
            this.error = new System.Windows.Forms.ErrorProvider(this.components);
            this.edgebtn = new System.Windows.Forms.Button();
            this.runBtn = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Colour = new System.Windows.Forms.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.iterationsBox = new System.Windows.Forms.GroupBox();
            this.iterHigh = new System.Windows.Forms.RadioButton();
            this.iterMed = new System.Windows.Forms.RadioButton();
            this.iterLow = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.kernelBox = new System.Windows.Forms.GroupBox();
            this.kernelHigh = new System.Windows.Forms.RadioButton();
            this.kernelMed = new System.Windows.Forms.RadioButton();
            this.kernelLow = new System.Windows.Forms.RadioButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.scaleFactor = new System.Windows.Forms.TrackBar();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel6 = new System.Windows.Forms.Panel();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.edgeAmountHigh = new System.Windows.Forms.RadioButton();
            this.edgeAmountMed = new System.Windows.Forms.RadioButton();
            this.edgeAmountLow = new System.Windows.Forms.RadioButton();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.radioButton28 = new System.Windows.Forms.RadioButton();
            this.radioButton29 = new System.Windows.Forms.RadioButton();
            this.radioButton30 = new System.Windows.Forms.RadioButton();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.edgeThicknessHigh = new System.Windows.Forms.RadioButton();
            this.edgeThicknessMed = new System.Windows.Forms.RadioButton();
            this.edgeThicknessLow = new System.Windows.Forms.RadioButton();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.radioButton34 = new System.Windows.Forms.RadioButton();
            this.radioButton35 = new System.Windows.Forms.RadioButton();
            this.radioButton36 = new System.Windows.Forms.RadioButton();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.imageWorker = new System.ComponentModel.BackgroundWorker();
            this.videoWorker2 = new System.ComponentModel.BackgroundWorker();
            this.stopButton = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.histogramWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.error)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.Colour.SuspendLayout();
            this.panel5.SuspendLayout();
            this.iterationsBox.SuspendLayout();
            this.kernelBox.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scaleFactor)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox.Location = new System.Drawing.Point(12, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(600, 500);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // loadBtn
            // 
            this.loadBtn.Location = new System.Drawing.Point(842, 34);
            this.loadBtn.Name = "loadBtn";
            this.loadBtn.Size = new System.Drawing.Size(132, 31);
            this.loadBtn.TabIndex = 1;
            this.loadBtn.Text = "Load Image/Video";
            this.loadBtn.UseVisualStyleBackColor = true;
            this.loadBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // colorBtn
            // 
            this.colorBtn.Location = new System.Drawing.Point(842, 151);
            this.colorBtn.Name = "colorBtn";
            this.colorBtn.Size = new System.Drawing.Size(60, 23);
            this.colorBtn.TabIndex = 2;
            this.colorBtn.Text = "Colors";
            this.colorBtn.UseVisualStyleBackColor = true;
            this.colorBtn.Click += new System.EventHandler(this.colorBtn_Click);
            // 
            // resetBtn
            // 
            this.resetBtn.Location = new System.Drawing.Point(842, 247);
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(132, 35);
            this.resetBtn.TabIndex = 3;
            this.resetBtn.Text = "Reset";
            this.resetBtn.UseVisualStyleBackColor = true;
            this.resetBtn.Click += new System.EventHandler(this.resetBtn_Click);
            // 
            // error
            // 
            this.error.ContainerControl = this;
            // 
            // edgebtn
            // 
            this.edgebtn.Location = new System.Drawing.Point(908, 151);
            this.edgebtn.Name = "edgebtn";
            this.edgebtn.Size = new System.Drawing.Size(66, 23);
            this.edgebtn.TabIndex = 4;
            this.edgebtn.Text = "Edges";
            this.edgebtn.UseVisualStyleBackColor = true;
            this.edgebtn.Click += new System.EventHandler(this.edgebtn_Click);
            // 
            // runBtn
            // 
            this.runBtn.Location = new System.Drawing.Point(842, 97);
            this.runBtn.Name = "runBtn";
            this.runBtn.Size = new System.Drawing.Size(132, 48);
            this.runBtn.TabIndex = 5;
            this.runBtn.Text = "Run!";
            this.runBtn.UseVisualStyleBackColor = true;
            this.runBtn.Click += new System.EventHandler(this.runBtn_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Colour);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(618, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(218, 270);
            this.tabControl1.TabIndex = 10;
            // 
            // Colour
            // 
            this.Colour.BackColor = System.Drawing.SystemColors.Control;
            this.Colour.Controls.Add(this.panel5);
            this.Colour.Controls.Add(this.panel4);
            this.Colour.Location = new System.Drawing.Point(4, 22);
            this.Colour.Name = "Colour";
            this.Colour.Padding = new System.Windows.Forms.Padding(3);
            this.Colour.Size = new System.Drawing.Size(210, 244);
            this.Colour.TabIndex = 0;
            this.Colour.Text = "Colors";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.iterationsBox);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Controls.Add(this.kernelBox);
            this.panel5.Location = new System.Drawing.Point(6, 90);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(199, 148);
            this.panel5.TabIndex = 12;
            // 
            // iterationsBox
            // 
            this.iterationsBox.Controls.Add(this.iterHigh);
            this.iterationsBox.Controls.Add(this.iterMed);
            this.iterationsBox.Controls.Add(this.iterLow);
            this.iterationsBox.Location = new System.Drawing.Point(7, 89);
            this.iterationsBox.Name = "iterationsBox";
            this.iterationsBox.Size = new System.Drawing.Size(185, 43);
            this.iterationsBox.TabIndex = 11;
            this.iterationsBox.TabStop = false;
            this.iterationsBox.Text = "Iterations";
            // 
            // iterHigh
            // 
            this.iterHigh.AutoSize = true;
            this.iterHigh.Location = new System.Drawing.Point(131, 18);
            this.iterHigh.Name = "iterHigh";
            this.iterHigh.Size = new System.Drawing.Size(51, 17);
            this.iterHigh.TabIndex = 10;
            this.iterHigh.Text = "Many";
            this.iterHigh.UseVisualStyleBackColor = true;
            this.iterHigh.CheckedChanged += new System.EventHandler(this.iterHigh_CheckedChanged);
            // 
            // iterMed
            // 
            this.iterMed.AutoSize = true;
            this.iterMed.Checked = true;
            this.iterMed.Location = new System.Drawing.Point(61, 18);
            this.iterMed.Name = "iterMed";
            this.iterMed.Size = new System.Drawing.Size(52, 17);
            this.iterMed.TabIndex = 9;
            this.iterMed.TabStop = true;
            this.iterMed.Text = "Some";
            this.iterMed.UseVisualStyleBackColor = true;
            this.iterMed.CheckedChanged += new System.EventHandler(this.iterMed_CheckedChanged);
            // 
            // iterLow
            // 
            this.iterLow.AutoSize = true;
            this.iterLow.Location = new System.Drawing.Point(3, 18);
            this.iterLow.Name = "iterLow";
            this.iterLow.Size = new System.Drawing.Size(47, 17);
            this.iterLow.TabIndex = 8;
            this.iterLow.Text = "Less";
            this.iterLow.UseVisualStyleBackColor = true;
            this.iterLow.CheckedChanged += new System.EventHandler(this.iterLow_CheckedChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(59, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Bilateral Filtering";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // kernelBox
            // 
            this.kernelBox.Controls.Add(this.kernelHigh);
            this.kernelBox.Controls.Add(this.kernelMed);
            this.kernelBox.Controls.Add(this.kernelLow);
            this.kernelBox.Location = new System.Drawing.Point(7, 31);
            this.kernelBox.Name = "kernelBox";
            this.kernelBox.Size = new System.Drawing.Size(185, 43);
            this.kernelBox.TabIndex = 9;
            this.kernelBox.TabStop = false;
            this.kernelBox.Text = "Kernel Size";
            // 
            // kernelHigh
            // 
            this.kernelHigh.AutoSize = true;
            this.kernelHigh.Location = new System.Drawing.Point(131, 18);
            this.kernelHigh.Name = "kernelHigh";
            this.kernelHigh.Size = new System.Drawing.Size(52, 17);
            this.kernelHigh.TabIndex = 10;
            this.kernelHigh.Text = "Large";
            this.kernelHigh.UseVisualStyleBackColor = true;
            this.kernelHigh.CheckedChanged += new System.EventHandler(this.kernelHigh_CheckedChanged);
            // 
            // kernelMed
            // 
            this.kernelMed.AutoSize = true;
            this.kernelMed.Checked = true;
            this.kernelMed.Location = new System.Drawing.Point(61, 18);
            this.kernelMed.Name = "kernelMed";
            this.kernelMed.Size = new System.Drawing.Size(62, 17);
            this.kernelMed.TabIndex = 9;
            this.kernelMed.TabStop = true;
            this.kernelMed.Text = "Medium";
            this.kernelMed.UseVisualStyleBackColor = true;
            this.kernelMed.CheckedChanged += new System.EventHandler(this.kernelMed_CheckedChanged);
            // 
            // kernelLow
            // 
            this.kernelLow.AutoSize = true;
            this.kernelLow.Location = new System.Drawing.Point(3, 18);
            this.kernelLow.Name = "kernelLow";
            this.kernelLow.Size = new System.Drawing.Size(50, 17);
            this.kernelLow.TabIndex = 8;
            this.kernelLow.Text = "Small";
            this.kernelLow.UseVisualStyleBackColor = true;
            this.kernelLow.CheckedChanged += new System.EventHandler(this.kernelLow_CheckedChanged);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.scaleFactor);
            this.panel4.Location = new System.Drawing.Point(6, 16);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(199, 68);
            this.panel4.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Scale Factor";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Low";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(167, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "High";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // scaleFactor
            // 
            this.scaleFactor.LargeChange = 1;
            this.scaleFactor.Location = new System.Drawing.Point(3, 21);
            this.scaleFactor.Maximum = 3;
            this.scaleFactor.Minimum = 1;
            this.scaleFactor.Name = "scaleFactor";
            this.scaleFactor.Size = new System.Drawing.Size(193, 45);
            this.scaleFactor.TabIndex = 1;
            this.scaleFactor.Value = 2;
            this.scaleFactor.ValueChanged += new System.EventHandler(this.scaleFactor_ValueChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.panel6);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(210, 244);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Edges";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.groupBox10);
            this.panel6.Controls.Add(this.groupBox11);
            this.panel6.Controls.Add(this.groupBox12);
            this.panel6.Controls.Add(this.groupBox13);
            this.panel6.Location = new System.Drawing.Point(6, 6);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(199, 103);
            this.panel6.TabIndex = 12;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.edgeAmountHigh);
            this.groupBox10.Controls.Add(this.edgeAmountMed);
            this.groupBox10.Controls.Add(this.edgeAmountLow);
            this.groupBox10.Location = new System.Drawing.Point(7, 8);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(185, 43);
            this.groupBox10.TabIndex = 11;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Amount";
            // 
            // edgeAmountHigh
            // 
            this.edgeAmountHigh.AutoSize = true;
            this.edgeAmountHigh.Location = new System.Drawing.Point(131, 18);
            this.edgeAmountHigh.Name = "edgeAmountHigh";
            this.edgeAmountHigh.Size = new System.Drawing.Size(51, 17);
            this.edgeAmountHigh.TabIndex = 10;
            this.edgeAmountHigh.Text = "Many";
            this.edgeAmountHigh.UseVisualStyleBackColor = true;
            this.edgeAmountHigh.CheckedChanged += new System.EventHandler(this.edgeAmountHigh_CheckedChanged);
            // 
            // edgeAmountMed
            // 
            this.edgeAmountMed.AutoSize = true;
            this.edgeAmountMed.Checked = true;
            this.edgeAmountMed.Location = new System.Drawing.Point(61, 18);
            this.edgeAmountMed.Name = "edgeAmountMed";
            this.edgeAmountMed.Size = new System.Drawing.Size(52, 17);
            this.edgeAmountMed.TabIndex = 9;
            this.edgeAmountMed.TabStop = true;
            this.edgeAmountMed.Text = "Some";
            this.edgeAmountMed.UseVisualStyleBackColor = true;
            this.edgeAmountMed.CheckedChanged += new System.EventHandler(this.edgeAmountMed_CheckedChanged);
            // 
            // edgeAmountLow
            // 
            this.edgeAmountLow.AutoSize = true;
            this.edgeAmountLow.Location = new System.Drawing.Point(3, 18);
            this.edgeAmountLow.Name = "edgeAmountLow";
            this.edgeAmountLow.Size = new System.Drawing.Size(47, 17);
            this.edgeAmountLow.TabIndex = 8;
            this.edgeAmountLow.Text = "Less";
            this.edgeAmountLow.UseVisualStyleBackColor = true;
            this.edgeAmountLow.CheckedChanged += new System.EventHandler(this.edgeAmountLow_CheckedChanged);
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.radioButton28);
            this.groupBox11.Controls.Add(this.radioButton29);
            this.groupBox11.Controls.Add(this.radioButton30);
            this.groupBox11.Location = new System.Drawing.Point(7, 8);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(185, 43);
            this.groupBox11.TabIndex = 11;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Amount";
            // 
            // radioButton28
            // 
            this.radioButton28.AutoSize = true;
            this.radioButton28.Location = new System.Drawing.Point(131, 18);
            this.radioButton28.Name = "radioButton28";
            this.radioButton28.Size = new System.Drawing.Size(51, 17);
            this.radioButton28.TabIndex = 10;
            this.radioButton28.Text = "Many";
            this.radioButton28.UseVisualStyleBackColor = true;
            // 
            // radioButton29
            // 
            this.radioButton29.AutoSize = true;
            this.radioButton29.Checked = true;
            this.radioButton29.Location = new System.Drawing.Point(61, 18);
            this.radioButton29.Name = "radioButton29";
            this.radioButton29.Size = new System.Drawing.Size(52, 17);
            this.radioButton29.TabIndex = 9;
            this.radioButton29.TabStop = true;
            this.radioButton29.Text = "Some";
            this.radioButton29.UseVisualStyleBackColor = true;
            // 
            // radioButton30
            // 
            this.radioButton30.AutoSize = true;
            this.radioButton30.Location = new System.Drawing.Point(3, 18);
            this.radioButton30.Name = "radioButton30";
            this.radioButton30.Size = new System.Drawing.Size(47, 17);
            this.radioButton30.TabIndex = 8;
            this.radioButton30.Text = "Less";
            this.radioButton30.UseVisualStyleBackColor = true;
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.edgeThicknessHigh);
            this.groupBox12.Controls.Add(this.edgeThicknessMed);
            this.groupBox12.Controls.Add(this.edgeThicknessLow);
            this.groupBox12.Location = new System.Drawing.Point(7, 57);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(185, 43);
            this.groupBox12.TabIndex = 9;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Thickness";
            // 
            // edgeThicknessHigh
            // 
            this.edgeThicknessHigh.AutoSize = true;
            this.edgeThicknessHigh.Location = new System.Drawing.Point(131, 18);
            this.edgeThicknessHigh.Name = "edgeThicknessHigh";
            this.edgeThicknessHigh.Size = new System.Drawing.Size(52, 17);
            this.edgeThicknessHigh.TabIndex = 10;
            this.edgeThicknessHigh.Text = "Thick";
            this.edgeThicknessHigh.UseVisualStyleBackColor = true;
            this.edgeThicknessHigh.CheckedChanged += new System.EventHandler(this.edgeThicknessHigh_CheckedChanged);
            // 
            // edgeThicknessMed
            // 
            this.edgeThicknessMed.AutoSize = true;
            this.edgeThicknessMed.Checked = true;
            this.edgeThicknessMed.Location = new System.Drawing.Point(61, 18);
            this.edgeThicknessMed.Name = "edgeThicknessMed";
            this.edgeThicknessMed.Size = new System.Drawing.Size(58, 17);
            this.edgeThicknessMed.TabIndex = 9;
            this.edgeThicknessMed.TabStop = true;
            this.edgeThicknessMed.Text = "Normal";
            this.edgeThicknessMed.UseVisualStyleBackColor = true;
            this.edgeThicknessMed.CheckedChanged += new System.EventHandler(this.edgeThicknessMed_CheckedChanged);
            // 
            // edgeThicknessLow
            // 
            this.edgeThicknessLow.AutoSize = true;
            this.edgeThicknessLow.Location = new System.Drawing.Point(3, 18);
            this.edgeThicknessLow.Name = "edgeThicknessLow";
            this.edgeThicknessLow.Size = new System.Drawing.Size(46, 17);
            this.edgeThicknessLow.TabIndex = 8;
            this.edgeThicknessLow.Text = "Thin";
            this.edgeThicknessLow.UseVisualStyleBackColor = true;
            this.edgeThicknessLow.CheckedChanged += new System.EventHandler(this.edgeThicknessLow_CheckedChanged);
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.radioButton34);
            this.groupBox13.Controls.Add(this.radioButton35);
            this.groupBox13.Controls.Add(this.radioButton36);
            this.groupBox13.Location = new System.Drawing.Point(7, 57);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(185, 43);
            this.groupBox13.TabIndex = 9;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Thickness";
            // 
            // radioButton34
            // 
            this.radioButton34.AutoSize = true;
            this.radioButton34.Location = new System.Drawing.Point(131, 18);
            this.radioButton34.Name = "radioButton34";
            this.radioButton34.Size = new System.Drawing.Size(52, 17);
            this.radioButton34.TabIndex = 10;
            this.radioButton34.Text = "Thick";
            this.radioButton34.UseVisualStyleBackColor = true;
            // 
            // radioButton35
            // 
            this.radioButton35.AutoSize = true;
            this.radioButton35.Checked = true;
            this.radioButton35.Location = new System.Drawing.Point(61, 18);
            this.radioButton35.Name = "radioButton35";
            this.radioButton35.Size = new System.Drawing.Size(58, 17);
            this.radioButton35.TabIndex = 9;
            this.radioButton35.TabStop = true;
            this.radioButton35.Text = "Normal";
            this.radioButton35.UseVisualStyleBackColor = true;
            // 
            // radioButton36
            // 
            this.radioButton36.AutoSize = true;
            this.radioButton36.Location = new System.Drawing.Point(3, 18);
            this.radioButton36.Name = "radioButton36";
            this.radioButton36.Size = new System.Drawing.Size(46, 17);
            this.radioButton36.TabIndex = 8;
            this.radioButton36.Text = "Thin";
            this.radioButton36.UseVisualStyleBackColor = true;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(618, 290);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(356, 21);
            this.progressBar.TabIndex = 11;
            // 
            // imageWorker
            // 
            this.imageWorker.WorkerReportsProgress = true;
            this.imageWorker.WorkerSupportsCancellation = true;
            this.imageWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.imageWorker_DoWork);
            this.imageWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.imageWorker_ProgressChanged);
            this.imageWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.imageWorker_RunWorkerCompleted);
            // 
            // videoWorker2
            // 
            this.videoWorker2.WorkerReportsProgress = true;
            this.videoWorker2.WorkerSupportsCancellation = true;
            this.videoWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.videoWorker2_DoWork);
            this.videoWorker2.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.videoWorker2_ProgressChanged);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(842, 206);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(132, 35);
            this.stopButton.TabIndex = 12;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chart1.BackColor = System.Drawing.Color.Transparent;
            this.chart1.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Center;
            this.chart1.BackImageTransparentColor = System.Drawing.Color.Transparent;
            this.chart1.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Location = new System.Drawing.Point(618, 315);
            this.chart1.Margin = new System.Windows.Forms.Padding(0);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            this.chart1.Size = new System.Drawing.Size(356, 204);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            this.chart1.Visible = false;
            // 
            // histogramWorker
            // 
            this.histogramWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.histogramWorker_DoWork);
            this.histogramWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.histogramWorker_RunWorkerCompleted);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 521);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.runBtn);
            this.Controls.Add(this.edgebtn);
            this.Controls.Add(this.resetBtn);
            this.Controls.Add(this.colorBtn);
            this.Controls.Add(this.loadBtn);
            this.Controls.Add(this.pictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Opacity = 0.95D;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.error)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.Colour.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.iterationsBox.ResumeLayout(false);
            this.iterationsBox.PerformLayout();
            this.kernelBox.ResumeLayout(false);
            this.kernelBox.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scaleFactor)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button loadBtn;
        private System.Windows.Forms.Button colorBtn;
        private System.Windows.Forms.Button resetBtn;
        private System.Windows.Forms.ErrorProvider error;
        private System.Windows.Forms.Button edgebtn;
        private System.Windows.Forms.Button runBtn;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Colour;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar scaleFactor;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.GroupBox iterationsBox;
        private System.Windows.Forms.RadioButton iterHigh;
        private System.Windows.Forms.RadioButton iterMed;
        private System.Windows.Forms.RadioButton iterLow;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox kernelBox;
        private System.Windows.Forms.RadioButton kernelHigh;
        private System.Windows.Forms.RadioButton kernelMed;
        private System.Windows.Forms.RadioButton kernelLow;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.RadioButton edgeAmountHigh;
        private System.Windows.Forms.RadioButton edgeAmountMed;
        private System.Windows.Forms.RadioButton edgeAmountLow;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.RadioButton radioButton28;
        private System.Windows.Forms.RadioButton radioButton29;
        private System.Windows.Forms.RadioButton radioButton30;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.RadioButton edgeThicknessHigh;
        private System.Windows.Forms.RadioButton edgeThicknessMed;
        private System.Windows.Forms.RadioButton edgeThicknessLow;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.RadioButton radioButton34;
        private System.Windows.Forms.RadioButton radioButton35;
        private System.Windows.Forms.RadioButton radioButton36;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.ComponentModel.BackgroundWorker imageWorker;
        private System.ComponentModel.BackgroundWorker videoWorker2;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.ComponentModel.BackgroundWorker histogramWorker;
    }
}

