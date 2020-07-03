using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayManagement.Models
{
    public class Holiday
    {
        public string HolodayTypes { get; set; }
        public HolidayType HolidayType { get; set; }
        public int StaffID { get; set; }
        public Staff Staff { get; set; }
        public int NumberOfDays { get; set; }

    }
}
