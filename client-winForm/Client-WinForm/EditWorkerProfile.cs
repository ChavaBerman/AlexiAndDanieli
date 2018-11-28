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
    public partial class EditWorkerProfile : Form
    {
        public EditWorkerProfile()
        {
            InitializeComponent();
            updateForm();



        }
        private void updateForm()
        {
            cmb_department.DataSource = new List<Status>();
            cmb_department.DataSource = StatusRequests.GetAllStatuses();
            cmb_department.DisplayMember = "StatusName";

            cmb_managerName.DataSource = new List<User>();
            cmb_managerName.DataSource = UserRequests.GetAllTeamHeads();
            cmb_managerName.DisplayMember = "userName";

            cmb_workers.DataSource = new List<User>();
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

            foreach (var cbi in cmb_department.Items)
            {
                if ((cbi as Status).Id == currentWorker.StatusId)
                {
                    cmb_department.SelectedItem = cbi;
                    break;
                }
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            User user = cmb_workers.SelectedItem as User;
            user.ManagerId = (cmb_managerName.SelectedItem as User).UserId;
            user.StatusId = (cmb_department.SelectedItem as Status).Id;
            if (UserRequests.UpdateUser(user))
            {
                MessageBox.Show("Succeeded!");
                Close();
            }
            else MessageBox.Show("Did not succeed...");

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure to delete this item ??",
                                    "Confirm Delete!!",
                                    MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                int id = (cmb_workers.SelectedItem as User).UserId;
                if (UserRequests.DeleteUser(id))
                    MessageBox.Show("Deleted!");
                else MessageBox.Show("Did not succeed to ");
                updateForm();
            }
        }
    }
}
