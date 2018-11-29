
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
    class UniqueEmailAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult validationResult = ValidationResult.Success;
            try
            {
                //Take worker id and email of the worker parameter
                int workerId = (validationContext.ObjectInstance as Worker).WorkerId;
                string email = value.ToString();

                //Invoke method 'getAllWorkers' from 'WorkerService' in 'BLL project' by reflection (not by adding reference!)

                //1. Load 'BLL' project   
                Assembly assembly = Assembly.LoadFrom(Directory.GetParent(AppContext.BaseDirectory).Parent.FullName + @"\BLL\bin\Debug\BLL.dll");

                //2. Get 'WorkerService' type
                Type workerServiceType = assembly.GetTypes().First(t => t.Name.Equals("LogicManager"));

                //3. Get 'GetAllWorkers' method
                MethodInfo getAllWorkersMethod = workerServiceType.GetMethods().First(m => m.Name.Equals("GetAllWorkers"));

                //4. Invoke this method
                List<Worker> workers = getAllWorkersMethod.Invoke(Activator.CreateInstance(workerServiceType), new object[] { }) as List<Worker>;

                //The result of this method is list of workers

                //check if email of the worker parameter is unique
                bool isUnique =workers.Any(worker => worker.Email.Equals(email, StringComparison.OrdinalIgnoreCase)&&worker.WorkerId!=workerId) == false;
                if (isUnique == false)
                {
                    ErrorMessage = "Enter another email address, this one is already exists.";
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
