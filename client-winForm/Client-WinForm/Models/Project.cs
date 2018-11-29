using Client_WinForm.Validations;
using MySql.Data.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace Client_WinForm.Models
{
    public class Project
    {

        public Project()
        {
         
        }
        [Key]
        public int ProjectId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(15, ErrorMessage = "ProjectName can contains max 15 chars"), MinLength(2, ErrorMessage = "ProjectName must contains at least 2 chars")]
        public string ProjectName { get; set; }

        [Required(ErrorMessage = "CustomerName is required")]
        [MaxLength(15, ErrorMessage = "CustomerName grade than 15 chars"), MinLength(2, ErrorMessage = "CustomerName less than 2 chars")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "DateBegin is required")]
        [ValidDateTimeBegin]
        public DateTime DateBegin { get; set; }

        [Required(ErrorMessage = "DateEnd is required")]
        [ValidDateTimeEnd]
        public DateTime DateEnd { get; set; }

        public bool IsFinish { get; set; } = false;

        public int IdTeamHead { get; set; }

        [Range(0, int.MaxValue)]
        [DefaultValue(0)]
        public decimal DevHours { get; set; }

        [Range(0, int.MaxValue)]
        [DefaultValue(0)]
        public decimal QAHours { get; set; }

        [Range(0, int.MaxValue)]
        [DefaultValue(0)]
        public decimal UIUXHours { get; set; }
        public List<Task> tasks { get; set; }
        public List<Worker> workers;



    }
}
