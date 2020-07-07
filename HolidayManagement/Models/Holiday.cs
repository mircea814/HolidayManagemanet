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
        public int HolidayTypeID { get; set; }
        public HolidayType HolidayType { get; set; }
        public int StaffID { get; set; }
        public Staff Staff { get; set; }
        public int TotalNumberOfDays { get; set; }
        public int DaysLeft { get; set; }

    }
}
