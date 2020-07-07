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
        public int OfficeID{ get; set; }
        public Office Office { get; set; }
        public int StaffStatusID { get; set; }
        public StaffStatus StaffStatus { get; set; }
    }
}
