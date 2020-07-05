using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayManagement.Models
{
    public class HolidayType
    {
        [Key]
        public int HolidayTypeID { get; set; }
        public string Type { get; set; }
    }
}
