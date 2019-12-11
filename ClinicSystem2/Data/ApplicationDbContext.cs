using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ClinicSystem2.Models;
using System.Linq;

namespace ClinicSystem2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<ClinicSystem2.Models.Appointment> Appointment { get; set; }
        public DbSet<ClinicSystem2.Models.Role> Role { get; set; }
    }
}
