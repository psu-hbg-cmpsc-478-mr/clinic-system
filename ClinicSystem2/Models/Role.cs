using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem2.Models
{
    public class Role
    {
        [Key]
        public int ID { get; set; }
        public string Username { get; set; }
        public string RoleName { get; set; }
    }
}
