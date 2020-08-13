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
using Zadatak_1.Model;

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

        public static ClinicAdministrator CurrentAdministrator = new ClinicAdministrator();

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
                AddAdminWindow window = new AddAdminWindow();
                window.Show();
                Close();
                return;
            }

            CurrentAdministrator = null;

            //Inserted value in password field is being converted into enrypted verson for latter matching with database version.
            byte[] data = System.Text.Encoding.ASCII.GetBytes(txtPassword.Password);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            String hash = System.Text.Encoding.ASCII.GetString(data);

            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());
            //User is extracted from the database matching inserted paramaters Username and Password.
            SqlCommand query = new SqlCommand("SELECT * FROM tblClinicAdministrator WHERE Username=@Username AND Password=@Password", sqlCon);
            query.CommandType = CommandType.Text;
            query.Parameters.AddWithValue("@Username", txtUsername.Text);
            query.Parameters.AddWithValue("@Password", hash);
            sqlCon.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            foreach (DataRow row in dataTable.Rows)
            {
                CurrentAdministrator = new ClinicAdministrator
                {
                    Id = int.Parse(row[0].ToString()),
                    FirstName = row[1].ToString(),
                    LastName = row[2].ToString(),
                    RegistrationNumber = row[3].ToString(),
                    Gender = row[4].ToString(),
                    DateOfBirth = DateTime.Parse(row[5].ToString()),
                    Citazenship = row[6].ToString(),
                    Username = row[7].ToString(),
                    Password = row[8].ToString(),
                    FirstLogin = bool.Parse(row[9].ToString())
                };
            }

            if (CurrentAdministrator != null && CurrentAdministrator.FirstLogin)
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString()))
                {
                    var cmd = new SqlCommand(@"update tblClinicAdministrator set FirstLogin=@FirstLogin where AdministratorID=@AdministratorID", conn);
                    cmd.Parameters.AddWithValue("@AdministratorID", CurrentAdministrator.Id);
                    cmd.Parameters.AddWithValue("@FirstLogin", false);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                AddClinicWindow window = new AddClinicWindow();
                window.Show();
                Close();
                return;
            }

            if (CurrentAdministrator != null)
            {
                AdminWindow window = new AdminWindow();
                window.Show();
                Close();
                return;
            }

            sqlCon.Close();
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Incorrect login credentials, please try again.", "Notification");
        }

        private void BtnRegister(object sender, RoutedEventArgs e)
        {

        }
    }
}
