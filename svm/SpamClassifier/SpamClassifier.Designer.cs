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
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabLearning = new System.Windows.Forms.TabPage();
            this.tabClassifying = new System.Windows.Forms.TabPage();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.labelSpam = new System.Windows.Forms.Label();
            this.labelHam = new System.Windows.Forms.Label();
            this.tabControlMain.SuspendLayout();
            this.tabLearning.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabLearning);
            this.tabControlMain.Controls.Add(this.tabClassifying);
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
            // tabClassifying
            // 
            this.tabClassifying.Location = new System.Drawing.Point(4, 22);
            this.tabClassifying.Name = "tabClassifying";
            this.tabClassifying.Padding = new System.Windows.Forms.Padding(3);
            this.tabClassifying.Size = new System.Drawing.Size(973, 454);
            this.tabClassifying.TabIndex = 1;
            this.tabClassifying.Text = "Classifying";
            this.tabClassifying.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 458);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(981, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
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
            this.splitContainer1.Panel1.Controls.Add(this.labelSpam);
            // 
            // splitContainer1.Panel2
            // 
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
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 480);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControlMain);
            this.Name = "main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Spam classification";
            this.tabControlMain.ResumeLayout(false);
            this.tabLearning.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
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

    }
}

