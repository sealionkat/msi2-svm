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
            this.buttonLoadSpam = new System.Windows.Forms.Button();
            this.labelSpam = new System.Windows.Forms.Label();
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
            this.labelHamCnt = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelSpamCnt = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonReset = new System.Windows.Forms.Button();
            this.labelLastUpdate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClearUseless = new System.Windows.Forms.Button();
            this.buttonShowUseless = new System.Windows.Forms.Button();
            this.buttonLoadUseless = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tabControlMain.SuspendLayout();
            this.tabLearning.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabClassifying.SuspendLayout();
            this.tabSettings.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.buttonLoadSpam);
            this.splitContainer1.Panel1.Controls.Add(this.labelSpam);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.buttonLoadHam);
            this.splitContainer1.Panel2.Controls.Add(this.labelHam);
            this.splitContainer1.Size = new System.Drawing.Size(967, 448);
            this.splitContainer1.SplitterDistance = 483;
            this.splitContainer1.SplitterWidth = 10;
            this.splitContainer1.TabIndex = 0;
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
            this.buttonClearTxt.Size = new System.Drawing.Size(90, 23);
            this.buttonClearTxt.TabIndex = 5;
            this.buttonClearTxt.Text = "Clear textarea";
            this.buttonClearTxt.UseVisualStyleBackColor = true;
            // 
            // labelClassificationResult
            // 
            this.labelClassificationResult.AutoSize = true;
            this.labelClassificationResult.Location = new System.Drawing.Point(206, 356);
            this.labelClassificationResult.Name = "labelClassificationResult";
            this.labelClassificationResult.Size = new System.Drawing.Size(22, 13);
            this.labelClassificationResult.TabIndex = 4;
            this.labelClassificationResult.Text = "NA";
            // 
            // label2
            // 
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
            // 
            // richTextBoxEmail
            // 
            this.richTextBoxEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxEmail.Location = new System.Drawing.Point(17, 45);
            this.richTextBoxEmail.Name = "richTextBoxEmail";
            this.richTextBoxEmail.ReadOnly = true;
            this.richTextBoxEmail.Size = new System.Drawing.Size(938, 300);
            this.richTextBoxEmail.TabIndex = 1;
            this.richTextBoxEmail.Text = "";
            // 
            // buttonLoadEmail
            // 
            this.buttonLoadEmail.Location = new System.Drawing.Point(17, 16);
            this.buttonLoadEmail.Name = "buttonLoadEmail";
            this.buttonLoadEmail.Size = new System.Drawing.Size(75, 23);
            this.buttonLoadEmail.TabIndex = 0;
            this.buttonLoadEmail.Text = "Load e-mail";
            this.buttonLoadEmail.UseVisualStyleBackColor = true;
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.labelHamCnt);
            this.tabSettings.Controls.Add(this.label6);
            this.tabSettings.Controls.Add(this.labelSpamCnt);
            this.tabSettings.Controls.Add(this.label4);
            this.tabSettings.Controls.Add(this.buttonReset);
            this.tabSettings.Controls.Add(this.labelLastUpdate);
            this.tabSettings.Controls.Add(this.label1);
            this.tabSettings.Controls.Add(this.buttonClearUseless);
            this.tabSettings.Controls.Add(this.buttonShowUseless);
            this.tabSettings.Controls.Add(this.buttonLoadUseless);
            this.tabSettings.Location = new System.Drawing.Point(4, 22);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Size = new System.Drawing.Size(973, 454);
            this.tabSettings.TabIndex = 2;
            this.tabSettings.Text = "Settings";
            this.tabSettings.UseVisualStyleBackColor = true;
            // 
            // labelHamCnt
            // 
            this.labelHamCnt.AutoSize = true;
            this.labelHamCnt.Location = new System.Drawing.Point(397, 83);
            this.labelHamCnt.Name = "labelHamCnt";
            this.labelHamCnt.Size = new System.Drawing.Size(22, 13);
            this.labelHamCnt.TabIndex = 9;
            this.labelHamCnt.Text = "NA";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(327, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "HAM count:";
            // 
            // labelSpamCnt
            // 
            this.labelSpamCnt.AutoSize = true;
            this.labelSpamCnt.Location = new System.Drawing.Point(273, 83);
            this.labelSpamCnt.Name = "labelSpamCnt";
            this.labelSpamCnt.Size = new System.Drawing.Size(22, 13);
            this.labelSpamCnt.TabIndex = 7;
            this.labelSpamCnt.Text = "NA";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(197, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "SPAM count:";
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(18, 113);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(120, 23);
            this.buttonReset.TabIndex = 5;
            this.buttonReset.Text = "Reset training";
            this.buttonReset.UseVisualStyleBackColor = true;
            // 
            // labelLastUpdate
            // 
            this.labelLastUpdate.AutoSize = true;
            this.labelLastUpdate.Location = new System.Drawing.Point(144, 83);
            this.labelLastUpdate.Name = "labelLastUpdate";
            this.labelLastUpdate.Size = new System.Drawing.Size(22, 13);
            this.labelLastUpdate.TabIndex = 4;
            this.labelLastUpdate.Text = "NA";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Training set last update: ";
            // 
            // buttonClearUseless
            // 
            this.buttonClearUseless.Location = new System.Drawing.Point(297, 21);
            this.buttonClearUseless.Name = "buttonClearUseless";
            this.buttonClearUseless.Size = new System.Drawing.Size(141, 23);
            this.buttonClearUseless.TabIndex = 2;
            this.buttonClearUseless.Text = "Clear useless words list";
            this.buttonClearUseless.UseVisualStyleBackColor = true;
            // 
            // buttonShowUseless
            // 
            this.buttonShowUseless.Location = new System.Drawing.Point(18, 21);
            this.buttonShowUseless.Name = "buttonShowUseless";
            this.buttonShowUseless.Size = new System.Drawing.Size(131, 23);
            this.buttonShowUseless.TabIndex = 1;
            this.buttonShowUseless.Text = "Show useless words list";
            this.buttonShowUseless.UseVisualStyleBackColor = true;
            // 
            // buttonLoadUseless
            // 
            this.buttonLoadUseless.Location = new System.Drawing.Point(155, 21);
            this.buttonLoadUseless.Name = "buttonLoadUseless";
            this.buttonLoadUseless.Size = new System.Drawing.Size(136, 23);
            this.buttonLoadUseless.TabIndex = 0;
            this.buttonLoadUseless.Text = "Load useless words list";
            this.buttonLoadUseless.UseVisualStyleBackColor = true;
            // 
            // statusStrip
            // 
            this.statusStrip.Location = new System.Drawing.Point(0, 458);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(981, 22);
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip1";
            // 
            // SpamClassifier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 480);
            this.Controls.Add(this.statusStrip);
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
            this.tabClassifying.ResumeLayout(false);
            this.tabClassifying.PerformLayout();
            this.tabSettings.ResumeLayout(false);
            this.tabSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabLearning;
        private System.Windows.Forms.TabPage tabClassifying;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label labelSpam;
        private System.Windows.Forms.Label labelHam;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Label labelLastUpdate;
        private System.Windows.Forms.Label label1;
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
        private System.Windows.Forms.Label labelHamCnt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelSpamCnt;
        private System.Windows.Forms.Label label4;

    }
}

