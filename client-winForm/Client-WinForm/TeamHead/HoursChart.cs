using Client_WinForm.HelpModel;
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
    public partial class HoursChart : Form
    {
        public HoursChart(User teamHead)
        {
            
            InitializeComponent();
            cmb_projects.DataSource = ProjectRequests.GetAllProjectsByTeamHead(teamHead.UserId);
            cmb_projects.DisplayMember = "ProjectName";

            
        }

        private void cmb_projects_SelectedIndexChanged(object sender, EventArgs e)
        {
Dictionary<string, Hours> workersDictionary = new Dictionary<string, Hours>();
            workersDictionary = UserRequests.GetWorkersDictionary(((sender as ComboBox).SelectedItem as Project).ProjectId);
            List<decimal> givenList = workersDictionary.Values.Select(p => p.GivenHours).ToList();
            List<decimal> reservingList = workersDictionary.Values.Select(p => p.ReservingHours).ToList();
            chart1.Series[0].Points.DataBindXY(workersDictionary.Keys, givenList);
            chart1.Series[1].Points.DataBindXY(workersDictionary.Keys, reservingList);
        }
    }
}
