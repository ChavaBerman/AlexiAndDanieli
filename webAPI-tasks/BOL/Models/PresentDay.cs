
using BOL.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.Models
{
    public class PresentDay
    {
        public PresentDay()
        {
        }

        [Key]
        public int IdPresentDay { get; set; }
       //TODO: [ValidDateTimeBegin]
        public DateTime TimeBegin { get; set; }

       //TODO: [ValidDateTimeEnd]
        public DateTime TimeEnd { get; set; }
        public decimal sumHoursDay { get; set; }

        public int UserId { get; set; }

        public int ProjectId { get; set; }

        //------------------------
        public User User { get; set; }

        public Project Project { get; set; }


    }
}
