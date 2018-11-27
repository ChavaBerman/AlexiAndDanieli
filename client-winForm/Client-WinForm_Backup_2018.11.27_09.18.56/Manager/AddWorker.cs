using Client_WinForm.Models;
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
    public partial class AddWorker : Form
    {
        
        User manager = new User();
        public AddWorker(User manager)
        {
           this.manager= manager ; 
            InitializeComponent();
            List<Status> statuses = new List<Status>();
            statuses = Requests.StatusRequests.GetAllStatuses();
            cmb_department.DataSource = statuses;
            cmb_department.DisplayMember = "StatusName";
        }

        private void cmb_department_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_managerName.DataSource=null;
            if (((sender as ComboBox).SelectedItem as Status).StatusName!= "TeamHead")
            {
                List<User> teamHeads = new List<User>();
                teamHeads = Requests.UserRequests.GetAllTeamHeads();
                cmb_managerName.DataSource = teamHeads;
            }
            else
            {
                List<User> managers = new List<User>() { manager };
                cmb_managerName.DataSource = managers;

            }
            cmb_managerName.DisplayMember = "UserName";
        }

        private void btn_addWorker_Click(object sender, EventArgs e)
        {
            User newUser = new User {
                UserName = txt_userName.Text,
                IsNewWorker=true,
                Password = LoginUser.sha256_hash(txt_password.Text),
                ConfirmPassword=txt_confirmPassword.Text,
                Email =txt_email.Text,
                ManagerId =(cmb_managerName.SelectedItem  as User).UserId,
                NumHoursWork=0,
                StatusId=(cmb_department.SelectedItem as Status).Id,
                
            };
            var validationContext = new ValidationContext(newUser, null, null);
            var results = new List<ValidationResult>();

            if (Validator.TryValidateObject(newUser, validationContext, results, true))
            {
               if( Requests.UserRequests.AddUser(newUser))
                    MessageBox.Show("was added susccessfully");
            }
            else
            {
                MessageBox.Show( string.Join(",\n", results.Select(p => p.ErrorMessage)));  
                
            }
        }
    }
}
