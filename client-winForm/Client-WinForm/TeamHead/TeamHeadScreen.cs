using Client_WinForm.Models;
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
    public partial class TeamHeadScreen : Form
    {
        User Teamhead;
        public TeamHeadScreen(User Teamhead)
        {
            this.Teamhead = Teamhead;
            InitializeComponent();
            IsMdiContainer = true;
        }

        private void hoursToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HoursChart hoursChart = new HoursChart(Teamhead);
            hoursChart.MdiParent = this;
            hoursChart.Show();
        }

        private void viewMyProjectsStateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProjectState projectState = new ProjectState(Teamhead);
            projectState.MdiParent = this;
            projectState.Show();
        }

        private void updateHoursToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateHours updateHours = new UpdateHours(Teamhead);
            updateHours.MdiParent = this;
            updateHours.Show();
        }

        private void logout_link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            
                ManagementTaskLogin managementTaskLogin = new ManagementTaskLogin();
                managementTaskLogin.Show();
                Close();

            
        }
    }
}
