﻿using Client_WinForm.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client_WinForm.Requests;

namespace Client_WinForm.Manager
{
    public partial class SetPermission : Form
    {
        public SetPermission()
        {
            InitializeComponent();
        
            cmb_workers.DataSource = WorkerRequests.GetWorkers();
            cmb_workers.DisplayMember = "WorkerName";

            cmb_projects.DataSource = ProjectRequests.GetAllProjects();
            cmb_projects.DisplayMember = "ProjectName";

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            Models.Task newTask = new Models.Task
            {
                IdWorker = (cmb_workers.SelectedItem as Models.Worker).WorkerId,
                IdProject = (cmb_projects.SelectedItem as Project).ProjectId,
                GivenHours = num_hours.Value,
                ReservingHours = 0
            };
           TaskRequests.AddTask(newTask);
            
        }
    }
}
