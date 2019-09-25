using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientControlLib.Models
{
    public class PatientDetails
    {
        public string Name { get; set; }
        public DateTime Dob { get; set; }
        public bool IsAssigned { get; set; } = false;
        public string Id { get; set; }
    }

}
