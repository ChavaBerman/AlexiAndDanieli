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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace memoryGame
{
    public partial class SignIn : Form
    {
        static HttpClient client = new HttpClient();
        public SignIn()
        {
            InitializeComponent();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            dynamic credential;
            try
            {

                int userAge = int.Parse(age.Text);

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(@"http://localhost:57034/Login");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {


                    credential = new User { UserName = name.Text, Age = int.Parse(age.Text) };
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
                        ChoosePartner choosePartner = new ChoosePartner();
                        choosePartner.Show();
                        GlobalProp.CurrentUser = credential;
                    }
                    else MessageBox.Show(result);

                }
            }
            catch
            {
                MessageBox.Show("Age must be a number!");
            }

        }
    }
}



