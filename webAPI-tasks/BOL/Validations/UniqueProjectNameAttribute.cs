using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BOL.Validations
{
    class UniqueProjectNameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult validationResult = ValidationResult.Success;
            try
            {
                //Take projectId and projectName of the project parameter
                int projectId = (validationContext.ObjectInstance as Project).ProjectId;
                string projectName = value.ToString();

                //Invoke method 'GetAllProjects' from 'projectService' in 'BLL project' by reflection (not by adding reference!)

                //1. Load 'BLL' project
                Assembly assembly = Assembly.LoadFrom(Directory.GetParent(AppContext.BaseDirectory).Parent.FullName + @"\BLL\bin\Debug\BLL.dll");

                //2. Get 'WorkerService' type
                Type projectServiceType = assembly.GetTypes().First(t => t.Name.Equals("LogicProjects"));

                //3. Get 'GetAllProjects' method
                MethodInfo getAllProjectsMethod = projectServiceType.GetMethods().First(m => m.Name.Equals("GetAllProjects"));

                //4. Invoke this method
                List<Project> projects = getAllProjectsMethod.Invoke(Activator.CreateInstance(projectServiceType), new object[] { }) as List<Project>;

                //The result of this method is list of projects


                bool isUnique = projects.Any(project => project.ProjectName.Equals(projectName) && project.ProjectId != projectId) == false;
                if (isUnique == false)
                {
                    ErrorMessage = "Project name already exists.";
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
