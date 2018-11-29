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
    class UniqueNameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult validationResult = ValidationResult.Success;
            try
            {
                //Take userId and username of the user parameter
                int userId = (validationContext.ObjectInstance as Worker).WorkerId;
                string name = value.ToString();

                //Invoke method 'getAllUsers' from 'UserService' in 'BLL project' by reflection (not by adding reference!)

                //1. Load 'BLL' project   
                Assembly assembly = Assembly.LoadFrom(Directory.GetParent(AppContext.BaseDirectory).Parent.FullName + @"\BLL\bin\Debug\BLL.dll");

                //2. Get 'UserService' type
                Type userServiceType = assembly.GetTypes().First(t => t.Name.Equals("LogicManager"));

                //3. Get 'GetAllUsers' method
                MethodInfo getAllUsersMethod = userServiceType.GetMethods().First(m => m.Name.Equals("GetAllUsers"));

                //4. Invoke this method
                List<Worker> users = getAllUsersMethod.Invoke(Activator.CreateInstance(userServiceType), new object[] { }) as List<Worker>;

                //The result of this method is list of users

                //check if username of the user parameter is unique
                bool isUnique = users.Any(user => user.WorkerName.Equals(name, StringComparison.OrdinalIgnoreCase) && user.WorkerId != userId) == false;
                if (isUnique == false)
                {
                    ErrorMessage = "Choose another name, it is already exsists.";
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
