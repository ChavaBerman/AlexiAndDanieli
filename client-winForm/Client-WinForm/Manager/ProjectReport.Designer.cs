namespace Client_WinForm.Manager
{
    partial class ProjectReport
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.grid_project_report = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.grid_project_report)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_project_report.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // grid_project_report
            // 
            this.grid_project_report.Location = new System.Drawing.Point(96, 35);
            // 
            // 
            // 
            this.grid_project_report.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grid_project_report.Name = "grid_project_report";
            this.grid_project_report.Size = new System.Drawing.Size(609, 381);
            this.grid_project_report.TabIndex = 2;
            this.grid_project_report.TitleText = "Project Report";
            // 
            // ProjectReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grid_project_report);
            this.Name = "ProjectReport";
            this.Text = "ProjectReport";
            ((System.ComponentModel.ISupportInitialize)(this.grid_project_report.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_project_report)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView grid_project_report;
    }
}