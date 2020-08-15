using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak_1.Model
{
    public class ClinicPatient
    {

        public string CardNumber { get; set; }
        public DateTime InsuranceExpiration { get; set; }
        public string DoctorUniqueNumber { get; set; }

        public ClinicPatient() : base()
        {
        }
    }
}
