namespace Client_WinForm.Manager
{
    partial class EditWorkerProfile
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
            this.btn_save = new System.Windows.Forms.Button();
            this.cmb_managerName = new System.Windows.Forms.ComboBox();
            this.cmb_department = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_delete = new System.Windows.Forms.Button();
            this.cmb_workers = new System.Windows.Forms.ComboBox();
            this.Workers = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(329, 267);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 21;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // cmb_managerName
            // 
            this.cmb_managerName.FormattingEnabled = true;
            this.cmb_managerName.Location = new System.Drawing.Point(308, 191);
            this.cmb_managerName.Name = "cmb_managerName";
            this.cmb_managerName.Size = new System.Drawing.Size(121, 21);
            this.cmb_managerName.TabIndex = 20;
            // 
            // cmb_department
            // 
            this.cmb_department.FormattingEnabled = true;
            this.cmb_department.Location = new System.Drawing.Point(308, 164);
            this.cmb_department.Name = "cmb_department";
            this.cmb_department.Size = new System.Drawing.Size(121, 21);
            this.cmb_department.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(225, 199);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Manager Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(225, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Department";
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(410, 267);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(75, 23);
            this.btn_delete.TabIndex = 22;
            this.btn_delete.Text = "Delete";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // cmb_workers
            // 
            this.cmb_workers.FormattingEnabled = true;
            this.cmb_workers.Location = new System.Drawing.Point(308, 82);
            this.cmb_workers.Name = "cmb_workers";
            this.cmb_workers.Size = new System.Drawing.Size(121, 21);
            this.cmb_workers.TabIndex = 23;
            this.cmb_workers.SelectedIndexChanged += new System.EventHandler(this.cmb_workers_SelectedIndexChanged);
            // 
            // Workers
            // 
            this.Workers.AutoSize = true;
            this.Workers.Location = new System.Drawing.Point(326, 55);
            this.Workers.Name = "Workers";
            this.Workers.Size = new System.Drawing.Size(78, 13);
            this.Workers.TabIndex = 24;
            this.Workers.Text = "Choose worker";
            // 
            // EditWorkerProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Workers);
            this.Controls.Add(this.cmb_workers);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.cmb_managerName);
            this.Controls.Add(this.cmb_department);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Name = "EditWorkerProfile";
            this.Text = "EditWorkerProfile";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.ComboBox cmb_managerName;
        private System.Windows.Forms.ComboBox cmb_department;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.ComboBox cmb_workers;
        private System.Windows.Forms.Label Workers;
    }
}