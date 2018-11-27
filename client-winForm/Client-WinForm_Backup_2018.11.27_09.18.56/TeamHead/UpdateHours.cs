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
    public partial class UpdateHours : Form
    {
     
        List<Models.Task> tasks = new List<Models.Task>();

        public UpdateHours(User teamHead)
        {
            InitializeComponent();
            cmb_workers.DataSource = UserRequests.GetWorkersByTeamhead(teamHead.UserId);
            cmb_workers.DisplayMember = "userName";




        }

        private void cmb_workers_SelectedIndexChanged(object sender, EventArgs e)
        {
            int userId = ((sender as ComboBox).SelectedItem as User).UserId;
            tasks = TaskRequests.GetAllTasksByUserId(userId);
            List<ShownTask> selectTask = new List<ShownTask>();
            foreach (Models.Task item in tasks)
            {
                selectTask.Add(new ShownTask { ProjectName = item.projectName,ReservingHours=item.ReservingHours });
            }
            dataGridView1.DataSource = selectTask;


        }

        private void btn_save_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                decimal reservingHours = (decimal)dataGridView1.Rows[e.RowIndex].Cells["ReservingHours"].Value;
                Models.Task task = tasks[e.RowIndex];
                task.ReservingHours = reservingHours;
             if(TaskRequests.UpdateTask(task))
                    MessageBox.Show("Updated!");
                else MessageBox.Show("Failed to update...");

            }
            catch
            {
                MessageBox.Show("Enter only numbers!");
            }



        }
    }
}
