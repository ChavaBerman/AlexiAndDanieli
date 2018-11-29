using Client_WinForm.HelpModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Windows;

namespace Client_WinForm.Requests
{
    class WorkerRequests
    {

        public static dynamic GetIp()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(@"https://api.ipify.org/?format=json");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("").Result;
            dynamic result = null;
            if (response.IsSuccessStatusCode)
            {
                var workersJson = response.Content.ReadAsStringAsync().Result;
                result = JsonConvert.DeserializeObject<dynamic>(workersJson);
            }
            return result["ip"];
        }

        public static List<Models.Worker> GetWorkers()
        {
            List<Models.Worker> allWorkers = new List<Models.Worker>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(@"http://localhost:61309/api/Workers/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("GetWorkers").Result;
            if (response.IsSuccessStatusCode)
            {
                var workersJson = response.Content.ReadAsStringAsync().Result;
                allWorkers = JsonConvert.DeserializeObject<List<Models.Worker>>(workersJson);
            }
            return allWorkers;
        }

        public static Models.Worker LoginByPassword(LoginWorker loginWorker)
        {
            Models.Worker worker = new Models.Worker();

            //Post Request for Login
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(@"http://localhost:61309/api/Workers/LoginByPassword");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string workerStr = JsonConvert.SerializeObject(loginWorker, Formatting.None);

                streamWriter.Write(workerStr);
                streamWriter.Flush();
                streamWriter.Close();
            }
            try
            {
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
                        return Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Worker>(Newtonsoft.Json.JsonConvert.SerializeObject(obj));
                    }

                    else return null;

                }
            }
            catch (WebException ex)
            {
                using (var stream = ex.Response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    //Printing the matching error
                    MessageBox.Show(reader.ReadToEnd());
                }
                return null;

            }

        }

        public static Models.Worker LoginByComputerWorker()
        {
            
                //Post Request for Login
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(@"http://localhost:61309/api/Workers/LoginByComputerWorker");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string ip = GetIp();
                    string computerWorkerStr = JsonConvert.SerializeObject(new ComputerLogin { ComputerIp = ip }, Formatting.None);

                    streamWriter.Write(computerWorkerStr);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
               
                try {
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
                            return Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Worker>(Newtonsoft.Json.JsonConvert.SerializeObject(obj));
                        }

                        else return null;

                    }
                }
                catch (WebException ex)
                {
                    using (var stream = ex.Response.GetResponseStream())
                    using (var reader = new StreamReader(stream))
                    {
                        //Printing the matching error
                        MessageBox.Show(reader.ReadToEnd());
                    }
                    return null;

                }  
        }

        public static List<Models.Worker> GetWorkersByTeamhead(int id)
        {
            List<Models.Worker> allWorkers = new List<Models.Worker>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(@"http://localhost:61309/api/Workers/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync($"GetWorkersByTeamhead/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                var workersJson = response.Content.ReadAsStringAsync().Result;
                allWorkers = JsonConvert.DeserializeObject<List<Models.Worker>>(workersJson);
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
                var workersJson = response.Content.ReadAsStringAsync().Result;
                allWorkers = JsonConvert.DeserializeObject<Dictionary<string, Hours>>(workersJson);
            }
            return allWorkers;
        }

        public static List<Models.Worker> GetAllTeamHeads()
        {
            List<Models.Worker> teamHeads = new List<Models.Worker>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(@"http://localhost:61309/api/Workers/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("GetAllTeamHeads").Result;
            if (response.IsSuccessStatusCode)
            {
                var workersJson = response.Content.ReadAsStringAsync().Result;
                teamHeads = JsonConvert.DeserializeObject<List<Models.Worker>>(workersJson);
            }
            return teamHeads;
        }

        public static List<Models.Worker> GetAllowedWorkers(int workerId)
        {
            List<Models.Worker> allowedWorkers = new List<Models.Worker>();
            //Get request for getting the alloed workers for project
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(@"http://localhost:61309/api/Workers/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync($"GetAllowedWorkers/{workerId}").Result;
            //If got the information
            if (response.IsSuccessStatusCode)
            {
                var workersJson = response.Content.ReadAsStringAsync().Result;
                allowedWorkers = JsonConvert.DeserializeObject<List<Models.Worker>>(workersJson);
            }
            return allowedWorkers;
        }

        public static bool UpdateWorker(Models.Worker worker)
        {
            
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create($@"http://localhost:61309/api/Workers/UpdateWorker");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "PUT";
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    dynamic currentWorker = worker;
                    string currentWorkerNameString = Newtonsoft.Json.JsonConvert.SerializeObject(currentWorker, Formatting.None);
                    streamWriter.Write(currentWorkerNameString);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
            try
            {
                //Gettting response
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                //Reading response
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream(), ASCIIEncoding.ASCII))
                {
                    string result = streamReader.ReadToEnd();
                    //If Update succeeded
                    if (httpResponse.StatusCode == HttpStatusCode.Created)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (WebException ex)
            {
                using (var stream = ex.Response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    //Printing the matching error
                    MessageBox.Show(reader.ReadToEnd());
                }
                return false;

            }
        }

        public static bool sendMessageToManager(int idWorker, string message, string subject)
        {
            EmailParams emailParams = new EmailParams { idWorker = idWorker, message = message, subject = subject };
            try
            {
                //Post Request for Sending email to manager
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(@"http://localhost:61309/api/Workers/SendMessageToManager");
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
                    //If Sending succeeded
                    if (httpResponse.StatusCode == HttpStatusCode.OK)
                    {
                        return true;
                    }
                    
                    else return false;
                }
            }
            catch 
            {
                return false;

            }


        }

        public static bool DeleteWorker(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:61309/api/Workers/");
                HttpResponseMessage response = client.DeleteAsync($"RemoveWorker/{id}").Result;
                //If Deleting Succeeded
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                
                    return false;
            }

        }

        public static bool AddWorker(Models.Worker newWorker)
        {
            
                //Post Request for Register
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(@"http://localhost:61309/api/Workers/AddWorker");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string workerJson = JsonConvert.SerializeObject(newWorker, Formatting.None);

                    streamWriter.Write(workerJson);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                try
                {
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

                        

                    }
                }
                catch (WebException ex)
                {
                    using (var stream = ex.Response.GetResponseStream())
                    using (var reader = new StreamReader(stream))
                    {
                    //Printing the matching error
                    MessageBox.Show(reader.ReadToEnd());
                    }
                    return false;

                }
                return false;


            





            }
}
    }
