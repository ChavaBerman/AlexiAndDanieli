namespace Client_WinForm.TeamHead
{
    partial class TeamHeadScreen
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.hoursToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewMyProjectsStateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateHoursToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logout_link = new System.Windows.Forms.LinkLabel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hoursToolStripMenuItem,
            this.viewMyProjectsStateToolStripMenuItem,
            this.updateHoursToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // hoursToolStripMenuItem
            // 
            this.hoursToolStripMenuItem.Name = "hoursToolStripMenuItem";
            this.hoursToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.hoursToolStripMenuItem.Text = "Hours Chart";
            this.hoursToolStripMenuItem.Click += new System.EventHandler(this.hoursToolStripMenuItem_Click);
            // 
            // viewMyProjectsStateToolStripMenuItem
            // 
            this.viewMyProjectsStateToolStripMenuItem.Name = "viewMyProjectsStateToolStripMenuItem";
            this.viewMyProjectsStateToolStripMenuItem.Size = new System.Drawing.Size(138, 20);
            this.viewMyProjectsStateToolStripMenuItem.Text = "View My Projects State";
            this.viewMyProjectsStateToolStripMenuItem.Click += new System.EventHandler(this.viewMyProjectsStateToolStripMenuItem_Click);
            // 
            // updateHoursToolStripMenuItem
            // 
            this.updateHoursToolStripMenuItem.Name = "updateHoursToolStripMenuItem";
            this.updateHoursToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.updateHoursToolStripMenuItem.Text = "Update Hours";
            this.updateHoursToolStripMenuItem.Click += new System.EventHandler(this.updateHoursToolStripMenuItem_Click);
            // 
            // logout_link
            // 
            this.logout_link.AutoSize = true;
            this.logout_link.Location = new System.Drawing.Point(743, 9);
            this.logout_link.Name = "logout_link";
            this.logout_link.Size = new System.Drawing.Size(45, 13);
            this.logout_link.TabIndex = 2;
            this.logout_link.TabStop = true;
            this.logout_link.Text = "Log Out";
            this.logout_link.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.logout_link_LinkClicked);
            // 
            // TeamHeadScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.logout_link);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TeamHeadScreen";
            this.Text = "TeamHeadScreen";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem hoursToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewMyProjectsStateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateHoursToolStripMenuItem;
        private System.Windows.Forms.LinkLabel logout_link;
    }
}