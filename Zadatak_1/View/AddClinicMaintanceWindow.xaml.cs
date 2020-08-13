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
    /// Interaction logic for AddClinicMaintanceWindow.xaml
    /// </summary>
    public partial class AddClinicMaintanceWindow : Window
    {
        AdminViewModel avm = new AdminViewModel();

        public AddClinicMaintanceWindow()
        {
            InitializeComponent();
            DataContext = avm;
            avm.Maintance.FirstName = "";
            avm.Maintance.LastName = "";
            avm.Maintance.RegistrationNumber = "";
            avm.Maintance.Gender = "";
            avm.Maintance.Citazenship = "";
            avm.Maintance.Username = "";
            avm.Maintance.Password = "";
        }

        private void Btn_Confirm(object sender, RoutedEventArgs e)
        {
            avm.Maintance.DateOfBirth = DateTime.Parse(date.ToString());

            if(AddClinicMaintanceValidation.Validate(avm.Maintance))
            {
                avm.AddClinicMaintance();
                AdminWindow window = new AdminWindow();
                window.Show();
                Close();
            }
        }

        private void Btn_Cancel(object sender, RoutedEventArgs e)
        {
            LoginWindow window = new LoginWindow();
            window.Show();
            Close();
        }

        private void ExpansionAccessChecked(object sender, RoutedEventArgs e)
        {
            avm.Maintance.ClinicExpansion = true;
        }

        private void DisabledPatientsChecked(object sender, RoutedEventArgs e)
        {
            avm.Maintance.DisabledAccess = true;
        }
    }
}
