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

            LoginUser loginUser = new LoginUser { UserName = txt_userName.Text, Password = LoginUser.sha256_hash(txt_password.Text) };
            var validationContext = new ValidationContext(loginUser, null, null);
            var results = new List<ValidationResult>();
            User user = new User();

            if (Validator.TryValidateObject(loginUser, validationContext, results, true))
            {

                user = Requests.UserRequests.LoginByPassword(loginUser);
                if (user != null)
                {
                    if (cb_rememberUser.Checked)
                    {
                        user.UserComputer = Requests.UserRequests.GetIp();
                        if (!Requests.UserRequests.UpdateUser(user))
                            MessageBox.Show("this computer already registred to another user");
                    }

                    switch (user.statusObj.StatusName)
                    {
                        case "Manager":
                            Manager.ManagerMainScreen managerMainScreen = new Manager.ManagerMainScreen(user);
                            managerMainScreen.Show();
                            Close();
                            break;
                        case "TeamHead":
                            TeamHeadScreen TeamHeadScreen = new TeamHeadScreen(user);
                            TeamHeadScreen.Show();
                            Close();
                            break;

                        default:
                            WorkerScreen workerScreen = new WorkerScreen(user);
                            workerScreen.Show();
                            Close();
                            break;

                    }
                }
                else MessageBox.Show("can not login with these details");
            }
            else MessageBox.Show(string.Join(",\n", results.Select(p => p.ErrorMessage)));


        }

    }



}



