namespace Client_WinForm
{
    partial class WorkerScreen
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txt_clock = new System.Windows.Forms.TextBox();
            this.btn_login = new System.Windows.Forms.Button();
            this.btn_logout = new System.Windows.Forms.Button();
            this.cmb_myProjects = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.logout_link = new System.Windows.Forms.LinkLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.myTasksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.myHoursToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_duration = new System.Windows.Forms.Label();
            this.btn_apply = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txt_clock
            // 
            this.txt_clock.Location = new System.Drawing.Point(288, 37);
            this.txt_clock.Name = "txt_clock";
            this.txt_clock.Size = new System.Drawing.Size(194, 20);
            this.txt_clock.TabIndex = 0;
            // 
            // btn_login
            // 
            this.btn_login.Location = new System.Drawing.Point(506, 35);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(75, 23);
            this.btn_login.TabIndex = 1;
            this.btn_login.Text = "Begin";
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // btn_logout
            // 
            this.btn_logout.Location = new System.Drawing.Point(587, 35);
            this.btn_logout.Name = "btn_logout";
            this.btn_logout.Size = new System.Drawing.Size(75, 23);
            this.btn_logout.TabIndex = 2;
            this.btn_logout.Text = "Stop";
            this.btn_logout.UseVisualStyleBackColor = true;
            this.btn_logout.Click += new System.EventHandler(this.btn_logout_Click);
            // 
            // cmb_myProjects
            // 
            this.cmb_myProjects.FormattingEnabled = true;
            this.cmb_myProjects.Location = new System.Drawing.Point(149, 37);
            this.cmb_myProjects.Name = "cmb_myProjects";
            this.cmb_myProjects.Size = new System.Drawing.Size(121, 21);
            this.cmb_myProjects.TabIndex = 3;
            this.cmb_myProjects.SelectedIndexChanged += new System.EventHandler(this.cmb_myProjects_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Choose Project";
            // 
            // logout_link
            // 
            this.logout_link.AutoSize = true;
            this.logout_link.Location = new System.Drawing.Point(743, 9);
            this.logout_link.Name = "logout_link";
            this.logout_link.Size = new System.Drawing.Size(45, 13);
            this.logout_link.TabIndex = 5;
            this.logout_link.TabStop = true;
            this.logout_link.Text = "Log Out";
            this.logout_link.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.logout_link_LinkClicked);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.myTasksToolStripMenuItem,
            this.myHoursToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1045, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // myTasksToolStripMenuItem
            // 
            this.myTasksToolStripMenuItem.Name = "myTasksToolStripMenuItem";
            this.myTasksToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.myTasksToolStripMenuItem.Text = "My Tasks";
            this.myTasksToolStripMenuItem.Click += new System.EventHandler(this.myTasksToolStripMenuItem_Click);
            // 
            // myHoursToolStripMenuItem
            // 
            this.myHoursToolStripMenuItem.Name = "myHoursToolStripMenuItem";
            this.myHoursToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.myHoursToolStripMenuItem.Text = "My Hours";
            this.myHoursToolStripMenuItem.Click += new System.EventHandler(this.myHoursToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(853, 512);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "duration";
            // 
            // lbl_duration
            // 
            this.lbl_duration.AutoSize = true;
            this.lbl_duration.Location = new System.Drawing.Point(904, 512);
            this.lbl_duration.Name = "lbl_duration";
            this.lbl_duration.Size = new System.Drawing.Size(0, 13);
            this.lbl_duration.TabIndex = 9;
            // 
            // btn_apply
            // 
            this.btn_apply.Location = new System.Drawing.Point(37, 523);
            this.btn_apply.Name = "btn_apply";
            this.btn_apply.Size = new System.Drawing.Size(140, 23);
            this.btn_apply.TabIndex = 10;
            this.btn_apply.Text = "Apply to Manager";
            this.btn_apply.UseVisualStyleBackColor = true;
            this.btn_apply.Click += new System.EventHandler(this.btn_apply_Click);
            // 
            // WorkerScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 579);
            this.Controls.Add(this.btn_apply);
            this.Controls.Add(this.lbl_duration);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.logout_link);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmb_myProjects);
            this.Controls.Add(this.btn_logout);
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.txt_clock);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "WorkerScreen";
            this.Text = "WorkerScreen";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox txt_clock;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.Button btn_logout;
        private System.Windows.Forms.ComboBox cmb_myProjects;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel logout_link;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem myTasksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem myHoursToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_duration;
        private System.Windows.Forms.Button btn_apply;
    }
}