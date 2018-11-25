using memoryGame.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using memoryGame.Models;

namespace memoryGame
{
    public partial class ChoosePartner : Form
    {

        List<User> users;
        string whoChose = "";
        public ChoosePartner()
        {
            users = GetUsersList();
            InitializeComponent();
        }

        private void ChoosePartner_Load(object sender, EventArgs e)
        {
            dataGridView_partnerList.DataSource = users.Select(c => new { c.UserName, c.Age }).ToList();
        }

        private void dataGridView_partnerList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            User partner = users[e.RowIndex];
            whoChose = GlobalProp.CurrentUser.UserName;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create($@"http://localhost:57034/ChoosePatner/{partner.UserName}");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "PUT";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {



                dynamic credential = GlobalProp.CurrentUser.UserName;
                string credentialString = Newtonsoft.Json.JsonConvert.SerializeObject(credential, Formatting.None);

                streamWriter.Write(credentialString);
                streamWriter.Flush();
                streamWriter.Close();


            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();


            using (var streamReader = new System.IO.StreamReader(httpResponse.GetResponseStream(), ASCIIEncoding.ASCII))
            {
                string result = streamReader.ReadToEnd();
                if (result.Contains("true"))
                {

                    StartGame startGame = new StartGame(partner);
                    startGame.Show();
                    Close();
                }
                else MessageBox.Show(result);

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            users = GetUsersList();
            dataGridView_partnerList.DataSource = users.Select(c => new { c.UserName, c.Age }).ToList();

            User user = GetUser(GlobalProp.CurrentUser.UserName);

            if (user.PartnerUserName != null)
            {
                GlobalProp.CurrentUser = user;


                User partner = GetUser(GlobalProp.CurrentUser.PartnerUserName);
                partner.PartnerUserName = user.UserName;
                if (whoChose != GlobalProp.CurrentUser.UserName)
                {
                    StartGame startGame = new StartGame(partner);
                    startGame.Show();
                    Close();
                }
            }

            

        }
    
          




        public List<User> GetUsersList()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(@"http://localhost:57034/");
            // Add an Accept header for JSON format.  
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // List all Names.  
            HttpResponseMessage response = client.GetAsync("GetUsers").Result;  // Blocking call!  
            if (response.IsSuccessStatusCode)
            {

                var usersJson = response.Content.ReadAsStringAsync().Result;
                users = JsonConvert.DeserializeObject<List<User>>(usersJson);



            }
            else
            {

                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            return users;
        }

        public User GetUser(string username)
        {
            User user = new User();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(@"http://localhost:57034/");
            // Add an Accept header for JSON format.  
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // List all Names.  
            HttpResponseMessage response = client.GetAsync($"GetCurrentUser/{username}").Result;  // Blocking call!  
            if (response.IsSuccessStatusCode)
            {

                var userJson = response.Content.ReadAsStringAsync().Result;
                user = JsonConvert.DeserializeObject<User>(userJson);

            }
            else
            {

                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            return user;
        }
    }

}
    
