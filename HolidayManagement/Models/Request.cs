using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayManagement.Models
{
    public class Request
    {  
        [Key]
        public int RequestID { get; set; }
        public int StaffId { get; set; }
        public ICollection<Staff> Staff { get; set; }
        public string RequestStatus { get; set; }
        public ICollection<RequestStatus> Status { get; set; }
    }
}
