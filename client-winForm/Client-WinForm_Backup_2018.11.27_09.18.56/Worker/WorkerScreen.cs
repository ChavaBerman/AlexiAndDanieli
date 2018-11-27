using Client_WinForm.Models;
using Client_WinForm.Requests;
using Client_WinForm.Worker;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client_WinForm
{
    public partial class WorkerScreen : Form
    {
        PresentDay presentDay=new PresentDay();
        User worker;
        Project currentProject;
        public WorkerScreen(User worker)
        {

            this.worker = worker;
            InitializeComponent();
            IsMdiContainer = true;
            btn_logout.Enabled = false;
            btn_login.Enabled = false;
            cmb_myProjects.DataSource = ProjectRequests.GetAllProjectsByWorker(worker.UserId);
            cmb_myProjects.DisplayMember = "ProjectName";
        }






        private void timer1_Tick(object sender, EventArgs e)
        {
            if (btn_login.Enabled == false)
                lbl_duration.Text =(DateTime.Now - presentDay.TimeBegin).ToString();
            
            txt_clock.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            presentDay = new PresentDay()
            {
                UserId = worker.UserId,
                ProjectId = currentProject.ProjectId,
                TimeBegin = DateTime.Parse(txt_clock.Text),


            };
            cmb_myProjects.Enabled = false;
            PresentDayRequests.AddPresent(presentDay);
            btn_login.Enabled = false;
            btn_logout.Enabled = true;
            
        }

        private void cmb_myProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentProject = ((sender as ComboBox).SelectedItem as Project);
            btn_login.Enabled = true;
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            lbl_duration.Text = "";
            if (!PresentDayRequests.UpdateDetailsByLogout())
                MessageBox.Show("didnt succeed");
            else
            {
                cmb_myProjects.Enabled = true;
                btn_login.Enabled = true;
                btn_logout.Enabled = false;

            }
        }

        private void logout_link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ManagementTaskLogin managementTaskLogin = new ManagementTaskLogin();
            managementTaskLogin.Show();
            if (btn_logout.Enabled == true)
                PresentDayRequests.UpdateDetailsByLogout();
            Close();
        }

        private void myTasksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyTasks myTasks = new MyTasks(worker);
            myTasks.MdiParent = this;
            myTasks.Show();
        }

        private void myHoursToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyHours myHours = new MyHours(worker);
            myHours.MdiParent = this;
            myHours.Show();
        }

        private void btn_apply_Click(object sender, EventArgs e)
        {
            
            ApplyToManager applyToManager = new ApplyToManager(worker);
            applyToManager.MdiParent = this;
            applyToManager.Show();
        }
    }
}
