using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayManagement.Models
{
    public class Request
    {  
        [Key]
        public int RequestID { get; set; }
        public int StaffId { get; set; }
        public Staff Staff { get; set; }
        public string RequestStatus { get; set; }
        public RequestStatus Status { get; set; }
    }
}
