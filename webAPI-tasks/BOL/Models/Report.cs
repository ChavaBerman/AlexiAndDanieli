using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.Models
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

        public ReportData() { }
        public ReportData(int id, string name, decimal reservingHours, decimal givenHours, decimal presencePercent, int parentId)
        {
            Id = id;
            Name = name;
            ReservingHours = reservingHours;
            GivenHours = givenHours;
            ParentId = parentId;
        }
        public ReportData(int id, string name, string teamheader, decimal hours,decimal presence,decimal presencePercent, int parentId) : this(id, name,hours, presence, presencePercent, parentId)
        {
            TeamHeader = teamheader;
        }
       
    }
}
