using Client_WinForm.Models;
using GemBox.Spreadsheet;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.Data;
using Telerik.WinControls.Export;
using Telerik.WinControls.UI;

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
            if (isStarted) { 
            int requiredMonth = cmb_month.SelectedIndex + 1;
            string projectName = cmb_projects.SelectedIndex > -1 ? (cmb_projects.SelectedItem as Project).ProjectName : "ok";
            string workerName = cmb_workers.SelectedIndex > -1 ? (cmb_workers.SelectedItem as User).UserName : "ok";
            string teamHeadName = cmb_teamHeads.SelectedIndex > -1 ?( cmb_teamHeads.SelectedItem as User).UserName : "ok";
            reportDataList = Requests.ReportsRequests.FilterReport(requiredMonth, projectName, teamHeadName, workerName);
            grid_data_report.DataSource = reportDataList;
            grid_data_report.Columns["Id"].IsVisible = false;
            grid_data_report.Columns["ParentId"].IsVisible = false;}

          
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            cmb_projects.SelectedIndex = -1;
            cmb_teamHeads.SelectedIndex = -1;
            cmb_workers.SelectedIndex = -1;
            cmb_month.SelectedIndex = -1;
        }

        private void btn_exportToExcel_Click(object sender, EventArgs e)
        {
            
                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(ReportData));
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
                ExcelFile file = new ExcelFile();
                ExcelWorksheet sheet = file.Worksheets.Add("Exported List");

                for (int i = 0; i < properties.Count; i++)
                    sheet.Cells[0, i].Value = properties[i].Name;

                for (int i = 0; i < reportDataList.Count; i++)
                    for (int j = 0; j < properties.Count; j++)
                        sheet.Cells[i + 1, j].Value = properties[j].GetValue(reportDataList[i]);

                file.Save(@"S:\תמי פרישמן\סתם", SaveOptions.XlsxDefault);




        }
    }
}
