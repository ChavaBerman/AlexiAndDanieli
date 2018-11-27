using Client_WinForm.Models;
using GemBox.Spreadsheet;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.Data;

using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Export;

using NsExcel = Microsoft.Office.Interop.Excel;

namespace Client_WinForm.Manager
{
    public partial class Report : Form
    {
        bool isStarted = false;
        List<ReportData> reportDataList = new List<ReportData>();
        public Report()
        {
            InitializeComponent();
            reportDataList = Requests.ReportsRequests.CreateReport();
            grid_data_report.Relations.AddSelfReference(grid_data_report.MasterTemplate, "Id", "ParentId");
            grid_data_report.DataSource = reportDataList;
            grid_data_report.Columns["Id"].IsVisible = false;
            grid_data_report.Columns["ParentId"].IsVisible = false;
            cmb_projects.DataSource = Requests.ProjectRequests.GetAllProjects();
            cmb_projects.DisplayMember = "ProjectName";
            cmb_projects.SelectedIndex = -1;
            cmb_teamHeads.DataSource = Requests.UserRequests.GetAllTeamHeads();
            cmb_teamHeads.DisplayMember = "UserName";
            cmb_teamHeads.SelectedIndex = -1;
            cmb_workers.DataSource = Requests.UserRequests.GetAllWorkers();
            cmb_workers.DisplayMember = "UserName";
            cmb_workers.SelectedIndex = -1;
            isStarted = true;
        }

        private void cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isStarted)
            {
                int requiredMonth = cmb_month.SelectedIndex + 1;
                string projectName = cmb_projects.SelectedIndex > -1 ? (cmb_projects.SelectedItem as Project).ProjectName : "ok";
                string workerName = cmb_workers.SelectedIndex > -1 ? (cmb_workers.SelectedItem as User).UserName : "ok";
                string teamHeadName = cmb_teamHeads.SelectedIndex > -1 ? (cmb_teamHeads.SelectedItem as User).UserName : "ok";
                reportDataList = Requests.ReportsRequests.FilterReport(requiredMonth, projectName, teamHeadName, workerName);
                grid_data_report.DataSource = reportDataList;
                grid_data_report.Columns["Id"].IsVisible = false;
                grid_data_report.Columns["ParentId"].IsVisible = false;
            }


        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            cmb_projects.SelectedIndex = -1;
            cmb_teamHeads.SelectedIndex = -1;
            cmb_workers.SelectedIndex = -1;
            cmb_month.SelectedIndex = -1;
        }

  
            private void RunExportToExcelML(string fileName, ref bool openExportFile)
            {
                ExportToExcelML excelExporter = new
    ExportToExcelML(grid_data_report);


                //set export settings
                excelExporter.ExportVisualSettings = true;
                excelExporter.ExportHierarchy = true;
                excelExporter.HiddenColumnOption = HiddenOption.DoNotExport;

                try
                {
                    this.Cursor = Cursors.WaitCursor;

                    excelExporter.RunExport(fileName);
               DialogResult dr= MessageBox.Show("in the grid was exported successfully.Do you want to open the file ? ", "Export to Excel", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            
                    if (dr == DialogResult.Yes)
                    {
                        openExportFile = true;
                    }
                }
                catch (IOException ex)
                {
                    
                    MessageBox.Show(this, ex.Message, "I/O Error",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }
            }

            private void RunExportToCSV(string fileName, ref bool openExportFile)
            {
                ExportToCSV csvExporter = new ExportToCSV(grid_data_report);
                csvExporter.CSVCellFormatting += csvExporter_CSVCellFormatting;



                //set export settings
                csvExporter.ExportHierarchy = true;
                csvExporter.HiddenColumnOption = HiddenOption.DoNotExport;

                try
                {
                    this.Cursor = Cursors.WaitCursor;

                    csvExporter.RunExport(fileName);

                    
                    DialogResult dr = MessageBox.Show("The data in the grid was exported successfully.Do you want to open the file ? ",    "Export to CSV", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        openExportFile = true;
                    }
                }
                catch (IOException ex)
                {
                    RadMessageBox.SetThemeName(this.radGridView1.ThemeName);
                    RadMessageBox.Show(this, ex.Message, "I/O Error",
    MessageBoxButtons.OK, RadMessageIcon.Error);
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }
            }


        }
 
}
