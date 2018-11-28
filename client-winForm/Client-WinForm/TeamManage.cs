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

namespace Client_WinForm.Manager
{
    public partial class TeamManage : Form
    {
        public TeamManage()
        {
            InitializeComponent();

            cmb_managerName.DataSource = UserRequests.GetAllTeamHeads();
            cmb_managerName.DisplayMember = "userName";

            cmb_workers.DataSource = UserRequests.GetAllWorkers();
            cmb_workers.DisplayMember = "userName";
        }

        private void cmb_workers_SelectedIndexChanged(object sender, EventArgs e)
        {
            User currentWorker = ((sender as ComboBox).SelectedItem as User);
            foreach (var cbi in cmb_managerName.Items)
            {
                if ((cbi as User).UserId == currentWorker.ManagerId)
                {
                    cmb_managerName.SelectedItem = cbi;
                    break;
                }
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            User user = cmb_workers.SelectedItem as User;
            user.ManagerId = (cmb_managerName.SelectedItem as User).UserId;
            if (UserRequests.UpdateUser(user))
            {
                MessageBox.Show("Succeeded!");
                Close();
            }
            else MessageBox.Show("Did not succeed...");
        }
    }
}
