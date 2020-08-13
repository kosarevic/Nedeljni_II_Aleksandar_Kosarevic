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
using Zadatak_1.Model;
using Zadatak_1.Validations;
using Zadatak_1.ViewModel;

namespace Zadatak_1.View
{
    /// <summary>
    /// Interaction logic for EditClinicMaintanceWindow.xaml
    /// </summary>
    public partial class EditClinicMaintanceWindow : Window
    {
        AdminViewModel avm = new AdminViewModel();

        public EditClinicMaintanceWindow(ClinicMaintance m)
        {
            InitializeComponent();
            avm.Maintance = m;
            DataContext = avm;
            ExpansionAccess.IsChecked = avm.Maintance.ClinicExpansion;
            DisabledPatients.IsChecked = avm.Maintance.DisabledAccess;
        }

        private void ExpansionAccessChecked(object sender, RoutedEventArgs e)
        {
            avm.Maintance.ClinicExpansion = true;
        }

        private void DisabledPatientsChecked(object sender, RoutedEventArgs e)
        {
            avm.Maintance.DisabledAccess = true;
        }

        private void Btn_Confirm(object sender, RoutedEventArgs e)
        {
            if(EditClinicMaintanceValidation.Validate(avm.Maintance))
            {
                avm.EditClinicMaintance();
                AdminWindow window = new AdminWindow();
                window.Show();
                Close();
            }
        }

        private void Btn_Cancel(object sender, RoutedEventArgs e)
        {
            AdminWindow window = new AdminWindow();
            window.Show();
            Close();
        }
    }
}
