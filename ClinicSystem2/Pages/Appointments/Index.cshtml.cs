using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ClinicSystem2.Data;
using ClinicSystem2.Models;

namespace ClinicSystem2.Pages.Appointments
{
    public class IndexModel : PageModel
    {
        private readonly ClinicSystem2.Data.ApplicationDbContext _context;

        public IndexModel(ClinicSystem2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Appointment> Appointment { get;set; }

        public async Task OnGetAsync()
        {
            Appointment = await _context.Appointment.ToListAsync();
        }
    }
}
