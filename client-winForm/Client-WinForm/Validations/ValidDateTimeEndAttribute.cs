using Client_WinForm.Models;
using MySql.Data.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_WinForm.Validations
{
    class ValidDateTimeEndAttribute: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult validationResult = ValidationResult.Success;
           
                //Take workerId and email of the worker parameter
                DateTime dateBegin = (validationContext.ObjectInstance as Project).DateBegin;
          
                if (dateBegin>= ((DateTime)value))
                {
                    ErrorMessage = "date end project grate than date begin project";
                    validationResult = new ValidationResult(ErrorMessageString);
                }
           
            return validationResult;
        }

    }
}
