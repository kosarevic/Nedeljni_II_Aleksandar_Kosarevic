using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak_1.Model
{
    public class Clinic
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ConstructionDate { get; set; }
        public string Owner { get; set; }
        public string Adress { get; set; }
        public int Floors { get; set; }
        public int Rooms { get; set; }
        public bool Balcony { get; set; }
        public bool BackYard { get; set; }
        public int AmbulanceAccess { get; set; }
        public int DisabledAccess { get; set; }

    }
}
