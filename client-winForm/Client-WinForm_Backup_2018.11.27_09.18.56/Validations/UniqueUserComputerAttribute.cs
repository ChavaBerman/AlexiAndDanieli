using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Client_WinForm.Models;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace Client_WinForm.Validations
{
    public class UniqueUserComputerAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult validationResult = ValidationResult.Success;
            try
            {
                //Take userId and email of the user parameter
                int userId = (validationContext.ObjectInstance as User).UserId;
                string userComputer = value.ToString();

                List<User> users = new List<User>();
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(@"http://localhost:61309/api/Users/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("getAllUsers").Result;
                if (response.IsSuccessStatusCode)
                {
                    var usersJson = response.Content.ReadAsStringAsync().Result;
                    users = JsonConvert.DeserializeObject<List<User>>(usersJson);
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }

                if (userComputer != "")
                {
                    bool isUnique = users.Any(user => user.UserComputer.Equals(userComputer) && user.UserId != userId) == false;
                    if (isUnique == false)
                    {
                        ErrorMessage = "User computer already belongs to another user...";
                        validationResult = new ValidationResult(ErrorMessageString);
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = "User computer already belongs to another user...";
                validationResult = new ValidationResult(ErrorMessageString);
            }
            return validationResult;
        }
    }
}
