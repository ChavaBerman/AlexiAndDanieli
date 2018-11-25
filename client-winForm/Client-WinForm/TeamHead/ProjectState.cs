using Client_WinForm.Models;
using Client_WinForm.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client_WinForm.TeamHead
{
    public partial class ProjectState : Form
    {
        List<Project> CurrentProjects = new List<Project>();
        public ProjectState(User Teamhead)
        {
            InitializeComponent();
            CurrentProjects= ProjectRequests.GetAllProjectsByTeamHead(Teamhead.UserId);
            cmb_workers.DataSource = CurrentProjects;
            cmb_workers.DisplayMember = "ProjectName";
            chart1.Series[0].ChartType =System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
        }

        private void cmb_workers_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Models.Task> currentTasks = new List<Models.Task>();
            int projectId = ((sender as ComboBox).SelectedItem as Project).ProjectId;
            currentTasks=Requests.TaskRequests.GetAllTasksByProjectId(projectId);
            dataGridView1.DataSource = currentTasks.Select(p => new { p.userName, p.ReservingHours, p.GivenHours }).ToList();
            decimal precents = ProjectRequests.GetAllProjectState(projectId);

            chart1.Series[0].Points.DataBindXY(new string[] { "Done: "+precents+"%","Todo "+(100-precents)+"%"}, new decimal[] { precents,100-precents});


        }
    }
}
