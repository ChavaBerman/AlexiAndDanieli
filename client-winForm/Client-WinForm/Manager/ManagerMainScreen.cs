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

namespace Client_WinForm.Manager
{
    public partial class ManagerMainScreen : Form
    {
        User manager=new User();
        public ManagerMainScreen(User user)
        {
            manager = user;
            IsMdiContainer = true;
            InitializeComponent();
            Text = "Hello " + manager.UserName;
        }

        private void addProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddProject addProject = new AddProject();
            addProject.MdiParent = this;
            addProject.Show();
        }

        private void logout_link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ManagementTaskLogin managementTaskLogin = new ManagementTaskLogin();
            managementTaskLogin.Show();
            Close();

        }

      

        private void manageTeamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TeamManage teamManage = new TeamManage();
            teamManage.MdiParent = this;
            teamManage.Show();
        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddWorker addWorker = new AddWorker(manager);
            addWorker.MdiParent = this;
            addWorker.Show();
        }

        private void setPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetPermission setPermission = new SetPermission();
            setPermission.MdiParent = this;
            setPermission.Show();
        }

        private void editWorkerToolStripMenuItem_Click(object sender, EventArgs e)
        {

            EditWorkerProfile editWorkerProfile = new EditWorkerProfile();
            editWorkerProfile.MdiParent = this;
            editWorkerProfile.Show();
        }


        private void projectReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProjectReport projectReport = new ProjectReport();
            projectReport.MdiParent = this;
            projectReport.Show();
        }

        private void workerReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WorkerReport workerReport = new WorkerReport();
            workerReport.MdiParent = this;
            workerReport.Show();
        }

        private void monthReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MonthReport monthReport = new MonthReport();
            monthReport.MdiParent = this;
            monthReport.Show();
        }
    }
}
