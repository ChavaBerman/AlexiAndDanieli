using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_WinForm.Models
{
    class ProjectReport
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
        public decimal ReservingHours { get; set; }
        public decimal GivenHours { get; set; }
    }
}
