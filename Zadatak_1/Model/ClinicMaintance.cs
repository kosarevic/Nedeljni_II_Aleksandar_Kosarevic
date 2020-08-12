using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak_1.Model
{
    public class ClinicMaintance : User
    {

        public bool ClinicExpansion { get; set; }
        public bool DisabledAccess { get; set; }

        public ClinicMaintance() : base()
        {
        }
    }
}
