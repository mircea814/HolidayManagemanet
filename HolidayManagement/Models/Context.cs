using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HolidayManagement.Models;

namespace HolidayManagement.Models
{
    public class Context : DbContext
    { 
        public Context(DbContextOptions<Context> options)
            :base(options)
        { }
    public DbSet<Staff> Staff { get; set; }
    public DbSet<StaffStatus> StaffStatus { get; set; }
    public DbSet<HolidayManagement.Models.Office> Office { get; set; }
    }
}
