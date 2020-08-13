using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Zadatak_1.Model;

namespace Zadatak_1.ViewModel
{
    class AddAdministratorViewModel : INotifyPropertyChanged
    {

        public AddAdministratorViewModel()
        {
            Administrator = new ClinicAdministrator();
        }

        private ClinicAdministrator administrator;

        public ClinicAdministrator Administrator
        {
            get { return administrator; }
            set
            {
                if (administrator != value)
                {
                    administrator = value;
                    OnPropertyChanged("Administrator");
                }
            }
        }

        //Gender collection is made with predifined values.
        private List<string> genders;

        public List<string> Genders
        {
            get { return new List<string> { "M", "F", "X" }; }
            set { genders = value; }
        }

        public void AddAdministrator()
        {
            //User password is encrypted before being deposited in database.
            byte[] data = System.Text.Encoding.ASCII.GetBytes(administrator.Password);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            String hash = System.Text.Encoding.ASCII.GetString(data);

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString()))
            {
                var cmd = new SqlCommand(@"insert into tblClinicAdministrator values (@FirstName, @LastName, @RegistrationNumber, @Gender, @DateOfBirth, @Citazenship, @Username, @Password, @FirstLogin);", conn);
                cmd.Parameters.AddWithValue("@FirstName", administrator.FirstName);
                cmd.Parameters.AddWithValue("@LastName", administrator.LastName);
                cmd.Parameters.AddWithValue("@RegistrationNumber", administrator.RegistrationNumber);
                cmd.Parameters.AddWithValue("@Gender", administrator.Gender);
                cmd.Parameters.AddWithValue("@DateOfBirth", administrator.DateOfBirth);
                cmd.Parameters.AddWithValue("@Citazenship", administrator.Citazenship);
                cmd.Parameters.AddWithValue("@Username", administrator.Username);
                cmd.Parameters.AddWithValue("@Password", hash);
                cmd.Parameters.AddWithValue("@FirstLogin", true);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Administrator Successfully created.", "Notification");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
