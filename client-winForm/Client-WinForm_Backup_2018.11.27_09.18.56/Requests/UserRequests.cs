using Client_WinForm.HelpModel;
using Client_WinForm.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Client_WinForm.Requests
{
    class UserRequests
    {
        public static List<User> GetAllUsers()
        {
            List<User> allUsers = new List<User>();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(@"http://localhost:61309/api/Users/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("GetAllUsers").Result;
            if (response.IsSuccessStatusCode)
            {
                var usersJson = response.Content.ReadAsStringAsync().Result;
                allUsers = JsonConvert.DeserializeObject<List<User>>(usersJson);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            return allUsers;
        }
        public static dynamic GetIp()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(@"https://api.ipify.org/?format=json");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("").Result;
            dynamic result=null;
            if (response.IsSuccessStatusCode)
            {
                var usersJson = response.Content.ReadAsStringAsync().Result;
                result = JsonConvert.DeserializeObject<dynamic>(usersJson);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            return result["ip"];
        }

        public static List<User> GetAllWorkers()
        {
            List<User> allWorkers = new List<User>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(@"http://localhost:61309/api/Users/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("GetAllWorkers").Result;
            if (response.IsSuccessStatusCode)
            {
                var usersJson = response.Content.ReadAsStringAsync().Result;
                allWorkers = JsonConvert.DeserializeObject<List<User>>(usersJson);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            return allWorkers;
        }
        public static User LoginByPassword(LoginUser loginUser)
        {
            User user = new User();
            try
            {
                //Post Request for Login
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(@"http://localhost:61309/api/Users/LoginByPassword");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string userStr = JsonConvert.SerializeObject(loginUser, Formatting.None);

                    streamWriter.Write(userStr);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                //Gettting response
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                //Reading response
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream(), ASCIIEncoding.ASCII))
                {
                    string result = streamReader.ReadToEnd();
                    //If Login succeeded
                    if (httpResponse.StatusCode == HttpStatusCode.Created)
                    {

                        dynamic obj = JsonConvert.DeserializeObject(result);
                        return JsonConvert.DeserializeObject<User>(JsonConvert.SerializeObject(obj));
                    }
                }
            }
            catch
            {
                return null;
            }
            return null;
        }
        public static User LoginByComputerUser()
        {
            try
            {
                //Post Request for Login
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(@"http://localhost:61309/api/Users/LoginByComputerUser");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string ip = GetIp();
                    string computerUser = JsonConvert.SerializeObject(new ComputerLogin { ComputerIp = ip }, Formatting.None);

                    streamWriter.Write(computerUser);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                //Gettting response
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                //Reading response
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream(), ASCIIEncoding.ASCII))
                {
                    string result = streamReader.ReadToEnd();
                    //If Login succeeded
                    if (httpResponse.StatusCode == HttpStatusCode.Created)
                    {

                        dynamic obj = JsonConvert.DeserializeObject(result);
                        return JsonConvert.DeserializeObject<User>(JsonConvert.SerializeObject(obj));
                        
                    }
                    //Printing the matching error
                    else return null;
                }
            }
            catch 
            {
                return null;

            }
        }
        public static List<User> GetWorkersByTeamhead(int id)
        {
            List<User> allWorkers = new List<User>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(@"http://localhost:61309/api/Users/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync($"GetWorkersByTeamhead/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                var usersJson = response.Content.ReadAsStringAsync().Result;
                allWorkers = JsonConvert.DeserializeObject<List<User>>(usersJson);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            return allWorkers;
        }
        public static Dictionary<string, Hours> GetWorkersDictionary(int projectId)
        {
            Dictionary<string, Hours> allWorkers = new Dictionary<string, Hours>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(@"http://localhost:61309/api/Tasks/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync($"GetWorkersDictionary/{projectId}").Result;
            if (response.IsSuccessStatusCode)
            {
                var usersJson = response.Content.ReadAsStringAsync().Result;
                allWorkers = JsonConvert.DeserializeObject<Dictionary<string, Hours>>(usersJson);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            return allWorkers;
        }
        
        public static List<User> GetAllTeamHeads()
        {
            List<User> teamHeads = new List<User>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(@"http://localhost:61309/api/Users/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("GetAllTeamHeads").Result;
            if (response.IsSuccessStatusCode)
            {
                var usersJson = response.Content.ReadAsStringAsync().Result;
                teamHeads = JsonConvert.DeserializeObject<List<User>>(usersJson);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            return teamHeads;
        }

        public static List<User> GetAllowedWorkers(int workerId)
        {
            List<User> allowedWorkers = new List<User>();
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(@"http://localhost:61309/api/Users/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync($"GetAllowedWorkers/{workerId}").Result;
            if (response.IsSuccessStatusCode)
            {
                var usersJson = response.Content.ReadAsStringAsync().Result;
                allowedWorkers = JsonConvert.DeserializeObject<List<User>>(usersJson);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            return allowedWorkers;
        }
        public static bool UpdateUser(User user)
        {
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create($@"http://localhost:61309/api/Users");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "PUT";
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    dynamic currentUser = user;
                    string currentUserNameString = Newtonsoft.Json.JsonConvert.SerializeObject(currentUser, Formatting.None);
                    streamWriter.Write(currentUserNameString);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                //Get response
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                //Read response
                using (var streamReaderPUT = new StreamReader(httpResponse.GetResponseStream(), ASCIIEncoding.ASCII))
                {
                    string resultPUT = streamReaderPUT.ReadToEnd();
                    //If request succeeded
                    if (httpResponse.StatusCode == HttpStatusCode.OK)
                    {
                        return true;

                    }
                    //Print the matching error
                    else return false;

                }
            }
            catch (Exception exception)
            {
                return false;
            }
        }

        public static bool sendMessageToManager(int idUser,string message, string subject)
        {
            EmailParams emailParams = new EmailParams { idUser = idUser, message = message, subject = subject };
            try
            {
                //Post Request for Register
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(@"http://localhost:61309/api/Users/sendMessageToManager");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string emailInfo = JsonConvert.SerializeObject(emailParams, Formatting.None);

                    streamWriter.Write(emailInfo);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                //Gettting response
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                //Reading response
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream(), ASCIIEncoding.ASCII))
                {
                    string result = streamReader.ReadToEnd();
                    //If Register succeeded
                    if (httpResponse.StatusCode == HttpStatusCode.OK)
                    {



                        return true;
                    }
                    //Printing the matching error
 else return false;
                }
            }
            catch (Exception exception)
            {
                return false;

            }
            
          
        }

        public static bool DeleteUser(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:61309/");
                HttpResponseMessage response = client.DeleteAsync($"api/Users/{id}").Result;
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                    return false;
            }
            
        }

        public static bool AddUser(User Newuser)
        {
            try
            {
                //Post Request for Register
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(@"http://localhost:61309/api/Users/addUser");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string user = JsonConvert.SerializeObject(Newuser, Formatting.None);

                    streamWriter.Write(user);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                //Gettting response
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                //Reading response
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream(), ASCIIEncoding.ASCII))
                {
                    string result = streamReader.ReadToEnd();
                    //If Register succeeded
                    if (httpResponse.StatusCode == HttpStatusCode.Created)
                    {


                        return true;
                    }
                    //Printing the matching error
                    
                }
            }
            catch (Exception exception)
            {
                System.Windows.Forms.MessageBox.Show("failed to add");

            }
            return false;
        }


    }
}
