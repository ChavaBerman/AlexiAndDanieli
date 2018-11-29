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
using ClosedXML.Excel;
using Telerik.Windows.Documents.Spreadsheet.Model;

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
            cmb_teamHeads.DataSource = Requests.WorkerRequests.GetAllTeamHeads();
            cmb_teamHeads.DisplayMember = "WorkerName";
            cmb_teamHeads.SelectedIndex = -1;
            cmb_workers.DataSource = Requests.WorkerRequests.GetWorkers();
            cmb_workers.DisplayMember = "WorkerName";
            cmb_workers.SelectedIndex = -1;
            isStarted = true;
        }

        private void cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isStarted)
            {
                int requiredMonth = cmb_month.SelectedIndex + 1;
                string projectName = cmb_projects.SelectedIndex > -1 ? (cmb_projects.SelectedItem as Project).ProjectName : "ok";
                string workerName = cmb_workers.SelectedIndex > -1 ? (cmb_workers.SelectedItem as Models.Worker).WorkerName : "ok";
                string teamHeadName = cmb_teamHeads.SelectedIndex > -1 ? (cmb_teamHeads.SelectedItem as Models.Worker).WorkerName : "ok";
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


        private void RunExportToExcelML(string folderPath, bool openExportFile)
        {

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                folderPath = folderBrowserDialog1.SelectedPath;
            //Creating DataTable
            System.Data.DataTable dt = new System.Data.DataTable();
  dt.Columns.Add("Project/Worker", typeof(string));
            //Adding the Columns
            foreach (var column in grid_data_report.Columns)
            {
              
                if (column.HeaderText != "ParentId" && column.HeaderText != "Id")
                    dt.Columns.Add(column.HeaderText, typeof(string));
            }

            //Adding the Rows
            foreach (var row in grid_data_report.Rows)
            {
                dt.Rows.Add();
                dt.Rows[dt.Rows.Count - 1][0] = row.Cells[1].Value.ToString() =="0"?  "Project": "Worker";
                for (int i = 2; i < row.Cells.Count; i++)
                {
                    dt.Rows[dt.Rows.Count - 1][i-1] = row.Cells[i].Value != null ? row.Cells[i].Value.ToString() : "";
                }
            }

            //Exporting to Excel
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "data");
                wb.SaveAs(folderPath + @"\ReportData.xlsx");
            }
        }

        private void grid_data_report_Click(object sender, EventArgs e)
        {

        }

        private void btn_exportToExcel_Click(object sender, EventArgs e)
        {
            RunExportToExcelML("C:\\Excel\\", true);
        }
    }

}
