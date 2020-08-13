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
using Zadatak_1.ViewModel;

namespace Zadatak_1.View
{
    /// <summary>
    /// Interaction logic for AddClinicWindow.xaml
    /// </summary>
    public partial class AddClinicWindow : Window
    {
        AdminViewModel avm = new AdminViewModel();

        public AddClinicWindow()
        {
            InitializeComponent();
            DataContext = avm;
            avm.Clinic.Owner = "";
            avm.Clinic.Adress = "";
            avm.Clinic.Title = "";
        }

        private void Btn_Confirm(object sender, RoutedEventArgs e)
        {
            avm.Clinic.ConstructionDate = DateTime.Parse(date.ToString());
            avm.AddClinic();
            LoginWindow window = new LoginWindow();
            window.Show();
            Close();
        }

        private void Btn_Cancel(object sender, RoutedEventArgs e)
        {
            LoginWindow window = new LoginWindow();
            window.Show();
            Close();
        }

        private void ClinicBalconyAccess(object sender, RoutedEventArgs e)
        {
            avm.Clinic.Balcony = true;
        }

        private void ClinicBackYardAccess(object sender, RoutedEventArgs e)
        {
            avm.Clinic.BackYard = true;
        }
    }
}
