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
        List<User> addedUsers = new List<User>();
        List<Models.Task> tasksForAddedWorkers = new List<Models.Task>();
        List<User> teamHeadWorkers = new List<User>();
        public AddProject()
        {
            InitializeComponent();
            List<User> teamHeads = new List<User>();
            teamHeads = Requests.UserRequests.GetAllTeamHeads();
            cmb_TeamHeads.DataSource = teamHeads;
            cmb_TeamHeads.DisplayMember = "userName";
        }

        private void cmb_TeamHeads_SelectedIndexChanged(object sender, EventArgs e)
        {
            Added_Workers.Items.Clear();
            addedUsers.Clear();
            List<User> allowedWorkers = new List<User>();
            allowedWorkers = Requests.UserRequests.GetAllowedWorkers(((sender as ComboBox).SelectedItem as User).UserId);
            cmb_workers.DataSource = allowedWorkers;
            cmb_workers.DisplayMember = "userName";
            teamHeadWorkers = Requests.UserRequests.GetWorkersByTeamhead(((sender as ComboBox).SelectedItem as User).UserId);
        }

        private void cmb_workers_SelectedIndexChanged(object sender, EventArgs e)
        {

            User user = ((sender as ComboBox).SelectedItem as User);
            if (addedUsers.Find(p => p.UserId == user.UserId) == null)
            {
                addedUsers.Add(user);
                Added_Workers.Items.Add(user.UserName);

            }
        }


        private void Added_Workers_SelectedIndexChanged(object sender, EventArgs e)
        {

            foreach (ListViewItem item in Added_Workers.SelectedItems)
            {
                addedUsers.RemoveAt(Added_Workers.Items.IndexOf(item));
                Added_Workers.Items.Remove(item);

            }
        }

        private void btn_add_project_Click(object sender, EventArgs e)
        {

            addedUsers.AddRange(teamHeadWorkers);
            foreach (User worker in addedUsers)
            {
                int reservingHours = 0;
                while (reservingHours == 0)
                {
                    try
                    {
                        reservingHours = int.Parse(Microsoft.VisualBasic.Interaction.InputBox("enter num of reserving hours for " + worker.UserName, "Reserving hours", "1"));
                        tasksForAddedWorkers.Add(new Models.Task { ReservingHours = reservingHours, IdUser = worker.UserId });
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
                IdManager = ((cmb_TeamHeads as ComboBox).SelectedItem as User).UserId,
                workers = addedUsers,
                tasks=tasksForAddedWorkers,
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

                    MessageBox.Show("added successfully");
                    Close();
                }
                //Printing the matching error
                else MessageBox.Show("failed to add");
            }
            else
            {
                MessageBox.Show(string.Join(",\n", results.Select(p => p.ErrorMessage)));

            }

        }
    }
}
