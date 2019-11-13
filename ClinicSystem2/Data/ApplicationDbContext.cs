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
            if (!Roles.Where(x => x.Name == "Staff").Any())
                Roles.Add(new Microsoft.AspNetCore.Identity.IdentityRole("Staff"));
            if (!Roles.Where(x => x.Name == "Doctor").Any())
                Roles.Add(new Microsoft.AspNetCore.Identity.IdentityRole("Doctor"));
            SaveChanges();
        }
        public DbSet<ClinicSystem2.Models.Appointment> Appointment { get; set; }
    }
}
