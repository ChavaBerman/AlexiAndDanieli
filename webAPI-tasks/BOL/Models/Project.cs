
using BOL.Models;
using BOL.Validations;
using MySql.Data.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class Project
    {

        public Project()
        {

            //HoursForDepartment = new List<HourForDepartment>();
            PresentsDayWorker = new List<PresentDay>();
            workers = new List<Worker>();
        }
        [Key]
        public int ProjectId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(15, ErrorMessage = "ProjectName grade than 15 chars"), MinLength(2, ErrorMessage = "ProjectName less than 2 chars")]
        [UniqueProjectName]
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
        public List<Models.Task> tasks { get; set; }

        //-------------------------
        public Worker Manager { get; set; }



        public List<PresentDay> PresentsDayWorker { get; set; }

        public List<Worker> workers { get; set; }

    }
}
