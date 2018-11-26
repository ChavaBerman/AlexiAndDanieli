namespace Client_WinForm.Manager
{
    partial class Report
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
            Telerik.WinControls.Data.GroupDescriptor groupDescriptor1 = new Telerik.WinControls.Data.GroupDescriptor();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.grid_data_report = new Telerik.WinControls.UI.RadGridView();
            this.cmb_month = new System.Windows.Forms.ComboBox();
            this.cmb_teamHeads = new System.Windows.Forms.ComboBox();
            this.cmb_projects = new System.Windows.Forms.ComboBox();
            this.cmb_workers = new System.Windows.Forms.ComboBox();
            this.Month = new System.Windows.Forms.Label();
            this.ddd = new System.Windows.Forms.Label();
            this.fff = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.btn_exportToExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grid_data_report)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_data_report.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // grid_data_report
            // 
            this.grid_data_report.Location = new System.Drawing.Point(-4, 105);
            // 
            // 
            // 
            this.grid_data_report.MasterTemplate.AllowColumnReorder = false;
            this.grid_data_report.MasterTemplate.GroupDescriptors.AddRange(new Telerik.WinControls.Data.GroupDescriptor[] {
            groupDescriptor1});
            this.grid_data_report.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grid_data_report.Name = "grid_data_report";
            this.grid_data_report.Size = new System.Drawing.Size(1022, 453);
            this.grid_data_report.TabIndex = 0;
            // 
            // cmb_month
            // 
            this.cmb_month.FormattingEnabled = true;
            this.cmb_month.Items.AddRange(new object[] {
            "January",
            "Fabruary",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.cmb_month.Location = new System.Drawing.Point(73, 38);
            this.cmb_month.Name = "cmb_month";
            this.cmb_month.Size = new System.Drawing.Size(121, 21);
            this.cmb_month.TabIndex = 1;
            this.cmb_month.SelectedIndexChanged += new System.EventHandler(this.cmb_SelectedIndexChanged);
            // 
            // cmb_teamHeads
            // 
            this.cmb_teamHeads.FormattingEnabled = true;
            this.cmb_teamHeads.Location = new System.Drawing.Point(266, 38);
            this.cmb_teamHeads.Name = "cmb_teamHeads";
            this.cmb_teamHeads.Size = new System.Drawing.Size(121, 21);
            this.cmb_teamHeads.TabIndex = 2;
            this.cmb_teamHeads.SelectedIndexChanged += new System.EventHandler(this.cmb_SelectedIndexChanged);
            // 
            // cmb_projects
            // 
            this.cmb_projects.FormattingEnabled = true;
            this.cmb_projects.Location = new System.Drawing.Point(474, 38);
            this.cmb_projects.Name = "cmb_projects";
            this.cmb_projects.Size = new System.Drawing.Size(121, 21);
            this.cmb_projects.TabIndex = 3;
            this.cmb_projects.SelectedIndexChanged += new System.EventHandler(this.cmb_SelectedIndexChanged);
            // 
            // cmb_workers
            // 
            this.cmb_workers.FormattingEnabled = true;
            this.cmb_workers.Location = new System.Drawing.Point(705, 38);
            this.cmb_workers.Name = "cmb_workers";
            this.cmb_workers.Size = new System.Drawing.Size(121, 21);
            this.cmb_workers.TabIndex = 4;
            this.cmb_workers.SelectedIndexChanged += new System.EventHandler(this.cmb_SelectedIndexChanged);
            // 
            // Month
            // 
            this.Month.AutoSize = true;
            this.Month.Location = new System.Drawing.Point(32, 41);
            this.Month.Name = "Month";
            this.Month.Size = new System.Drawing.Size(40, 13);
            this.Month.TabIndex = 5;
            this.Month.Text = "Month:";
            // 
            // ddd
            // 
            this.ddd.AutoSize = true;
            this.ddd.Location = new System.Drawing.Point(659, 41);
            this.ddd.Name = "ddd";
            this.ddd.Size = new System.Drawing.Size(45, 13);
            this.ddd.TabIndex = 6;
            this.ddd.Text = "Worker:";
            // 
            // fff
            // 
            this.fff.AutoSize = true;
            this.fff.Location = new System.Drawing.Point(428, 42);
            this.fff.Name = "fff";
            this.fff.Size = new System.Drawing.Size(43, 13);
            this.fff.TabIndex = 7;
            this.fff.Text = "Project:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(200, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Team head:";
            // 
            // btn_refresh
            // 
            this.btn_refresh.Location = new System.Drawing.Point(880, 32);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(107, 30);
            this.btn_refresh.TabIndex = 9;
            this.btn_refresh.Text = "Refresh";
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // btn_exportToExcel
            // 
            this.btn_exportToExcel.Location = new System.Drawing.Point(880, 69);
            this.btn_exportToExcel.Name = "btn_exportToExcel";
            this.btn_exportToExcel.Size = new System.Drawing.Size(107, 30);
            this.btn_exportToExcel.TabIndex = 10;
            this.btn_exportToExcel.Text = "Export to Excel";
            this.btn_exportToExcel.UseVisualStyleBackColor = true;
            this.btn_exportToExcel.Click += new System.EventHandler(this.btn_exportToExcel_Click);
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 560);
            this.Controls.Add(this.btn_exportToExcel);
            this.Controls.Add(this.btn_refresh);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.fff);
            this.Controls.Add(this.ddd);
            this.Controls.Add(this.Month);
            this.Controls.Add(this.cmb_workers);
            this.Controls.Add(this.cmb_projects);
            this.Controls.Add(this.cmb_teamHeads);
            this.Controls.Add(this.cmb_month);
            this.Controls.Add(this.grid_data_report);
            this.Name = "Report";
            this.Text = "Report";
            ((System.ComponentModel.ISupportInitialize)(this.grid_data_report.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_data_report)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView grid_data_report;
        private System.Windows.Forms.ComboBox cmb_month;
        private System.Windows.Forms.ComboBox cmb_teamHeads;
        private System.Windows.Forms.ComboBox cmb_projects;
        private System.Windows.Forms.ComboBox cmb_workers;
        private System.Windows.Forms.Label Month;
        private System.Windows.Forms.Label ddd;
        private System.Windows.Forms.Label fff;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.Button btn_exportToExcel;
    }
}