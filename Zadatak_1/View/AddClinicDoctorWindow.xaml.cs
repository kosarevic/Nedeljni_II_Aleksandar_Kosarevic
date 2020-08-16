using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Zadatak_1.Validations;
using Zadatak_1.ViewModel;

namespace Zadatak_1.View
{
    /// <summary>
    /// Interaction logic for AddClinicDoctorWindow.xaml
    /// </summary>
    public partial class AddClinicDoctorWindow : Window
    {
        ClinicManagerViewModel cmvm = new ClinicManagerViewModel();

        public AddClinicDoctorWindow()
        {
            InitializeComponent();
            DataContext = cmvm;
            cmvm.Doctor.FirstName = "";
            cmvm.Doctor.LastName = "";
            cmvm.Doctor.RegistrationNumber = "";
            cmvm.Doctor.Gender = "";
            cmvm.Doctor.Citazenship = "";
            cmvm.Doctor.Username = "";
            cmvm.Doctor.Password = "";
            cmvm.Doctor.UniqueNumber = "";
            cmvm.Doctor.Account = "";
            cmvm.Doctor.Unit = "";
            cmvm.Doctor.Shift = "";
        }

        private void Btn_Confirm(object sender, RoutedEventArgs e)
        {
            cmvm.Doctor.DateOfBirth = DateTime.Parse(date.ToString());

            if (AddClinicDoctorValidation.Validate(cmvm.Doctor))
            {
                cmvm.AddClinicDoctor();
                ClinicManagerWindow window = new ClinicManagerWindow();
                window.Show();
                Close(); 
            }
        }

        private void Btn_Cancel(object sender, RoutedEventArgs e)
        {
            ClinicManagerWindow window = new ClinicManagerWindow();
            window.Show();
            Close();
        }

        private void PatientAccessChecked(object sender, RoutedEventArgs e)
        {
            cmvm.Doctor.PatientAcceess = true;
        }
    }
}
