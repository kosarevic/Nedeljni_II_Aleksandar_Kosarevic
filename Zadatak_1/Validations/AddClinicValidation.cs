using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Zadatak_1.Model;

namespace Zadatak_1.Validations
{
    static class AddClinicValidation
    {

        public static bool Validate(Clinic clinic)
        {
            if (clinic.Title == "" || clinic.Title == null)
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("incorrect clinic title, try again.", "Notification");
                return false;
            }
            if (clinic.ConstructionDate.ToShortDateString() == "1/1/0001")
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("incorrect clinic construction date, try again.", "Notification");
                return false;
            }
            if (int.Parse(clinic.ConstructionDate.ToString("yyyy")) > int.Parse(DateTime.Now.ToString("yyyy")))
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Date of construction suggests that clinic is made in the future, please try again.", "Notification");
                return false;
            }
            if (int.Parse(DateTime.Now.ToString("yyyy")) - int.Parse(clinic.ConstructionDate.ToString("yyyy")) > 300)
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Date of construction suggests that clinic is older than 300 years, please try again.", "Notification");
                return false;
            }
            if (clinic.Owner == "" || clinic.Owner == null)
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("incorrect clinic owner, try again.", "Notification");
                return false;
            }
            if (clinic.Adress == "" || clinic.Adress == null)
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("incorrect clinic adress, try again.", "Notification");
                return false;
            }
            if (clinic.Floors < 1 || clinic.Floors > 50)
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("incorrect number of clinic floors (must be at least 1 and fewer than 50, try again.", "Notification");
                return false;
            }
            if (clinic.Rooms < 4 || clinic.Rooms > 20)
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("incorrect number of clinic rooms per floor (must be at least 4 and fewer than 20, try again.", "Notification");
                return false;
            }
            if (clinic.AmbulanceAccess < 1 || clinic.AmbulanceAccess > 20)
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("incorrect number of clinic ambulance access spots (must be at least 1 and fewer than 20, try again.", "Notification");
                return false;
            }
            if (clinic.DisabledAccess < 1 || clinic.DisabledAccess > 20)
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("incorrect number of clinic disabled access spots (must be at least 1 and fewer than 20, try again.", "Notification");
                return false;
            }
            return true;
        }

    }
}
