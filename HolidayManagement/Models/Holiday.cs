using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayManagement.Models
{
    public class Holiday
    {
     [Key]
        public int HolidayID { get; set; }
        public string HolodayTypes { get; set; }
        public ICollection<HolidayType> HolidayType { get; set; }
        public int StaffID { get; set; }
        public ICollection<Staff> Staff { get; set; }
        public int TotalNumberOfDays { get; set; }
        public int DaysLeft { get; set; }

    }
}
