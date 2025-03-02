﻿using Client_WinForm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client_WinForm.Worker
{
    public partial class MyTasks : Form
    {

        public MyTasks(Models.Worker worker)
        {
            InitializeComponent();
            dataGridView1.DataSource = Requests.TaskRequests.GetAllTasksByWorkerId(worker.WorkerId).Select(p=>new { p.projectName,p.ReservingHours,p.GivenHours}).ToList();
        }
    }
}
