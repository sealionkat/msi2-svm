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
            this.labelSpam = new System.Windows.Forms.Label();
            this.labelHam = new System.Windows.Forms.Label();
            this.tabClassifying = new System.Windows.Forms.TabPage();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelLastUpdate = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
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
            this.splitContainer1.Panel1.Controls.Add(this.button8);
            this.splitContainer1.Panel1.Controls.Add(this.labelSpam);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.button9);
            this.splitContainer1.Panel2.Controls.Add(this.labelHam);
            this.splitContainer1.Size = new System.Drawing.Size(967, 448);
            this.splitContainer1.SplitterDistance = 483;
            this.splitContainer1.SplitterWidth = 10;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
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
            this.tabClassifying.Controls.Add(this.button7);
            this.tabClassifying.Controls.Add(this.label3);
            this.tabClassifying.Controls.Add(this.label2);
            this.tabClassifying.Controls.Add(this.button6);
            this.tabClassifying.Controls.Add(this.richTextBox1);
            this.tabClassifying.Controls.Add(this.button5);
            this.tabClassifying.Location = new System.Drawing.Point(4, 22);
            this.tabClassifying.Name = "tabClassifying";
            this.tabClassifying.Padding = new System.Windows.Forms.Padding(3);
            this.tabClassifying.Size = new System.Drawing.Size(973, 454);
            this.tabClassifying.TabIndex = 1;
            this.tabClassifying.Text = "Classifying";
            this.tabClassifying.UseVisualStyleBackColor = true;
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.label7);
            this.tabSettings.Controls.Add(this.label6);
            this.tabSettings.Controls.Add(this.label5);
            this.tabSettings.Controls.Add(this.label4);
            this.tabSettings.Controls.Add(this.button4);
            this.tabSettings.Controls.Add(this.labelLastUpdate);
            this.tabSettings.Controls.Add(this.label1);
            this.tabSettings.Controls.Add(this.button3);
            this.tabSettings.Controls.Add(this.button2);
            this.tabSettings.Controls.Add(this.button1);
            this.tabSettings.Location = new System.Drawing.Point(4, 22);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Size = new System.Drawing.Size(973, 454);
            this.tabSettings.TabIndex = 2;
            this.tabSettings.Text = "Settings";
            this.tabSettings.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 458);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(981, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(155, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Load useless words list";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(18, 21);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(131, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Show useless words list";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(297, 21);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(141, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Clear useless words list";
            this.button3.UseVisualStyleBackColor = true;
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
            // labelLastUpdate
            // 
            this.labelLastUpdate.AutoSize = true;
            this.labelLastUpdate.Location = new System.Drawing.Point(144, 83);
            this.labelLastUpdate.Name = "labelLastUpdate";
            this.labelLastUpdate.Size = new System.Drawing.Size(22, 13);
            this.labelLastUpdate.TabIndex = 4;
            this.labelLastUpdate.Text = "NA";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(18, 113);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(120, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "Reset training";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(17, 16);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 0;
            this.button5.Text = "Load e-mail";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(17, 45);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(938, 300);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(17, 351);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 2;
            this.button6.Text = "Classify";
            this.button6.UseVisualStyleBackColor = true;
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(206, 356);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "NA";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(98, 16);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(90, 23);
            this.button7.TabIndex = 5;
            this.button7.Text = "Clear textarea";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(3, 26);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(137, 23);
            this.button8.TabIndex = 1;
            this.button8.Text = "Load set from directory";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(3, 26);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(137, 23);
            this.button9.TabIndex = 2;
            this.button9.Text = "Load set from directory";
            this.button9.UseVisualStyleBackColor = true;
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(273, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "NA";
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(397, 83);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(22, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "NA";
            // 
            // SpamClassifier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 480);
            this.Controls.Add(this.statusStrip1);
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
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label labelSpam;
        private System.Windows.Forms.Label labelHam;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label labelLastUpdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;

    }
}

