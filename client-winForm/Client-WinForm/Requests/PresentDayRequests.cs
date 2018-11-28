using Client_WinForm.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Client_WinForm.Requests
{
    public class PresentDayRequests
    {
        //Id 
        static int idPresentDay = 0;

        public static bool AddPresent(PresentDay NewpresentDay)
        {
            //Post Request for Register
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(@"http://localhost:61309/api/PresentDay/AddPresent");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string presentDay = JsonConvert.SerializeObject(NewpresentDay, Formatting.None);

                streamWriter.Write(presentDay);
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
                    //If AddPresent succeeded
                    if (httpResponse.StatusCode == HttpStatusCode.Created)
                    {
                        if (!int.TryParse(result, out idPresentDay))
                            return false;
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

        public static bool UpdatePresentDay(PresentDay presentDay)
        {

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create($@"http://localhost:61309/api/PresentDay/UpdatePresentDay");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "PUT";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                dynamic currentPresentDay = presentDay;
                string currentPresentNameString = Newtonsoft.Json.JsonConvert.SerializeObject(currentPresentDay, Formatting.None);
                streamWriter.Write(currentPresentNameString);
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
                    //If AddPresent succeeded
                    if (httpResponse.StatusCode == HttpStatusCode.OK)
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

        public static bool UpdateDetailsByLogout()
        {
            if (!UpdatePresentDay(new PresentDay { IdPresentDay = idPresentDay, TimeEnd = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")) }))
            {
                System.Windows.Forms.MessageBox.Show("failed to update");
                return false;
            }
            return true;

        }
    }
}
