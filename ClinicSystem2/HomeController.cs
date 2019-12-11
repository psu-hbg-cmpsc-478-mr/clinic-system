using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ClinicSystem2.Data;
using ClinicSystem2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicSystem2
{
    public class HomeController
    {
        private ApplicationDbContext ctx;

        public HomeController(ApplicationDbContext context)
        {
            ctx = context;
        }

        public bool IsClient(ClaimsPrincipal user)
        {
            return GetRole(user) == "Client";
        }

        public bool IsDoctor(ClaimsPrincipal user)
        {
            return GetRole(user) == "Doctor";
        }

        public bool IsStaff(ClaimsPrincipal user)
        {
            return GetRole(user) == "Staff";
        }

        public string GetRole(ClaimsPrincipal user)
        {
            return ctx.Role.Where(x => x.Username == user.Identity.Name)
                .SingleOrDefault()?.RoleName;
        }

        public Appointment GetNextAppointmentForClient(ClaimsPrincipal user)
        {
            return GetDisplayedAppointments(user).FirstOrDefault();
        }

        public IEnumerable<Appointment> GetDisplayedAppointments(ClaimsPrincipal user)
        {
            if (IsClient(user))
            {
                var appts = ctx.Appointment.Where(x => x.Patient == user.Identity.Name &&
                    x.End >= DateTime.Now).OrderBy(x => x.Start);
                return appts;
            }
            else if (IsDoctor(user))
            {
                var appts = ctx.Appointment.Where(x => x.Doctor == user.Identity.Name)
                    .OrderBy(x => x.Start);
                return appts;
            }
            else if (IsStaff(user))
            {
                var appts = ctx.Appointment.OrderBy(x => x.End);
                return appts;
            }
            else
            {
                return new List<Appointment>();
            }
        }
    }
}
