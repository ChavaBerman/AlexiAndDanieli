using Client_WinForm.Manager;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Client_WinForm.Requests
{
    class ReportsRequests
    {
        public static List<ProjectReport> CreateProjectReport()
        {
            List<ProjectReport> projectsReport = new List<ProjectReport>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(@"http://localhost:61309/api/Reports/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("GetProjectReportData").Result;
            if (response.IsSuccessStatusCode)
            {
                var projectReportJson = response.Content.ReadAsStringAsync().Result;
                projectsReport = JsonConvert.DeserializeObject<List<ProjectReport>>(projectReportJson);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            return projectsReport;
        }
        public static List<WorkerReport> CreateWorkerReport()
        {
            List<WorkerReport> workersReport = new List<WorkerReport>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(@"http://localhost:61309/api/Reports/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("GetWorkerReportData").Result;
            if (response.IsSuccessStatusCode)
            {
                var workerReportJson = response.Content.ReadAsStringAsync().Result;
               workersReport = JsonConvert.DeserializeObject<List<WorkerReport>>(workerReportJson);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            return workersReport;
        }
    }
}
