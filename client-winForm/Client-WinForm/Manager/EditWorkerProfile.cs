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

            cmb_managerName.DataSource = new List<Models.Worker>();
            cmb_managerName.DataSource = WorkerRequests.GetAllTeamHeads();
            cmb_managerName.DisplayMember = "WorkerName";

            cmb_workers.DataSource = new List<Models.Worker>();
            cmb_workers.DataSource = WorkerRequests.GetWorkers();
            cmb_workers.DisplayMember = "WorkerName";
        }
        private void cmb_workers_SelectedIndexChanged(object sender, EventArgs e)
        {
            Models.Worker currentWorker = ((sender as ComboBox).SelectedItem as Models.Worker);
            foreach (var cbi in cmb_managerName.Items)
            {
                if ((cbi as Models.Worker).WorkerId == currentWorker.ManagerId)
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
            Models.Worker worker = cmb_workers.SelectedItem as Models.Worker;
            worker.ManagerId = (cmb_managerName.SelectedItem as Models.Worker).WorkerId;
            worker.StatusId = (cmb_department.SelectedItem as Status).Id;
            if (WorkerRequests.UpdateWorker(worker))
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
                int id = (cmb_workers.SelectedItem as Models.Worker).WorkerId;
                if (WorkerRequests.DeleteWorker(id))
                    MessageBox.Show("Deleted!");
                else MessageBox.Show("Did not succeed to ");
                updateForm();
            }
        }
    }
}
