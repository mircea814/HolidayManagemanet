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
        public int StaffID { get; set; }
        public Staff Staff { get; set; }
        public int RequestStatusID { get; set; }
        public RequestStatus RequestStatus { get; set; }
        public DateTime StartDate { get; set;}
        public DateTime EndDate { get; set; }
        public int HolidayTypeID { get; set; }
        public HolidayType HolidayType { get; set; }
    }
}
