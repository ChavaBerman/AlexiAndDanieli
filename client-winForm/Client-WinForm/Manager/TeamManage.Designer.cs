namespace Client_WinForm.Manager
{
    partial class TeamManage
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
            this.Workers = new System.Windows.Forms.Label();
            this.cmb_workers = new System.Windows.Forms.ComboBox();
            this.cmb_managerName = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Workers
            // 
            this.Workers.AutoSize = true;
            this.Workers.Location = new System.Drawing.Point(346, 102);
            this.Workers.Name = "Workers";
            this.Workers.Size = new System.Drawing.Size(78, 13);
            this.Workers.TabIndex = 26;
            this.Workers.Text = "Choose worker";
            // 
            // cmb_workers
            // 
            this.cmb_workers.FormattingEnabled = true;
            this.cmb_workers.Location = new System.Drawing.Point(328, 129);
            this.cmb_workers.Name = "cmb_workers";
            this.cmb_workers.Size = new System.Drawing.Size(121, 21);
            this.cmb_workers.TabIndex = 25;
            this.cmb_workers.SelectedIndexChanged += new System.EventHandler(this.cmb_workers_SelectedIndexChanged);
            // 
            // cmb_managerName
            // 
            this.cmb_managerName.FormattingEnabled = true;
            this.cmb_managerName.Location = new System.Drawing.Point(328, 224);
            this.cmb_managerName.Name = "cmb_managerName";
            this.cmb_managerName.Size = new System.Drawing.Size(121, 21);
            this.cmb_managerName.TabIndex = 28;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(346, 196);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "His Team Header:";
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(349, 289);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 29;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // TeamManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.cmb_managerName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Workers);
            this.Controls.Add(this.cmb_workers);
            this.Name = "TeamManage";
            this.Text = "TeamManage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Workers;
        private System.Windows.Forms.ComboBox cmb_workers;
        private System.Windows.Forms.ComboBox cmb_managerName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_save;
    }
}