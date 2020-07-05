using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HolidayManagement.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace HolidayManagement.Models
{
    public class Context : IdentityDbContext<IdentityUser>
    { 
        public Context(DbContextOptions<Context> options)
            :base(options)
        { }
    public DbSet<Staff> MyStaff { get; set; }
    public DbSet<StaffStatus> MyStaffStatuses { get; set; }
    public DbSet<Office> MyOffices { get; set; }
    public DbSet<Request> MyRequests { get; set; }
    public DbSet<RequestStatus> MyRequestStatuses { get; set; }
    public DbSet<Holiday> MyHolidays { get; set; }
    public DbSet<HolidayType> MyHolidayTypes { get; set; }

    }
}
