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
   public class StatusRequests
    {
        public static List<Status> GetAllStatuses()
        {
            List<Status> allStatuses = new List<Status>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(@"http://localhost:61309/api/Status/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("GetAllstatuses").Result;
            if (response.IsSuccessStatusCode)
            {
                var statusJson = response.Content.ReadAsStringAsync().Result;
                allStatuses = JsonConvert.DeserializeObject<List<Status>>(statusJson);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            return allStatuses;
        }
    }
}
