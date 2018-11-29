using Client_WinForm.Models;
using MySql.Data.Types;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client_WinForm.Manager
{
    public partial class AddProject : Form
    {
        List<Models.Worker> addedWorkers = new List<Models.Worker>();
        List<Models.Task> tasksForAddedWorkers = new List<Models.Task>();
        List<Models.Worker> teamHeadWorkers = new List<Models.Worker>();
        

        public AddProject()
        {
            InitializeComponent();
            List<Models.Worker> teamHeads = new List<Models.Worker>();
            teamHeads = Requests.WorkerRequests.GetAllTeamHeads();
            cmb_TeamHeads.DataSource = teamHeads;
            cmb_TeamHeads.DisplayMember = "WorkerName";
            errorProvider.SetError(txt_projectName, "project name is required");
            errorProvider.SetError(txt_CustomerName, "customer name is required");
            btn_add_project.Enabled = false;
        }

        private void cmb_TeamHeads_SelectedIndexChanged(object sender, EventArgs e)
        {
            Added_Workers.Items.Clear();
            addedWorkers.Clear();
            List<Models.Worker> allowedWorkers = new List<Models.Worker>();
            allowedWorkers = Requests.WorkerRequests.GetAllowedWorkers(((sender as ComboBox).SelectedItem as Models.Worker).WorkerId);
            cmb_workers.DataSource = allowedWorkers;
            cmb_workers.DisplayMember = "WorkerName";
            teamHeadWorkers = Requests.WorkerRequests.GetWorkersByTeamhead(((sender as ComboBox).SelectedItem as Models.Worker).WorkerId);
        }

        private void cmb_workers_SelectedIndexChanged(object sender, EventArgs e)
        {

            Models.Worker worker = ((sender as ComboBox).SelectedItem as Models.Worker);
            if (addedWorkers.Find(p => p.WorkerId == worker.WorkerId) == null)
            {
                addedWorkers.Add(worker);
                Added_Workers.Items.Add(worker.WorkerName);

            }
        }


        private void Added_Workers_SelectedIndexChanged(object sender, EventArgs e)
        {

            foreach (ListViewItem item in Added_Workers.SelectedItems)
            {
                addedWorkers.RemoveAt(Added_Workers.Items.IndexOf(item));
                Added_Workers.Items.Remove(item);

            }
        }

        private void btn_add_project_Click(object sender, EventArgs e)
        {

            addedWorkers.AddRange(teamHeadWorkers);
            foreach (Models.Worker worker in addedWorkers)
            {
                int reservingHours = 0;
                while (reservingHours == 0)
                {
                    try
                    {
                        reservingHours = int.Parse(Microsoft.VisualBasic.Interaction.InputBox("enter num of reserving hours for " + worker.WorkerName, "Reserving hours", "1"));
                        tasksForAddedWorkers.Add(new Models.Task { ReservingHours = reservingHours, IdWorker = worker.WorkerId });
                    }
                    catch
                    {
                        MessageBox.Show("enter number only");
                    }
                }


            }

            Project newProject = new Project
            {
                ProjectName = txt_projectName.Text,
                CustomerName = txt_CustomerName.Text,
                IdTeamHead = ((cmb_TeamHeads as ComboBox).SelectedItem as Models.Worker).WorkerId,
                workers = addedWorkers,
                tasks= tasksForAddedWorkers,
                DevHours = DevHours.Value,
                UIUXHours = UIUXHours.Value,
                QAHours = QAHours.Value,
                DateBegin = date_begin.Value,
                DateEnd = date_end.Value
            };

            var validationContext = new ValidationContext(newProject, null, null);
            var results = new List<ValidationResult>();

            if (Validator.TryValidateObject(newProject, validationContext, results, true))
            {
                if (Requests.ProjectRequests.AddProject(newProject))
                {
                    Close();
                }
            }
            else
            {
                MessageBox.Show(string.Join(",\n", results.Select(p => p.ErrorMessage)));

            }

        }

        private void textChanged(object sender, EventArgs e)
        {
            bool validControl = true;
            if ((sender as TextBox).Text.Length < 2 || (sender as TextBox).Text.Length > 15)
            {
                errorProvider.SetError(sender as TextBox, "must contain 2-15 chars");
                validControl = false;
            }
            if((sender as TextBox).Text.Contains("'"))
            {
                errorProvider.SetError(sender as TextBox, "must contain 2-15 chars");
                validControl = false;
            }
            if (validControl)
                errorProvider.SetError(sender as TextBox, "");
            if (errorProvider.GetError(txt_CustomerName) == "" && errorProvider.GetError(txt_projectName) == "")
                btn_add_project.Enabled = true;
            else btn_add_project.Enabled = false;

        }
    }
}
