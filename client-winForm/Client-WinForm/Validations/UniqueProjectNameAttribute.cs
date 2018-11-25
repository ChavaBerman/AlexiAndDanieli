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
    class UniqueProjectNameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult validationResult = ValidationResult.Success;
            try
            {
                //Take userId and email of the user parameter
                int projectId = (validationContext.ObjectInstance as Project).ProjectId;
                string projectName = value.ToString();

                List<Project> projects = new List<Project>();
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(@"http://localhost:61309/api/Projects/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("GetAllProjects").Result;
                if (response.IsSuccessStatusCode)
                {
                    var projectsJson = response.Content.ReadAsStringAsync().Result;
                    projects = JsonConvert.DeserializeObject<List<Project>>(projectsJson);
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }


                bool isUnique = projects.Any(project => project.ProjectName.Equals(projectName) && project.ProjectId != projectId) == false;
                if (isUnique == false)
                {
                    ErrorMessage = "project name must be unique";
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
