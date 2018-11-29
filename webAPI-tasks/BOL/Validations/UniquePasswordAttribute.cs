
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
    class UniquePasswordAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult validationResult = ValidationResult.Success;
            try
            {
                string password = "";
                //Take workerId and password of the worker parameter
                int workerId = (validationContext.ObjectInstance as Worker).WorkerId;
                if ((validationContext.ObjectInstance as Worker).IsNewWorker == false)
                    return null;
                try
                {
                     password = value.ToString();
                }
                catch
                {
                    ErrorMessage = "password can not be null";
                    validationResult = new ValidationResult(ErrorMessageString);
                    return validationResult;
                }
                //Invoke method 'getAllUsers' from 'UserService' in 'BLL project' by reflection (not by adding reference!)

                //1. Load 'BLL' project
                Assembly assembly = Assembly.LoadFrom(Directory.GetParent(AppContext.BaseDirectory).Parent.FullName+@"\BLL\bin\Debug\BLL.dll");

                //2. Get 'UserService' type
                Type workerServiceType = assembly.GetTypes().First(t => t.Name.Equals("LogicManager"));

                //3. Get 'GetAllUsers' method
                MethodInfo getAllWorkersMethod = workerServiceType.GetMethods().First(m => m.Name.Equals("GetAllWorkersWithPassword"));

                //4. Invoke this method
                List<Worker> workers = getAllWorkersMethod.Invoke(Activator.CreateInstance(workerServiceType), new object[] { }) as List<Worker>;

                //The result of this method is list of workers


                bool isUnique = workers.Any(worker => worker.Password.Equals(password) && worker.WorkerId != workerId) == false;
                if (isUnique == false)
                {
                    ErrorMessage = "Choose another password.";
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
