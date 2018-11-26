namespace Client_WinForm.Manager
{
    partial class ManagerMainScreen
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
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.addProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageReportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageUsersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editWorkerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageTeamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.logout_link = new System.Windows.Forms.LinkLabel();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addProjectToolStripMenuItem,
            this.manageReportsToolStripMenuItem,
            this.manageUsersToolStripMenuItem,
            this.manageTeamToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(800, 24);
            this.menuStrip2.TabIndex = 0;
            this.menuStrip2.Text = "menuStrip1";
            // 
            // addProjectToolStripMenuItem
            // 
            this.addProjectToolStripMenuItem.Name = "addProjectToolStripMenuItem";
            this.addProjectToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.addProjectToolStripMenuItem.Text = "Add Project";
            this.addProjectToolStripMenuItem.Click += new System.EventHandler(this.addProjectToolStripMenuItem_Click);
            // 
            // manageReportsToolStripMenuItem
            // 
            this.manageReportsToolStripMenuItem.Name = "manageReportsToolStripMenuItem";
            this.manageReportsToolStripMenuItem.Size = new System.Drawing.Size(105, 20);
            this.manageReportsToolStripMenuItem.Text = "Manage Reports";
            this.manageReportsToolStripMenuItem.Click += new System.EventHandler(this.manageReportsToolStripMenuItem_Click);
            // 
            // manageUsersToolStripMenuItem
            // 
            this.manageUsersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addUserToolStripMenuItem,
            this.setPToolStripMenuItem,
            this.editWorkerToolStripMenuItem});
            this.manageUsersToolStripMenuItem.Name = "manageUsersToolStripMenuItem";
            this.manageUsersToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.manageUsersToolStripMenuItem.Text = "Manage Users";
            // 
            // addUserToolStripMenuItem
            // 
            this.addUserToolStripMenuItem.Name = "addUserToolStripMenuItem";
            this.addUserToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.addUserToolStripMenuItem.Text = "Add Worker";
            this.addUserToolStripMenuItem.Click += new System.EventHandler(this.addUserToolStripMenuItem_Click);
            // 
            // setPToolStripMenuItem
            // 
            this.setPToolStripMenuItem.Name = "setPToolStripMenuItem";
            this.setPToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.setPToolStripMenuItem.Text = "Set Permission";
            this.setPToolStripMenuItem.Click += new System.EventHandler(this.setPToolStripMenuItem_Click);
            // 
            // editWorkerToolStripMenuItem
            // 
            this.editWorkerToolStripMenuItem.Name = "editWorkerToolStripMenuItem";
            this.editWorkerToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.editWorkerToolStripMenuItem.Text = "Edit Worker";
            this.editWorkerToolStripMenuItem.Click += new System.EventHandler(this.editWorkerToolStripMenuItem_Click);
            // 
            // manageTeamToolStripMenuItem
            // 
            this.manageTeamToolStripMenuItem.Name = "manageTeamToolStripMenuItem";
            this.manageTeamToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.manageTeamToolStripMenuItem.Text = "Manage Team";
            this.manageTeamToolStripMenuItem.Click += new System.EventHandler(this.manageTeamToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // logout_link
            // 
            this.logout_link.AutoSize = true;
            this.logout_link.Location = new System.Drawing.Point(733, 9);
            this.logout_link.Name = "logout_link";
            this.logout_link.Size = new System.Drawing.Size(45, 13);
            this.logout_link.TabIndex = 1;
            this.logout_link.TabStop = true;
            this.logout_link.Text = "Log Out";
            this.logout_link.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.logout_link_LinkClicked);
            // 
            // ManagerMainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.logout_link);
            this.Controls.Add(this.menuStrip2);
            this.MainMenuStrip = this.menuStrip2;
            this.Name = "ManagerMainScreen";
            this.Text = "ManagerMainScreen";
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem addProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageReportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageUsersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageTeamToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.LinkLabel logout_link;
        private System.Windows.Forms.ToolStripMenuItem addUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editWorkerToolStripMenuItem;
    }
}