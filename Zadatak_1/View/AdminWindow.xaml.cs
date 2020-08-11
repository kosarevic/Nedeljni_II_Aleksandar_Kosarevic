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
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        AddAdministratorViewModel aavm = new AddAdministratorViewModel();

        public AdminWindow()
        {
            InitializeComponent();
            DataContext = aavm;
            aavm.Administrator.FirstName = "";
            aavm.Administrator.LastName = "";
            aavm.Administrator.RegistrationNumber = "";
            aavm.Administrator.Gender = "";
            aavm.Administrator.Citazenship = "";
            aavm.Administrator.Username = "";
            aavm.Administrator.Password = "";
        }

        private void Btn_Confirm(object sender, RoutedEventArgs e)
        {
            aavm.Administrator.DateOfBirth = DateTime.Parse(date.Text);

            if (AddAdministratorValidation.Validate(aavm.Administrator))
            {
                aavm.AddAdministrator();
                Close();
            }
        }

        void DataWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            LoginWindow window = new LoginWindow();
            window.Show();
        }

        private void Btn_Cancel(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
