using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak_1.Model
{
    class ClinicDoctor : User
    {

        public string UniqueNumber { get; set; }
        public string Account { get; set; }
        public string Unit { get; set; }
        public string Shift { get; set; }
        public bool PatientAcceess { get; set; }
        public int ManagerID { get; set; }

        public ClinicDoctor() : base()
        {
        }
    }
}
