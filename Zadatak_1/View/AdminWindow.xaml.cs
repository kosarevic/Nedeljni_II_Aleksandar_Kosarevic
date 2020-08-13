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
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        AdminViewModel avm = new AdminViewModel();

        public AdminWindow()
        {
            InitializeComponent();
            DataContext = avm;
        }

        private void AddNewClinicMaintance(object sender, RoutedEventArgs e)
        {
            AddClinicMaintanceWindow window = new AddClinicMaintanceWindow();
            window.Show();
            Close();
        }

        private void DeleteClinicMaintance(object sender, RoutedEventArgs e)
        {
            avm.DeleteClinicMaintance();
        }

        private void EditClinicMaintance(object sender, RoutedEventArgs e)
        {
            EditClinicMaintanceWindow window = new EditClinicMaintanceWindow(avm.Maintance);
            window.Show();
            Close();
        }

        private void Logout(object sender, RoutedEventArgs e)
        {
            LoginWindow window = new LoginWindow();
            window.Show();
            Close();
        }
    }
}
