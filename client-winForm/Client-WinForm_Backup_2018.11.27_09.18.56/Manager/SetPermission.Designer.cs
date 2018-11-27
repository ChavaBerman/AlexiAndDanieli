namespace Client_WinForm.Manager
{
    partial class SetPermission
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
            this.cmb_workers = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_projects = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.num_hours = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_add = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.num_hours)).BeginInit();
            this.SuspendLayout();
            // 
            // cmb_workers
            // 
            this.cmb_workers.FormattingEnabled = true;
            this.cmb_workers.Location = new System.Drawing.Point(275, 70);
            this.cmb_workers.Name = "cmb_workers";
            this.cmb_workers.Size = new System.Drawing.Size(189, 21);
            this.cmb_workers.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(334, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Choose worker";
            // 
            // cmb_projects
            // 
            this.cmb_projects.FormattingEnabled = true;
            this.cmb_projects.Location = new System.Drawing.Point(275, 164);
            this.cmb_projects.Name = "cmb_projects";
            this.cmb_projects.Size = new System.Drawing.Size(189, 21);
            this.cmb_projects.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(334, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Choose project";
            // 
            // num_hours
            // 
            this.num_hours.Location = new System.Drawing.Point(315, 247);
            this.num_hours.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_hours.Name = "num_hours";
            this.num_hours.Size = new System.Drawing.Size(124, 20);
            this.num_hours.TabIndex = 4;
            this.num_hours.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(334, 216);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Givan hours";
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(327, 318);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(102, 23);
            this.btn_add.TabIndex = 6;
            this.btn_add.Text = "Add to project";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // SetPermission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.num_hours);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmb_projects);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmb_workers);
            this.Name = "SetPermission";
            this.Text = "SetPermission";
            ((System.ComponentModel.ISupportInitialize)(this.num_hours)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_workers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_projects;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown num_hours;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_add;
    }
}