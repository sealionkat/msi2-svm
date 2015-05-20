namespace MiniSVM.SpamClassifier
{
    partial class SpamClassifier
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="dispoFsing">true if managed resources should be disposed; otherwise, false.</param>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpamClassifier));
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonReset = new System.Windows.Forms.Button();
            this.checkBoxRecursive = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxKernelType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonShowUseless = new System.Windows.Forms.Button();
            this.buttonLoadUseless = new System.Windows.Forms.Button();
            this.buttonClearUseless = new System.Windows.Forms.Button();
            this.tabLearning = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridViewSpam = new System.Windows.Forms.DataGridView();
            this.Word = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonLoadSpam = new System.Windows.Forms.Button();
            this.labelSpam = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dataGridViewHam = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel5 = new System.Windows.Forms.Panel();
            this.labelHam = new System.Windows.Forms.Label();
            this.buttonLoadHam = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonAutoselectFeatures = new System.Windows.Forms.Button();
            this.buttonTrain = new System.Windows.Forms.Button();
            this.buttonClearFeatures = new System.Windows.Forms.Button();
            this.buttonAddFromSelection = new System.Windows.Forms.Button();
            this.labelSelectedFeaturesCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabClassifying = new System.Windows.Forms.TabPage();
            this.buttonClearTxt = new System.Windows.Forms.Button();
            this.labelClassificationResult = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonClassifyTxt = new System.Windows.Forms.Button();
            this.richTextBoxEmail = new System.Windows.Forms.RichTextBox();
            this.buttonLoadEmail = new System.Windows.Forms.Button();
            this.buttonSaveModel = new System.Windows.Forms.Button();
            this.buttonLoadModel = new System.Windows.Forms.Button();
            this.trackBarTest = new MiniSVM.SpamClassifier.TransparentTrackBar();
            this.numericTestPercent = new MiniSVM.SpamClassifier.NumericTextBox();
            this.numericGamma = new MiniSVM.SpamClassifier.NumericTextBox();
            this.numericCost = new MiniSVM.SpamClassifier.NumericTextBox();
            this.numericHamFeatures = new MiniSVM.SpamClassifier.NumericTextBox();
            this.numericSpamFeatures = new MiniSVM.SpamClassifier.NumericTextBox();
            this.tabControlMain.SuspendLayout();
            this.tabSettings.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabLearning.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSpam)).BeginInit();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHam)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabClassifying.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTest)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabSettings);
            this.tabControlMain.Controls.Add(this.tabLearning);
            this.tabControlMain.Controls.Add(this.tabClassifying);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(981, 440);
            this.tabControlMain.TabIndex = 1;
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.groupBox4);
            this.tabSettings.Controls.Add(this.groupBox1);
            this.tabSettings.Location = new System.Drawing.Point(4, 22);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Size = new System.Drawing.Size(973, 414);
            this.tabSettings.TabIndex = 2;
            this.tabSettings.Text = "Settings";
            this.tabSettings.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.trackBarTest);
            this.groupBox4.Controls.Add(this.numericTestPercent);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.numericGamma);
            this.groupBox4.Controls.Add(this.numericCost);
            this.groupBox4.Controls.Add(this.buttonReset);
            this.groupBox4.Controls.Add(this.checkBoxRecursive);
            this.groupBox4.Controls.Add(this.numericHamFeatures);
            this.groupBox4.Controls.Add(this.numericSpamFeatures);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.comboBoxKernelType);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Location = new System.Drawing.Point(8, 133);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(298, 272);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Training";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 197);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Test set percent:";
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(187, 240);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(100, 23);
            this.buttonReset.TabIndex = 8;
            this.buttonReset.Text = "Reset training set";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // checkBoxRecursive
            // 
            this.checkBoxRecursive.AutoSize = true;
            this.checkBoxRecursive.Location = new System.Drawing.Point(22, 244);
            this.checkBoxRecursive.Name = "checkBoxRecursive";
            this.checkBoxRecursive.Size = new System.Drawing.Size(159, 17);
            this.checkBoxRecursive.TabIndex = 7;
            this.checkBoxRecursive.Text = "Read training set recursively";
            this.checkBoxRecursive.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(70, 148);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(170, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Autoselect ham features threshold:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(65, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(175, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Autoselect spam features threshold:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(209, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Cost:";
            // 
            // comboBoxKernelType
            // 
            this.comboBoxKernelType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxKernelType.FormattingEnabled = true;
            this.comboBoxKernelType.Items.AddRange(new object[] {
            "Linear",
            "Gaussian"});
            this.comboBoxKernelType.Location = new System.Drawing.Point(187, 18);
            this.comboBoxKernelType.Name = "comboBoxKernelType";
            this.comboBoxKernelType.Size = new System.Drawing.Size(100, 21);
            this.comboBoxKernelType.TabIndex = 0;
            this.comboBoxKernelType.SelectedIndexChanged += new System.EventHandler(this.comboBoxKernelType_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(194, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Gamma:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(118, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Kernel type:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonShowUseless);
            this.groupBox1.Controls.Add(this.buttonLoadUseless);
            this.groupBox1.Controls.Add(this.buttonClearUseless);
            this.groupBox1.Location = new System.Drawing.Point(8, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(298, 114);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Useless words";
            // 
            // buttonShowUseless
            // 
            this.buttonShowUseless.Location = new System.Drawing.Point(6, 23);
            this.buttonShowUseless.Name = "buttonShowUseless";
            this.buttonShowUseless.Size = new System.Drawing.Size(159, 23);
            this.buttonShowUseless.TabIndex = 0;
            this.buttonShowUseless.Text = "Show useless words list";
            this.buttonShowUseless.UseVisualStyleBackColor = true;
            this.buttonShowUseless.Click += new System.EventHandler(this.buttonShowUseless_Click);
            // 
            // buttonLoadUseless
            // 
            this.buttonLoadUseless.Location = new System.Drawing.Point(6, 52);
            this.buttonLoadUseless.Name = "buttonLoadUseless";
            this.buttonLoadUseless.Size = new System.Drawing.Size(159, 23);
            this.buttonLoadUseless.TabIndex = 1;
            this.buttonLoadUseless.Text = "Load useless words list";
            this.buttonLoadUseless.UseVisualStyleBackColor = true;
            this.buttonLoadUseless.Click += new System.EventHandler(this.buttonLoadUseless_Click);
            // 
            // buttonClearUseless
            // 
            this.buttonClearUseless.Location = new System.Drawing.Point(6, 81);
            this.buttonClearUseless.Name = "buttonClearUseless";
            this.buttonClearUseless.Size = new System.Drawing.Size(159, 23);
            this.buttonClearUseless.TabIndex = 2;
            this.buttonClearUseless.Text = "Clear useless words list";
            this.buttonClearUseless.UseVisualStyleBackColor = true;
            this.buttonClearUseless.Click += new System.EventHandler(this.buttonClearUseless_Click);
            // 
            // tabLearning
            // 
            this.tabLearning.Controls.Add(this.tableLayoutPanel);
            this.tabLearning.Location = new System.Drawing.Point(4, 22);
            this.tabLearning.Name = "tabLearning";
            this.tabLearning.Padding = new System.Windows.Forms.Padding(3);
            this.tabLearning.Size = new System.Drawing.Size(973, 414);
            this.tabLearning.TabIndex = 0;
            this.tabLearning.Text = "Learning";
            this.tabLearning.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 82.62668F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.37332F));
            this.tableLayoutPanel.Controls.Add(this.splitContainer1, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(967, 408);
            this.tableLayoutPanel.TabIndex = 9;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer1.Size = new System.Drawing.Size(792, 402);
            this.splitContainer1.SplitterDistance = 390;
            this.splitContainer1.SplitterWidth = 10;
            this.splitContainer1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.42786F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.57214F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(390, 402);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridViewSpam);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 60);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(384, 339);
            this.panel3.TabIndex = 1;
            // 
            // dataGridViewSpam
            // 
            this.dataGridViewSpam.AllowUserToAddRows = false;
            this.dataGridViewSpam.AllowUserToDeleteRows = false;
            this.dataGridViewSpam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSpam.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Word,
            this.Count});
            this.dataGridViewSpam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSpam.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewSpam.Name = "dataGridViewSpam";
            this.dataGridViewSpam.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSpam.Size = new System.Drawing.Size(384, 339);
            this.dataGridViewSpam.TabIndex = 1;
            this.dataGridViewSpam.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSpam_CellContentClick);
            // 
            // Word
            // 
            this.Word.HeaderText = "Word";
            this.Word.Name = "Word";
            this.Word.ReadOnly = true;
            // 
            // Count
            // 
            this.Count.HeaderText = "Count";
            this.Count.Name = "Count";
            this.Count.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonLoadSpam);
            this.panel2.Controls.Add(this.labelSpam);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(384, 51);
            this.panel2.TabIndex = 0;
            // 
            // buttonLoadSpam
            // 
            this.buttonLoadSpam.Location = new System.Drawing.Point(0, 24);
            this.buttonLoadSpam.Name = "buttonLoadSpam";
            this.buttonLoadSpam.Size = new System.Drawing.Size(137, 23);
            this.buttonLoadSpam.TabIndex = 1;
            this.buttonLoadSpam.Text = "Load set from directory";
            this.buttonLoadSpam.UseVisualStyleBackColor = true;
            this.buttonLoadSpam.Click += new System.EventHandler(this.buttonLoadSpam_Click);
            // 
            // labelSpam
            // 
            this.labelSpam.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelSpam.Location = new System.Drawing.Point(0, 0);
            this.labelSpam.Name = "labelSpam";
            this.labelSpam.Size = new System.Drawing.Size(384, 23);
            this.labelSpam.TabIndex = 0;
            this.labelSpam.Text = "SPAM";
            this.labelSpam.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.panel4, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.panel5, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.42786F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.57214F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(392, 402);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dataGridViewHam);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 60);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(386, 339);
            this.panel4.TabIndex = 1;
            // 
            // dataGridViewHam
            // 
            this.dataGridViewHam.AllowUserToAddRows = false;
            this.dataGridViewHam.AllowUserToDeleteRows = false;
            this.dataGridViewHam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHam.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dataGridViewHam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewHam.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewHam.Name = "dataGridViewHam";
            this.dataGridViewHam.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewHam.Size = new System.Drawing.Size(386, 339);
            this.dataGridViewHam.TabIndex = 3;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Word";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Count";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.labelHam);
            this.panel5.Controls.Add(this.buttonLoadHam);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(386, 51);
            this.panel5.TabIndex = 0;
            // 
            // labelHam
            // 
            this.labelHam.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelHam.Location = new System.Drawing.Point(0, 0);
            this.labelHam.Name = "labelHam";
            this.labelHam.Size = new System.Drawing.Size(386, 23);
            this.labelHam.TabIndex = 1;
            this.labelHam.Text = "HAM";
            this.labelHam.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonLoadHam
            // 
            this.buttonLoadHam.Location = new System.Drawing.Point(0, 24);
            this.buttonLoadHam.Name = "buttonLoadHam";
            this.buttonLoadHam.Size = new System.Drawing.Size(137, 23);
            this.buttonLoadHam.TabIndex = 2;
            this.buttonLoadHam.Text = "Load set from directory";
            this.buttonLoadHam.UseVisualStyleBackColor = true;
            this.buttonLoadHam.Click += new System.EventHandler(this.buttonLoadHam_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonLoadModel);
            this.panel1.Controls.Add(this.buttonSaveModel);
            this.panel1.Controls.Add(this.buttonAutoselectFeatures);
            this.panel1.Controls.Add(this.buttonTrain);
            this.panel1.Controls.Add(this.buttonClearFeatures);
            this.panel1.Controls.Add(this.buttonAddFromSelection);
            this.panel1.Controls.Add(this.labelSelectedFeaturesCount);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(801, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(163, 402);
            this.panel1.TabIndex = 1;
            // 
            // buttonAutoselectFeatures
            // 
            this.buttonAutoselectFeatures.Location = new System.Drawing.Point(7, 55);
            this.buttonAutoselectFeatures.Name = "buttonAutoselectFeatures";
            this.buttonAutoselectFeatures.Size = new System.Drawing.Size(153, 23);
            this.buttonAutoselectFeatures.TabIndex = 5;
            this.buttonAutoselectFeatures.Text = "Autoselect features";
            this.buttonAutoselectFeatures.UseVisualStyleBackColor = true;
            this.buttonAutoselectFeatures.Click += new System.EventHandler(this.buttonAutoselectFeatures_Click);
            // 
            // buttonTrain
            // 
            this.buttonTrain.Location = new System.Drawing.Point(7, 110);
            this.buttonTrain.Name = "buttonTrain";
            this.buttonTrain.Size = new System.Drawing.Size(153, 23);
            this.buttonTrain.TabIndex = 4;
            this.buttonTrain.Text = "Train Model";
            this.buttonTrain.UseVisualStyleBackColor = true;
            this.buttonTrain.Click += new System.EventHandler(this.buttonTrain_Click);
            // 
            // buttonClearFeatures
            // 
            this.buttonClearFeatures.Location = new System.Drawing.Point(7, 83);
            this.buttonClearFeatures.Name = "buttonClearFeatures";
            this.buttonClearFeatures.Size = new System.Drawing.Size(153, 21);
            this.buttonClearFeatures.TabIndex = 3;
            this.buttonClearFeatures.Text = "Clear features";
            this.buttonClearFeatures.UseVisualStyleBackColor = true;
            this.buttonClearFeatures.Click += new System.EventHandler(this.buttonClearFeatures_Click);
            // 
            // buttonAddFromSelection
            // 
            this.buttonAddFromSelection.Location = new System.Drawing.Point(7, 26);
            this.buttonAddFromSelection.Name = "buttonAddFromSelection";
            this.buttonAddFromSelection.Size = new System.Drawing.Size(153, 23);
            this.buttonAddFromSelection.TabIndex = 2;
            this.buttonAddFromSelection.Text = "Add from selection";
            this.buttonAddFromSelection.UseVisualStyleBackColor = true;
            this.buttonAddFromSelection.Click += new System.EventHandler(this.buttonAddFromSelection_Click);
            // 
            // labelSelectedFeaturesCount
            // 
            this.labelSelectedFeaturesCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSelectedFeaturesCount.Location = new System.Drawing.Point(95, 9);
            this.labelSelectedFeaturesCount.Name = "labelSelectedFeaturesCount";
            this.labelSelectedFeaturesCount.Size = new System.Drawing.Size(65, 13);
            this.labelSelectedFeaturesCount.TabIndex = 1;
            this.labelSelectedFeaturesCount.Text = "NA";
            this.labelSelectedFeaturesCount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Selected features:";
            // 
            // tabClassifying
            // 
            this.tabClassifying.Controls.Add(this.buttonClearTxt);
            this.tabClassifying.Controls.Add(this.labelClassificationResult);
            this.tabClassifying.Controls.Add(this.label2);
            this.tabClassifying.Controls.Add(this.buttonClassifyTxt);
            this.tabClassifying.Controls.Add(this.richTextBoxEmail);
            this.tabClassifying.Controls.Add(this.buttonLoadEmail);
            this.tabClassifying.Location = new System.Drawing.Point(4, 22);
            this.tabClassifying.Name = "tabClassifying";
            this.tabClassifying.Padding = new System.Windows.Forms.Padding(3);
            this.tabClassifying.Size = new System.Drawing.Size(973, 414);
            this.tabClassifying.TabIndex = 1;
            this.tabClassifying.Text = "Classifying";
            this.tabClassifying.UseVisualStyleBackColor = true;
            // 
            // buttonClearTxt
            // 
            this.buttonClearTxt.Location = new System.Drawing.Point(98, 16);
            this.buttonClearTxt.Name = "buttonClearTxt";
            this.buttonClearTxt.Size = new System.Drawing.Size(76, 23);
            this.buttonClearTxt.TabIndex = 5;
            this.buttonClearTxt.Text = "Clear";
            this.buttonClearTxt.UseVisualStyleBackColor = true;
            this.buttonClearTxt.Click += new System.EventHandler(this.buttonClearTxt_Click);
            // 
            // labelClassificationResult
            // 
            this.labelClassificationResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelClassificationResult.AutoSize = true;
            this.labelClassificationResult.Location = new System.Drawing.Point(206, 356);
            this.labelClassificationResult.Name = "labelClassificationResult";
            this.labelClassificationResult.Size = new System.Drawing.Size(22, 13);
            this.labelClassificationResult.TabIndex = 4;
            this.labelClassificationResult.Text = "NA";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(98, 356);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Classification status:";
            // 
            // buttonClassifyTxt
            // 
            this.buttonClassifyTxt.Location = new System.Drawing.Point(17, 351);
            this.buttonClassifyTxt.Name = "buttonClassifyTxt";
            this.buttonClassifyTxt.Size = new System.Drawing.Size(75, 23);
            this.buttonClassifyTxt.TabIndex = 2;
            this.buttonClassifyTxt.Text = "Classify";
            this.buttonClassifyTxt.UseVisualStyleBackColor = true;
            this.buttonClassifyTxt.Click += new System.EventHandler(this.buttonClassifyTxt_Click);
            // 
            // richTextBoxEmail
            // 
            this.richTextBoxEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxEmail.Location = new System.Drawing.Point(17, 45);
            this.richTextBoxEmail.Name = "richTextBoxEmail";
            this.richTextBoxEmail.Size = new System.Drawing.Size(938, 300);
            this.richTextBoxEmail.TabIndex = 1;
            this.richTextBoxEmail.Text = "";
            this.richTextBoxEmail.TextChanged += new System.EventHandler(this.richTextBoxEmail_TextChanged);
            // 
            // buttonLoadEmail
            // 
            this.buttonLoadEmail.Location = new System.Drawing.Point(17, 16);
            this.buttonLoadEmail.Name = "buttonLoadEmail";
            this.buttonLoadEmail.Size = new System.Drawing.Size(75, 23);
            this.buttonLoadEmail.TabIndex = 0;
            this.buttonLoadEmail.Text = "Load e-mail";
            this.buttonLoadEmail.UseVisualStyleBackColor = true;
            this.buttonLoadEmail.Click += new System.EventHandler(this.buttonLoadEmail_Click);
            // 
            // buttonSaveModel
            // 
            this.buttonSaveModel.Location = new System.Drawing.Point(7, 151);
            this.buttonSaveModel.Name = "buttonSaveModel";
            this.buttonSaveModel.Size = new System.Drawing.Size(153, 23);
            this.buttonSaveModel.TabIndex = 6;
            this.buttonSaveModel.Text = "Save model";
            this.buttonSaveModel.UseVisualStyleBackColor = true;
            this.buttonSaveModel.Click += new System.EventHandler(this.buttonSaveModel_Click);
            // 
            // buttonLoadModel
            // 
            this.buttonLoadModel.Location = new System.Drawing.Point(7, 180);
            this.buttonLoadModel.Name = "buttonLoadModel";
            this.buttonLoadModel.Size = new System.Drawing.Size(153, 23);
            this.buttonLoadModel.TabIndex = 7;
            this.buttonLoadModel.Text = "Load model";
            this.buttonLoadModel.UseVisualStyleBackColor = true;
            this.buttonLoadModel.Click += new System.EventHandler(this.buttonLoadModel_Click);
            // 
            // trackBarTest
            // 
            this.trackBarTest.AutoSize = false;
            this.trackBarTest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.trackBarTest.Location = new System.Drawing.Point(99, 194);
            this.trackBarTest.Maximum = 50;
            this.trackBarTest.Name = "trackBarTest";
            this.trackBarTest.Size = new System.Drawing.Size(141, 16);
            this.trackBarTest.TabIndex = 5;
            this.trackBarTest.TickFrequency = 10;
            this.trackBarTest.Value = 20;
            this.trackBarTest.ValueChanged += new System.EventHandler(this.trackBarTest_ValueChanged);
            // 
            // numericTestPercent
            // 
            this.numericTestPercent.AllowSpace = false;
            this.numericTestPercent.Location = new System.Drawing.Point(246, 194);
            this.numericTestPercent.Name = "numericTestPercent";
            this.numericTestPercent.Size = new System.Drawing.Size(41, 20);
            this.numericTestPercent.TabIndex = 6;
            this.numericTestPercent.Text = "20";
            this.numericTestPercent.TextChanged += new System.EventHandler(this.numericTestPercent_TextChanged);
            // 
            // numericGamma
            // 
            this.numericGamma.AllowSpace = false;
            this.numericGamma.Location = new System.Drawing.Point(246, 45);
            this.numericGamma.Name = "numericGamma";
            this.numericGamma.Size = new System.Drawing.Size(41, 20);
            this.numericGamma.TabIndex = 1;
            this.numericGamma.Text = "1";
            // 
            // numericCost
            // 
            this.numericCost.AllowSpace = false;
            this.numericCost.Location = new System.Drawing.Point(246, 71);
            this.numericCost.Name = "numericCost";
            this.numericCost.Size = new System.Drawing.Size(41, 20);
            this.numericCost.TabIndex = 2;
            this.numericCost.Text = "1";
            // 
            // numericHamFeatures
            // 
            this.numericHamFeatures.AllowSpace = false;
            this.numericHamFeatures.Location = new System.Drawing.Point(246, 145);
            this.numericHamFeatures.Name = "numericHamFeatures";
            this.numericHamFeatures.Size = new System.Drawing.Size(41, 20);
            this.numericHamFeatures.TabIndex = 4;
            this.numericHamFeatures.Text = "10";
            // 
            // numericSpamFeatures
            // 
            this.numericSpamFeatures.AllowSpace = false;
            this.numericSpamFeatures.Location = new System.Drawing.Point(246, 119);
            this.numericSpamFeatures.Name = "numericSpamFeatures";
            this.numericSpamFeatures.Size = new System.Drawing.Size(41, 20);
            this.numericSpamFeatures.TabIndex = 3;
            this.numericSpamFeatures.Text = "20";
            // 
            // SpamClassifier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 440);
            this.Controls.Add(this.tabControlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SpamClassifier";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Spam classification";
            this.tabControlMain.ResumeLayout(false);
            this.tabSettings.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tabLearning.ResumeLayout(false);
            this.tableLayoutPanel.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSpam)).EndInit();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHam)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabClassifying.ResumeLayout(false);
            this.tabClassifying.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTest)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabLearning;
        private System.Windows.Forms.TabPage tabClassifying;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label labelSpam;
        private System.Windows.Forms.Label labelHam;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Button buttonClearUseless;
        private System.Windows.Forms.Button buttonShowUseless;
        private System.Windows.Forms.Button buttonLoadUseless;
        private System.Windows.Forms.Label labelClassificationResult;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonClassifyTxt;
        private System.Windows.Forms.RichTextBox richTextBoxEmail;
        private System.Windows.Forms.Button buttonLoadEmail;
        private System.Windows.Forms.Button buttonClearTxt;
        private System.Windows.Forms.Button buttonLoadSpam;
        private System.Windows.Forms.Button buttonLoadHam;
        private System.Windows.Forms.DataGridView dataGridViewSpam;
        private System.Windows.Forms.CheckBox checkBoxRecursive;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Word;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelSelectedFeaturesCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAddFromSelection;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dataGridViewHam;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Button buttonClearFeatures;
        private System.Windows.Forms.Button buttonTrain;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxKernelType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonAutoselectFeatures;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private NumericTextBox numericSpamFeatures;
        private NumericTextBox numericHamFeatures;
        private NumericTextBox numericCost;
        private NumericTextBox numericGamma;
        private System.Windows.Forms.Label label8;
        private NumericTextBox numericTestPercent;
        private TransparentTrackBar trackBarTest;
        private System.Windows.Forms.Button buttonSaveModel;
        private System.Windows.Forms.Button buttonLoadModel;

    }
}

