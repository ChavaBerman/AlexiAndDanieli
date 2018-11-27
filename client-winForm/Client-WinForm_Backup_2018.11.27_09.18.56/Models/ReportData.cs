using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_WinForm.Models
{
    public class ReportData
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
        public string TeamHeader { get; set; }
        public decimal ReservingHours { get; set; }
        public decimal GivenHours { get; set; }
        public string Customer { get; set; }
        public DateTime? DateBegin { get; set; }
        public DateTime? DateEnd { get; set; }
        public int? Days { get; set; }
        public int? WorkedDays { get; set; }
    }
}
