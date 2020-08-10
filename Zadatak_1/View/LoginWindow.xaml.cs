using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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

namespace Zadatak_1.View
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void BtnLogin(object sender, RoutedEventArgs e)
        {
            List<string> text = new List<string>();
            string OwnerUsername = null;
            string OwnerPassword = null;

            StreamReader sr = new StreamReader(@"..\\..\Files\ClinicAccess.txt");
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                text.Add(line);
            }
            sr.Close();

            if (text.Any())
            {
                foreach (string t in text)
                {
                    string[] temp = t.Split(' ');
                    OwnerUsername = temp[1];
                    OwnerPassword = temp[3];
                }
            }

            if (txtUsername.Text == OwnerUsername && txtPassword.Password == OwnerPassword)
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Successfull login.", "Notification");
            }
            else
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Incorrect login credentials, please try again.", "Notification");
            }
        }

        private void BtnRegister(object sender, RoutedEventArgs e)
        {

        }
    }
}
