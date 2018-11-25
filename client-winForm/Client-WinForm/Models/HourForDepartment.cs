using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Client_WinForm.Models
{
    public class HourForDepartment
    {
        //TODO:VALIDATION SUM HOURS LESS

        
        [Required(ErrorMessage = "ProjectId is required")]
        public int ProjectId { get; set; }


        [Required(ErrorMessage = "DepartmentId is required")]
        public int DepartmentId { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Sum hours must be more than 0 hours")]
        public int SumHours { get; set; }
        public Project project { get; set; }

        public DepartmentUser DepartmentUser { get; set; }


    }
}
