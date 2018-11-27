using Client_WinForm.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Client_WinForm.Requests
{
   public class PresentDayRequests
    {
        static int idPresentDay=0;
        public static bool AddPresent(PresentDay NewpresentDay)
        {
            try
            {
                //Post Request for Register
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(@"http://localhost:61309/api/PresentDay/AddPresent");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string user = JsonConvert.SerializeObject(NewpresentDay, Formatting.None);

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
                        idPresentDay = int.Parse(result);


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

        public static bool UpdatePresentDay(PresentDay presentDay)
        {
            try
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
