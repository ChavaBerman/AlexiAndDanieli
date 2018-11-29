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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client_WinForm.Manager
{
    public partial class AddWorker : Form
    {

        Models.Worker manager = new Models.Worker();
        public AddWorker(Models.Worker manager)
        {
           this.manager= manager ; 
            InitializeComponent();
            List<Status> statuses = new List<Status>();
            statuses = Requests.StatusRequests.GetAllStatuses();
            cmb_department.DataSource = statuses;
            cmb_department.DisplayMember = "StatusName";
            txt_password.PasswordChar = '*';
            txt_confirmPassword.PasswordChar = '*';
            btn_addWorker.Enabled = false;
            errorProvider1.SetError(txt_userName, "user name is required");
            errorProvider1.SetError(txt_password, "password is required");
            errorProvider1.SetError(txt_confirmPassword, "confirm password is required");
            errorProvider1.SetError(txt_email, "email is required");
        }

        private void cmb_department_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_managerName.DataSource=null;
            if (((sender as ComboBox).SelectedItem as Status).StatusName!= "TeamHead")
            {
                List<Models.Worker> teamHeads = new List<Models.Worker>();
                teamHeads = Requests.WorkerRequests.GetAllTeamHeads();
                cmb_managerName.DataSource = teamHeads;
            }
            else
            {
                List<Models.Worker> managers = new List<Models.Worker>() { manager };
                cmb_managerName.DataSource = managers;

            }
            cmb_managerName.DisplayMember = "WorkerName";
        }

        private void btn_addWorker_Click(object sender, EventArgs e)
        {
            Models.Worker newWorker = new Models.Worker {
                WorkerName = txt_userName.Text,
                IsNewWorker=true,
                Password = LoginWorker.sha256_hash(txt_password.Text).ToUpper(),
                ConfirmPassword= txt_confirmPassword.Text,
                Email = txt_email.Text,
                ManagerId =(cmb_managerName.SelectedItem as Models.Worker).WorkerId,
                NumHoursWork=0,
                StatusId=(cmb_department.SelectedItem as Status).Id,
                
            };
            var validationContext = new ValidationContext(newWorker, null, null);
            var results = new List<ValidationResult>();

            if (Validator.TryValidateObject(newWorker, validationContext, results, true))
            {
               if( Requests.WorkerRequests.AddWorker(newWorker))
                    MessageBox.Show("was added susccessfully");
            }
            else
            {
                MessageBox.Show( string.Join(",\n", results.Select(p => p.ErrorMessage)));  
                
            }
        }

        private void txt_confirmPassword_TextChanged(object sender, EventArgs e)
        {
            if (txt_confirmPassword.Text != txt_password.Text)
                errorProvider1.SetError(txt_confirmPassword, "passwords dont match");
            else errorProvider1.SetError(txt_confirmPassword, "");
            EnableBtnClick();
        }

        private void txt_userName_TextChanged(object sender, EventArgs e)
        {
            bool validUserName = true;
            if (txt_userName.Text.Length < 2 || txt_userName.Text.Length > 15)
            {
                errorProvider1.SetError(txt_userName, "user name must contain between 2-15 charcters");
                validUserName = false;
            }
            //avoid sqlInjection
            if (txt_userName.Text.Contains("'"))
            {
                errorProvider1.SetError(txt_userName, "user name cant contain ' char");
                validUserName = false;
            }
            if (validUserName)
                errorProvider1.SetError(txt_userName,"");
            EnableBtnClick();
        }

        private void txt_password_TextChanged(object sender, EventArgs e)
        {
            if (txt_password.Text.Length != 6)
                errorProvider1.SetError(txt_password, "password length has to be  6 chars ");
            else errorProvider1.SetError(txt_password, "");
            EnableBtnClick();
        }

        private void txt_email_TextChanged(object sender, EventArgs e)
        {
            Regex reg = new Regex(@"^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,6}$", RegexOptions.IgnoreCase); ///Object initialization for Regex 
            if (!reg.IsMatch(txt_email.Text))
                errorProvider1.SetError(txt_email, "email is not in valid pattern");
            else errorProvider1.SetError(txt_email, "");
            EnableBtnClick();
        }

        private void EnableBtnClick()
        {
            if (errorProvider1.GetError(txt_userName) == "" && errorProvider1.GetError(txt_password) == "" && errorProvider1.GetError(txt_confirmPassword) == "" && errorProvider1.GetError(txt_email) == "")
                btn_addWorker.Enabled = true;
        }
    }
}
