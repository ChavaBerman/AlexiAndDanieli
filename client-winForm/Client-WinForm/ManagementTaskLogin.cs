using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

using System.Windows.Forms;
using Client_WinForm.Models;
using Client_WinForm.TeamHead;

namespace Client_WinForm
{
    public partial class ManagementTaskLogin : Form
    {
        public ManagementTaskLogin()
        {
            InitializeComponent();
            txt_password.PasswordChar = '*';

        }

        private void btn_enter_Click(object sender, EventArgs e)
        {

            LoginWorker loginWorker = new LoginWorker { WorkerName = txt_userName.Text, Password = LoginWorker.sha256_hash(txt_password.Text).ToUpper() };
            var validationContext = new ValidationContext(loginWorker, null, null);
            var results = new List<ValidationResult>();
            Models.Worker worker = new Models.Worker();

            if (Validator.TryValidateObject(loginWorker, validationContext, results, true))
            {

                worker = Requests.WorkerRequests.LoginByPassword(loginWorker);
                if (worker != null)
                {
                    if (cb_rememberUser.Checked)
                    {
                        worker.WorkerComputer = Requests.WorkerRequests.GetIp();
                        if (!Requests.WorkerRequests.UpdateWorker(worker))
                            MessageBox.Show("this computer already registred to another worker");
                    }

                    switch (worker.statusObj.StatusName)
                    {
                        case "Manager":
                            Manager.ManagerMainScreen managerMainScreen = new Manager.ManagerMainScreen(worker);
                            managerMainScreen.Show();
                            Close();
                            break;
                        case "TeamHead":
                            TeamHeadScreen TeamHeadScreen = new TeamHeadScreen(worker);
                            TeamHeadScreen.Show();
                            Close();
                            break;

                        default:
                            WorkerScreen workerScreen = new WorkerScreen(worker);
                            workerScreen.Show();
                            Close();
                            break;

                    }
                }
                
            }
            else MessageBox.Show(string.Join(",\n", results.Select(p => p.ErrorMessage)));


        }

        private void btn_forgot_password_Click(object sender, EventArgs e)
        {

        }
    }



}



