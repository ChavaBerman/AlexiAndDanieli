
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Client_WinForm.Models;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Client_WinForm.Validations
{
    class UniquePasswordAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string password = value.ToString();
            int userId= (validationContext.ObjectInstance as User).UserId;
            ValidationResult validationResult = ValidationResult.Success;
            try
            {
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

                bool isUnique = users.Any(user => user.Password.Equals(password) && user.UserId != userId) == false;
                if (isUnique == false)
                {
                    ErrorMessage = "password nust be unique";
                    validationResult = new ValidationResult(ErrorMessageString);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return validationResult;
        }

    }
}
