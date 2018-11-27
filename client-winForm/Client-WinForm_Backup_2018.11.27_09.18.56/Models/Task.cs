using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_WinForm.Models
{
   public class Task
    {
        [Key]
        public int IdTask { get; set; }

        [Range(0, int.MaxValue)]
        [DefaultValue(0)]
        public decimal ReservingHours { get; set; }

        [Range(1, int.MaxValue)]
        [DefaultValue(1)]
       public decimal GivenHours { get; set; }
        public int IdUser { get; set; }
        public int IdProject { get; set; }


        public string projectName { get; set; }
        public string userName { get; set; }
    }
}
