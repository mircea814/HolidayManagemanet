﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayManagement.Models
{
    public class Office
    {
        [Key]
        public int OfficeID { get; set; }
        public string OfficeName { get; set; }
  

    }
}
