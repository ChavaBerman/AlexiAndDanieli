﻿using Client_WinForm.Models;
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
using System.Windows;

namespace Client_WinForm.Requests
{
    class ProjectRequests
    {
        public static List<Project> GetAllProjects()
        {
            List<Project> allProjects = new List<Project>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(@"http://localhost:61309/api/Projects/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("GetAllProjects").Result;
            if (response.IsSuccessStatusCode)
            {
                var projectsJson = response.Content.ReadAsStringAsync().Result;
                allProjects = JsonConvert.DeserializeObject<List<Project>>(projectsJson);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            return allProjects;
        }

        public static List<Project> GetAllProjectsByTeamHead(int id)
        {
            List<Project> allProjects = new List<Project>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(@"http://localhost:61309/api/Projects/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync($"GetAllProjectsByTeamHead/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                var ProjectsJson = response.Content.ReadAsStringAsync().Result;
                allProjects = JsonConvert.DeserializeObject<List<Project>>(ProjectsJson);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            return allProjects;
        }
        public static List<Project> GetAllProjectsByWorker(int id)
        {
            List<Project> allProjects = new List<Project>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(@"http://localhost:61309/api/Projects/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync($"GetAllProjectsByWorker/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                var ProjectsJson = response.Content.ReadAsStringAsync().Result;
                allProjects = JsonConvert.DeserializeObject<List<Project>>(ProjectsJson);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            return allProjects;
        }
        public static decimal GetAllProjectState(int id)
        {
            decimal precents = -1;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(@"http://localhost:61309/api/Projects/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync($"GetProjectState/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                var precentsJson = response.Content.ReadAsStringAsync().Result;
                precents = JsonConvert.DeserializeObject<decimal>(precentsJson);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            return precents;
        }
        public static bool AddProject(Project newProject)
        {
            //Post Request for Register
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(@"http://localhost:61309/api/Projects/AddProject");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string project = JsonConvert.SerializeObject(newProject, Formatting.None);

                streamWriter.Write(project);
                streamWriter.Flush();
                streamWriter.Close();
            }
            //Get response
            try
            {
                //Gettting response
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                //Reading response
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream(), ASCIIEncoding.ASCII))
                {
                    string result = streamReader.ReadToEnd();
                    //If AddProject succeeded
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

                    //Printing the matchung errors:
                    MessageBox.Show(reader.ReadToEnd());
                }
                return false;
            }

        }
    }
}
