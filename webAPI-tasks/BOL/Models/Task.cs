using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.Models
{
   public class Task
    {

        public int IdTask { get; set; }

        [Range(0,int.MaxValue, ErrorMessage = "Reserving hours can not be less than 0")]
        [DefaultValue(0)]
        public decimal ReservingHours { get; set; }

        [Range(0, int.MaxValue,ErrorMessage ="Given hours can not be less than 0")]
        [DefaultValue(1)]
        public decimal GivenHours { get; set; }
        public int IdWorker { get; set; }
        public int IdProject { get; set; }


        public string projectName { get; set; }
        public string workerName { get; set; }
    }
}
