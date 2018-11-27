using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;
using Client_WinForm.Models;
using System.Windows.Forms;
using Client_WinForm.TeamHead;
using Client_WinForm.HelpModel;

namespace Client_WinForm
{
    public partial class Welcome : Form
    {
        public Welcome()
        {
            IsMdiContainer = true;
            User user = Requests.UserRequests.LoginByComputerUser();
            if (user != null)
            {
                switch (user.statusObj.StatusName)
                {
                    case "Manager":
                        Manager.ManagerMainScreen managerMainScreen = new Manager.ManagerMainScreen(user);

                        managerMainScreen.Show();
                        break;
                    case "TeamHead":
                        TeamHeadScreen TeamHeadScreen = new TeamHeadScreen(user);

                        TeamHeadScreen.Show();
                        break;

                    default:
                        WorkerScreen workerScreen = new WorkerScreen(user);

                        workerScreen.Show();
                        break;

                }
            }
            else
            {
                ManagementTaskLogin managementTaskLogin = new ManagementTaskLogin();
                managementTaskLogin.MdiParent = this;
                managementTaskLogin.Show();

            }


            InitializeComponent();
        }

    }
}
