using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayManagement.Models
{
    public class Staff
    {
        [Key]
        public int StaffID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Office { get; set; }
        public ICollection<Office> Offices { get; set; }
        public string Status { get; set; }
        public ICollection<StaffStatus> StaffStatus { get; set; }
    }
}
