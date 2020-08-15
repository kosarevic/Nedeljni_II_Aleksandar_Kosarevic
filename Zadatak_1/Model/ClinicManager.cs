using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak_1.Model
{
    public class ClinicManager : User
    {

        public int Floor { get; set; }
        public int Doctors { get; set; }
        public int Rooms { get; set; }
        public int Oversight { get; set; }

        public ClinicManager() : base()
        {
        }
    }
}
