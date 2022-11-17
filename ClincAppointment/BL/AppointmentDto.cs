using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class AppointmentDto
    {
        [Required]
        public string PatientName { get; set; }
        [Required]
        public string Phone { get; set; }
        public string Note { get; set; }
    }
}
