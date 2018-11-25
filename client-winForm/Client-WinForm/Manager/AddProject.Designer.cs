namespace Client_WinForm.Manager
{
    partial class AddProject
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
            this.txt_projectName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_CustomerName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmb_TeamHeads = new System.Windows.Forms.ComboBox();
            this.cmb_workers = new System.Windows.Forms.ComboBox();
            this.DevHours = new System.Windows.Forms.NumericUpDown();
            this.UIUXHours = new System.Windows.Forms.NumericUpDown();
            this.QAHours = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.date_begin = new System.Windows.Forms.DateTimePicker();
            this.date_end = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btn_add_project = new System.Windows.Forms.Button();
            this.Added_Workers = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.DevHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UIUXHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QAHours)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_projectName
            // 
            this.txt_projectName.Location = new System.Drawing.Point(291, 61);
            this.txt_projectName.Name = "txt_projectName";
            this.txt_projectName.Size = new System.Drawing.Size(121, 20);
            this.txt_projectName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(187, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Project Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(187, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Customer Name";
            // 
            // txt_CustomerName
            // 
            this.txt_CustomerName.Location = new System.Drawing.Point(291, 87);
            this.txt_CustomerName.Name = "txt_CustomerName";
            this.txt_CustomerName.Size = new System.Drawing.Size(121, 20);
            this.txt_CustomerName.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(187, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Team Head";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(187, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "allowed Workers";
            // 
            // cmb_TeamHeads
            // 
            this.cmb_TeamHeads.FormattingEnabled = true;
            this.cmb_TeamHeads.Location = new System.Drawing.Point(291, 112);
            this.cmb_TeamHeads.Name = "cmb_TeamHeads";
            this.cmb_TeamHeads.Size = new System.Drawing.Size(121, 21);
            this.cmb_TeamHeads.TabIndex = 8;
            this.cmb_TeamHeads.SelectedIndexChanged += new System.EventHandler(this.cmb_TeamHeads_SelectedIndexChanged);
            // 
            // cmb_workers
            // 
            this.cmb_workers.FormattingEnabled = true;
            this.cmb_workers.Location = new System.Drawing.Point(291, 136);
            this.cmb_workers.Name = "cmb_workers";
            this.cmb_workers.Size = new System.Drawing.Size(121, 21);
            this.cmb_workers.TabIndex = 9;
            this.cmb_workers.SelectedIndexChanged += new System.EventHandler(this.cmb_workers_SelectedIndexChanged);
            // 
            // DevHours
            // 
            this.DevHours.Location = new System.Drawing.Point(292, 163);
            this.DevHours.Name = "DevHours";
            this.DevHours.Size = new System.Drawing.Size(120, 20);
            this.DevHours.TabIndex = 10;
            // 
            // UIUXHours
            // 
            this.UIUXHours.Location = new System.Drawing.Point(292, 189);
            this.UIUXHours.Name = "UIUXHours";
            this.UIUXHours.Size = new System.Drawing.Size(120, 20);
            this.UIUXHours.TabIndex = 11;
            // 
            // QAHours
            // 
            this.QAHours.Location = new System.Drawing.Point(292, 215);
            this.QAHours.Name = "QAHours";
            this.QAHours.Size = new System.Drawing.Size(120, 20);
            this.QAHours.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(187, 217);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "QA Houres";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(184, 166);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Development Houres";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(187, 191);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "UI/UX Houres";
            // 
            // date_begin
            // 
            this.date_begin.Location = new System.Drawing.Point(292, 241);
            this.date_begin.Name = "date_begin";
            this.date_begin.Size = new System.Drawing.Size(200, 20);
            this.date_begin.TabIndex = 16;
            // 
            // date_end
            // 
            this.date_end.AllowDrop = true;
            this.date_end.Location = new System.Drawing.Point(291, 267);
            this.date_end.Name = "date_end";
            this.date_end.Size = new System.Drawing.Size(200, 20);
            this.date_end.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(187, 267);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "End Date";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(187, 243);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Begin Date";
            // 
            // btn_add_project
            // 
            this.btn_add_project.Location = new System.Drawing.Point(308, 318);
            this.btn_add_project.Name = "btn_add_project";
            this.btn_add_project.Size = new System.Drawing.Size(75, 23);
            this.btn_add_project.TabIndex = 20;
            this.btn_add_project.Text = "Add Project";
            this.btn_add_project.UseVisualStyleBackColor = true;
            this.btn_add_project.Click += new System.EventHandler(this.btn_add_project_Click);
            // 
            // Added_Workers
            // 
            this.Added_Workers.Location = new System.Drawing.Point(608, 82);
            this.Added_Workers.Name = "Added_Workers";
            this.Added_Workers.Size = new System.Drawing.Size(121, 97);
            this.Added_Workers.TabIndex = 22;
            this.Added_Workers.UseCompatibleStateImageBehavior = false;
            this.Added_Workers.SelectedIndexChanged += new System.EventHandler(this.Added_Workers_SelectedIndexChanged);
            // 
            // AddProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Added_Workers);
            this.Controls.Add(this.btn_add_project);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.date_end);
            this.Controls.Add(this.date_begin);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.QAHours);
            this.Controls.Add(this.UIUXHours);
            this.Controls.Add(this.DevHours);
            this.Controls.Add(this.cmb_workers);
            this.Controls.Add(this.cmb_TeamHeads);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_CustomerName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_projectName);
            this.Name = "AddProject";
            this.Text = "AddProject";
            ((System.ComponentModel.ISupportInitialize)(this.DevHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UIUXHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QAHours)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_projectName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_CustomerName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmb_TeamHeads;
        private System.Windows.Forms.ComboBox cmb_workers;
        private System.Windows.Forms.NumericUpDown DevHours;
        private System.Windows.Forms.NumericUpDown UIUXHours;
        private System.Windows.Forms.NumericUpDown QAHours;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker date_begin;
        private System.Windows.Forms.DateTimePicker date_end;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btn_add_project;
        private System.Windows.Forms.ListView Added_Workers;
    }
}