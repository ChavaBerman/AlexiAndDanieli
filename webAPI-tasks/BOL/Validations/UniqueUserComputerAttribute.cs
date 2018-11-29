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

    class UniqueWorkerComputerAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult validationResult = ValidationResult.Success;
            try
            {
                //Take workerId and workerComputer of the worker parameter
                int workerId = (validationContext.ObjectInstance as Worker).WorkerId;
                string workerComputer = value.ToString();

                
                //1. Load 'BLL' project
                Assembly assembly = Assembly.LoadFrom(Directory.GetParent(AppContext.BaseDirectory).Parent.FullName + @"\BLL\bin\Debug\BLL.dll");

                
                Type workerServiceType = assembly.GetTypes().First(t => t.Name.Equals("LogicManager"));

                //3. Get 'GetAllWorkers' method
                MethodInfo getAllWorkersMethod = workerServiceType.GetMethods().First(m => m.Name.Equals("GetAllWorkers"));

                //4. Invoke this method
                List<Worker> workers = getAllWorkersMethod.Invoke(Activator.CreateInstance(workerServiceType), new object[] { }) as List<Worker>;

                //The result of this method is list of workers

                if (workerComputer != "")
                {
                    bool isUnique = workers.Any(worker => worker.WorkerComputer.Equals(workerComputer) && worker.WorkerId != workerId) == false;
                    if (isUnique == false)
                    {
                        ErrorMessage = "This computer already registered by another worker.";
                        validationResult = new ValidationResult(ErrorMessageString);
                    }
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
