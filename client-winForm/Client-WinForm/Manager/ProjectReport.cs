using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace Client_WinForm.Manager
{
    public partial class ProjectReport : Form
    {
        public ProjectReport()
        {
            InitializeComponent();
            List<ProjectReport> mm = new List<ProjectReport>();
            mm=Requests.ReportsRequests.CreateProjectReport();
            this.grid_project_report.Relations.AddSelfReference(this.grid_project_report.MasterTemplate, "Id", "ParentId");
            this.grid_project_report.DataSource = mm;
            this.grid_project_report.Columns["Id"].IsVisible = false;
            this.grid_project_report.Columns["ParentId"].IsVisible = false;
        }


   

     
    }
}
