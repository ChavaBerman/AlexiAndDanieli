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
using System.Windows;

namespace Client_WinForm.Requests
{
   public class TaskRequests
    {
        public static bool AddTask(Task newTask)
        {
                //Post Request for Add Task
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(@"http://localhost:61309/api/Tasks/AddTask");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string task = JsonConvert.SerializeObject(newTask, Formatting.None);

                    streamWriter.Write(task);
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
                        //If Adding Task succeeded
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

        public static List<Task> GetAllTasksByProjectId(int projectId)
        {
            List<Task> allTasks = new List<Task>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(@"http://localhost:61309/api/Tasks/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync($"GetTasksWithWorkerAndProjectByProjectId/{projectId}").Result;
            if (response.IsSuccessStatusCode)
            {
                var tasksJson = response.Content.ReadAsStringAsync().Result;
                allTasks = JsonConvert.DeserializeObject<List<Task>>(tasksJson);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            return allTasks;
        }

        public static List<Task> GetAllTasksByWorkerId(int workerId)
        {
            List<Task> allTasks = new List<Task>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(@"http://localhost:61309/api/Tasks/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync($"GetTasksWithWorkerAndProjectByWorkerId/{workerId}").Result;
            if (response.IsSuccessStatusCode)
            {
                var tasksJson = response.Content.ReadAsStringAsync().Result;
                allTasks = JsonConvert.DeserializeObject<List<Task>>(tasksJson);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            return allTasks;
        }

        public static bool UpdateTask(Task task)
        {
            
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create($@"http://localhost:61309/api/Tasks/UpdateTask");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "PUT";
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    dynamic currentTask = task;
                    string currentWorkerNameString = Newtonsoft.Json.JsonConvert.SerializeObject(currentTask, Formatting.None);
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
                    //If Update Task succeeded
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

        public static Dictionary<string, Hours> GetWorkerTasksDictionary(int workerId)
        {
            Dictionary<string, Hours> allTasks = new Dictionary<string, Hours>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(@"http://localhost:61309/api/Tasks/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync($"GetWorkerTasksDictionary/{workerId}").Result;
            if (response.IsSuccessStatusCode)
            {
                var infoJson = response.Content.ReadAsStringAsync().Result;
                allTasks = JsonConvert.DeserializeObject<Dictionary<string, Hours>>(infoJson);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            return allTasks;
        }
    }
}
