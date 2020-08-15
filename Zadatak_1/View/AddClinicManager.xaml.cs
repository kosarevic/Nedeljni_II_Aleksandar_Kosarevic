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
    /// Interaction logic for AddClinicManager.xaml
    /// </summary>
    public partial class AddClinicManager : Window
    {
        AdminViewModel avm = new AdminViewModel();

        public AddClinicManager()
        {
            InitializeComponent();
            DataContext = avm;
            avm.ClinicManager.FirstName = "";
            avm.ClinicManager.LastName = "";
            avm.ClinicManager.RegistrationNumber = "";
            avm.ClinicManager.Gender = "";
            avm.ClinicManager.Citazenship = "";
            avm.ClinicManager.Username = "";
            avm.ClinicManager.Password = "";

        }

        private void Btn_Confirm(object sender, RoutedEventArgs e)
        {
            avm.ClinicManager.DateOfBirth = DateTime.Parse(date.ToString());
            avm.AddClinicManager();
            AdminWindow window = new AdminWindow();
            window.Show();
            Close();
        }

        private void Btn_Cancel(object sender, RoutedEventArgs e)
        {
            AdminWindow window = new AdminWindow();
            window.Show();
            Close();
        }
    }
}
