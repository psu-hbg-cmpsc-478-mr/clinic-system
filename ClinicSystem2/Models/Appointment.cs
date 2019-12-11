using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem2.Models
{
    public class Appointment
    {
        public int ID { get; set; }
        public string Patient { get; set; }
        public string Doctor { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Reason { get; set; }
        public string Goals { get; set; }

        public override string ToString()
        {
            return $"At {Start} with Doctor {Doctor} for {Reason}";
        }
    }
}
