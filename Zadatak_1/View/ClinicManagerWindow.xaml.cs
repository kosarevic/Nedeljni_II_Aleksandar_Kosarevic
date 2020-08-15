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
    /// Interaction logic for ClinicManagerWindow.xaml
    /// </summary>
    public partial class ClinicManagerWindow : Window
    {
        ClinicManagerViewModel cmvm = new ClinicManagerViewModel();

        public ClinicManagerWindow()
        {
            InitializeComponent();
            DataContext = cmvm;
        }

        private void AddNewClinicDoctor(object sender, RoutedEventArgs e)
        {
            AddClinicDoctorWindow window = new AddClinicDoctorWindow();
            window.Show();
            Close();
        }

        private void EditClinicDoctor(object sender, RoutedEventArgs e)
        {

        }

        private void Logout(object sender, RoutedEventArgs e)
        {
            LoginWindow window = new LoginWindow();
            window.Show();
            Close();
        }
    }
}
