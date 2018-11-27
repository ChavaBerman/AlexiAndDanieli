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

namespace Client_WinForm.Requests
{
   public class TaskRequests
    {
        public static string AddTask(Task newTask)
        {
            try
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
                //Gettting response
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                //Reading response
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream(), ASCIIEncoding.ASCII))
                {
                    string result = streamReader.ReadToEnd();
                    //If Register succeeded
                    if (httpResponse.StatusCode == HttpStatusCode.Created)
                    {
                        return "Added successfuly!";
                    }
                    //Printing the matching error
                    else return "Did not succeed to update.";
                }
            }
            catch (Exception exception)
            {

                if (exception.Message.Contains("302"))
                    return "Worker already exists in this project.";
                return "Did not succeed to update.";
            }
            
        }

        public static List<Task> GetAllTasksByProjectId(int projectId)
        {
            List<Task> allTasks = new List<Task>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(@"http://localhost:61309/api/Tasks/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync($"GetTasksWithUserAndProjectByProjectId/{projectId}").Result;
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

        public static List<Task> GetAllTasksByUserId(int userId)
        {
            List<Task> allTasks = new List<Task>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(@"http://localhost:61309/api/Tasks/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync($"GetTasksWithUserAndProjectByUserId/{userId}").Result;
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
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create($@"http://localhost:61309/api/Tasks/UpdateTask");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "PUT";
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    dynamic currentTask = task;
                    string currentUserNameString = Newtonsoft.Json.JsonConvert.SerializeObject(currentTask, Formatting.None);
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
