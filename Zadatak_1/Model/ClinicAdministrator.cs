using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak_1.Model
{
    public class ClinicAdministrator : User
    {

        public bool FirstLogin { get; set; }

        public ClinicAdministrator() : base()
        {
        }

    }
}
