namespace svm
{
    partial class main
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
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.learningToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadDatasetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.classifyingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadEmailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.learningToolStripMenuItem,
            this.classifyingToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(981, 24);
            this.menuMain.TabIndex = 0;
            this.menuMain.Text = "menuStrip1";
            // 
            // learningToolStripMenuItem
            // 
            this.learningToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadDatasetToolStripMenuItem});
            this.learningToolStripMenuItem.Name = "learningToolStripMenuItem";
            this.learningToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.learningToolStripMenuItem.Text = "Learning";
            // 
            // loadDatasetToolStripMenuItem
            // 
            this.loadDatasetToolStripMenuItem.Name = "loadDatasetToolStripMenuItem";
            this.loadDatasetToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.loadDatasetToolStripMenuItem.Text = "Load dataset";
            // 
            // classifyingToolStripMenuItem
            // 
            this.classifyingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadEmailToolStripMenuItem});
            this.classifyingToolStripMenuItem.Name = "classifyingToolStripMenuItem";
            this.classifyingToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.classifyingToolStripMenuItem.Text = "Classifying";
            // 
            // loadEmailToolStripMenuItem
            // 
            this.loadEmailToolStripMenuItem.Name = "loadEmailToolStripMenuItem";
            this.loadEmailToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.loadEmailToolStripMenuItem.Text = "Load e-mail";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 359);
            this.Controls.Add(this.menuMain);
            this.MainMenuStrip = this.menuMain;
            this.Name = "main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Spam classification";
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem learningToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadDatasetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem classifyingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadEmailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

