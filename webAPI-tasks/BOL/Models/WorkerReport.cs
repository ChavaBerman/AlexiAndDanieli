using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.Models
{
   public class WorkerReport
    {
        public int Id { get; set; }
        public int IdParent { get; set; }
        public string Name { get; set; }
        public decimal GivenHours { get; set; }

    }
}
