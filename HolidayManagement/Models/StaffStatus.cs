﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayManagement.Models
{
    public class StaffStatus
    {
        [Key]
        public int StaffStatusID { get; set; }
        public string Status { get; set; }
    }
}
