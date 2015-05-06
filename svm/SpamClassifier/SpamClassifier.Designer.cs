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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpamClassifier));
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabLearning = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridViewSpam = new System.Windows.Forms.DataGridView();
            this.Word = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonLoadSpam = new System.Windows.Forms.Button();
            this.labelSpam = new System.Windows.Forms.Label();
            this.dataGridViewHam = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonLoadHam = new System.Windows.Forms.Button();
            this.labelHam = new System.Windows.Forms.Label();
            this.tabClassifying = new System.Windows.Forms.TabPage();
            this.buttonClearTxt = new System.Windows.Forms.Button();
            this.labelClassificationResult = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonClassifyTxt = new System.Windows.Forms.Button();
            this.richTextBoxEmail = new System.Windows.Forms.RichTextBox();
            this.buttonLoadEmail = new System.Windows.Forms.Button();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBoxRecursive = new System.Windows.Forms.CheckBox();
            this.buttonReset = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonShowUseless = new System.Windows.Forms.Button();
            this.buttonLoadUseless = new System.Windows.Forms.Button();
            this.buttonClearUseless = new System.Windows.Forms.Button();
            this.tabControlMain.SuspendLayout();
            this.tabLearning.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSpam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHam)).BeginInit();
            this.tabClassifying.SuspendLayout();
            this.tabSettings.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabLearning);
            this.tabControlMain.Controls.Add(this.tabClassifying);
            this.tabControlMain.Controls.Add(this.tabSettings);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(981, 480);
            this.tabControlMain.TabIndex = 1;
            // 
            // tabLearning
            // 
            this.tabLearning.Controls.Add(this.splitContainer1);
            this.tabLearning.Location = new System.Drawing.Point(4, 22);
            this.tabLearning.Name = "tabLearning";
            this.tabLearning.Padding = new System.Windows.Forms.Padding(3);
            this.tabLearning.Size = new System.Drawing.Size(973, 454);
            this.tabLearning.TabIndex = 0;
            this.tabLearning.Text = "Learning";
            this.tabLearning.UseVisualStyleBackColor = true;
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
            this.splitContainer1.Panel1.Controls.Add(this.dataGridViewSpam);
            this.splitContainer1.Panel1.Controls.Add(this.buttonLoadSpam);
            this.splitContainer1.Panel1.Controls.Add(this.labelSpam);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridViewHam);
            this.splitContainer1.Panel2.Controls.Add(this.buttonLoadHam);
            this.splitContainer1.Panel2.Controls.Add(this.labelHam);
            this.splitContainer1.Size = new System.Drawing.Size(967, 448);
            this.splitContainer1.SplitterDistance = 483;
            this.splitContainer1.SplitterWidth = 10;
            this.splitContainer1.TabIndex = 0;
            // 
            // dataGridViewSpam
            // 
            this.dataGridViewSpam.AllowUserToAddRows = false;
            this.dataGridViewSpam.AllowUserToDeleteRows = false;
            this.dataGridViewSpam.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewSpam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSpam.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Word,
            this.Count});
            this.dataGridViewSpam.Location = new System.Drawing.Point(3, 55);
            this.dataGridViewSpam.Name = "dataGridViewSpam";
            this.dataGridViewSpam.Size = new System.Drawing.Size(477, 375);
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
            // buttonLoadSpam
            // 
            this.buttonLoadSpam.Location = new System.Drawing.Point(3, 26);
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
            this.labelSpam.Size = new System.Drawing.Size(483, 23);
            this.labelSpam.TabIndex = 0;
            this.labelSpam.Text = "SPAM";
            this.labelSpam.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridViewHam
            // 
            this.dataGridViewHam.AllowUserToAddRows = false;
            this.dataGridViewHam.AllowUserToDeleteRows = false;
            this.dataGridViewHam.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewHam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHam.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dataGridViewHam.Location = new System.Drawing.Point(3, 55);
            this.dataGridViewHam.Name = "dataGridViewHam";
            this.dataGridViewHam.Size = new System.Drawing.Size(426, 375);
            this.dataGridViewHam.TabIndex = 2;
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
            // buttonLoadHam
            // 
            this.buttonLoadHam.Location = new System.Drawing.Point(3, 26);
            this.buttonLoadHam.Name = "buttonLoadHam";
            this.buttonLoadHam.Size = new System.Drawing.Size(137, 23);
            this.buttonLoadHam.TabIndex = 2;
            this.buttonLoadHam.Text = "Load set from directory";
            this.buttonLoadHam.UseVisualStyleBackColor = true;
            this.buttonLoadHam.Click += new System.EventHandler(this.buttonLoadHam_Click);
            // 
            // labelHam
            // 
            this.labelHam.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelHam.Location = new System.Drawing.Point(0, 0);
            this.labelHam.Name = "labelHam";
            this.labelHam.Size = new System.Drawing.Size(474, 23);
            this.labelHam.TabIndex = 1;
            this.labelHam.Text = "HAM";
            this.labelHam.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.tabClassifying.Size = new System.Drawing.Size(973, 454);
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
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.groupBox2);
            this.tabSettings.Controls.Add(this.groupBox1);
            this.tabSettings.Location = new System.Drawing.Point(4, 22);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Size = new System.Drawing.Size(973, 454);
            this.tabSettings.TabIndex = 2;
            this.tabSettings.Text = "Settings";
            this.tabSettings.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBoxRecursive);
            this.groupBox2.Controls.Add(this.buttonReset);
            this.groupBox2.Location = new System.Drawing.Point(8, 133);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(171, 78);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Training set";
            // 
            // checkBoxRecursive
            // 
            this.checkBoxRecursive.AutoSize = true;
            this.checkBoxRecursive.Location = new System.Drawing.Point(6, 21);
            this.checkBoxRecursive.Name = "checkBoxRecursive";
            this.checkBoxRecursive.Size = new System.Drawing.Size(159, 17);
            this.checkBoxRecursive.TabIndex = 6;
            this.checkBoxRecursive.Text = "Read training set recursively";
            this.checkBoxRecursive.UseVisualStyleBackColor = true;
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(6, 44);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(159, 23);
            this.buttonReset.TabIndex = 5;
            this.buttonReset.Text = "Reset training set";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonShowUseless);
            this.groupBox1.Controls.Add(this.buttonLoadUseless);
            this.groupBox1.Controls.Add(this.buttonClearUseless);
            this.groupBox1.Location = new System.Drawing.Point(8, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(171, 114);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Useless words";
            // 
            // buttonShowUseless
            // 
            this.buttonShowUseless.Location = new System.Drawing.Point(6, 23);
            this.buttonShowUseless.Name = "buttonShowUseless";
            this.buttonShowUseless.Size = new System.Drawing.Size(159, 23);
            this.buttonShowUseless.TabIndex = 1;
            this.buttonShowUseless.Text = "Show useless words list";
            this.buttonShowUseless.UseVisualStyleBackColor = true;
            this.buttonShowUseless.Click += new System.EventHandler(this.buttonShowUseless_Click);
            // 
            // buttonLoadUseless
            // 
            this.buttonLoadUseless.Location = new System.Drawing.Point(6, 52);
            this.buttonLoadUseless.Name = "buttonLoadUseless";
            this.buttonLoadUseless.Size = new System.Drawing.Size(159, 23);
            this.buttonLoadUseless.TabIndex = 0;
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
            // SpamClassifier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 480);
            this.Controls.Add(this.tabControlMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SpamClassifier";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Spam classification";
            this.tabControlMain.ResumeLayout(false);
            this.tabLearning.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSpam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHam)).EndInit();
            this.tabClassifying.ResumeLayout(false);
            this.tabClassifying.PerformLayout();
            this.tabSettings.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
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
        private System.Windows.Forms.DataGridView dataGridViewHam;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBoxRecursive;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Word;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;

    }
}

