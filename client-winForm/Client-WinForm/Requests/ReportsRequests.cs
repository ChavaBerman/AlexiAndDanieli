using Client_WinForm.Manager;
using Client_WinForm.Models;
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
        public static List<ReportData> CreateReport()
        {
            List<ReportData> ReportDataList = new List<ReportData>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(@"http://localhost:61309/api/Reports/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("GetReportData").Result;
            if (response.IsSuccessStatusCode)
            {
                var reportJson = response.Content.ReadAsStringAsync().Result;
                ReportDataList = JsonConvert.DeserializeObject<List<ReportData>>(reportJson);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            return ReportDataList;
        }
        public static List<ReportData> FilterReport(int requiredMonth, string projectName, string teamHeadName, string workerName)
        {
            List<ReportData> ReportDataList = new List<ReportData>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(@"http://localhost:61309/api/Reports/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync($"FilterReport/{requiredMonth}/{projectName}/{teamHeadName}/{workerName}").Result;
            if (response.IsSuccessStatusCode)
            {
                var reportJson = response.Content.ReadAsStringAsync().Result;
                ReportDataList = JsonConvert.DeserializeObject<List<ReportData>>(reportJson);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            return ReportDataList;
        }
    }
}
