using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using Zadatak_1.Model;

namespace Zadatak_1.Validations
{
    static class AddAdministratorValidation
    {

        public static bool Validate(ClinicAdministrator admin)
        {
            if (admin.FirstName.Length < 1 || !admin.FirstName.All(Char.IsLetter))
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("incorrect first name, try again.", "Notification");
                return false;
            }
            if (admin.LastName.Length < 1 || !admin.LastName.All(char.IsLetter))
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("incorrect last name, try again.", "Notification");
                return false;
            }
            if (admin.RegistrationNumber.Length != 9 || !admin.RegistrationNumber.All(char.IsDigit))
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("incorrect registration number (9 digits required), try again.", "Notification");
                return false;
            }
            else
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString()))
                {
                    var cmd = new SqlCommand(@"select RegistrationNumber from tblClinicAdministrator where RegistrationNumber = @RegistrationNumber", conn);
                    cmd.Parameters.AddWithValue("@RegistrationNumber", admin.RegistrationNumber);
                    conn.Open();
                    SqlDataReader reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {
                        if (reader1[0].ToString() == admin.RegistrationNumber)
                        {
                            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Registration number already exists in database, try again.", "Notification");
                            return false;
                        }
                    }
                    reader1.Close();
                    conn.Close();
                }
            }
            if (admin.Gender == "" || admin.Gender == null)
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("incorrect gender, try again.", "Notification");
                return false;
            }
            if (admin.DateOfBirth.ToShortDateString() == "1/1/0001")
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("incorrect date of birth, try again.", "Notification");
                return false;
            }
            if (int.Parse(admin.DateOfBirth.ToString("yyyy")) > int.Parse(DateTime.Now.ToString("yyyy")))
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Date of birth suggests that you are born in the future, please try again.", "Notification");
            }
            if (int.Parse(DateTime.Now.ToString("yyyy")) - int.Parse(admin.DateOfBirth.ToString("yyyy")) > 100)
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Your date of birth suggests that you lived longer than 100 years, please try again.", "Notification");
                return false;
            }
            if ((int.Parse(DateTime.Now.ToString("yyyyMMdd")) - int.Parse(admin.DateOfBirth.ToString("yyyyMMdd"))) / 10000 < 18)
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Your date of birth suggests are under aged (less than 18 y/o), please try again.", "Notification");
                return false;
            }
            if (admin.Citazenship == "" || admin.Citazenship == null)
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("incorrect citazenship, try again.", "Notification");
                return false;
            }
            if (admin.Username == "" || admin.Username == null)
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Username is incorrect, please try again.", "Notification");
                return false;
            }
            else
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString()))
                {
                    var cmd = new SqlCommand(@"select Username from tblClinicAdministrator where Username = @Username", conn);
                    cmd.Parameters.AddWithValue("@Username", admin.Username);
                    conn.Open();
                    SqlDataReader reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {
                        if (reader1[0].ToString() == admin.Username)
                        {
                            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Username already exists in database, try again.", "Notification");
                            return false;
                        }
                    }
                    reader1.Close();
                    conn.Close();
                }
            }
            if (admin.Password == "" || admin.Password == null)
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Password is incorrect, please try again.", "Notification");
                return false;
            }
            if (admin.Password.Length < 8 || admin.Password.Where(char.IsUpper).Count() == 0 || admin.Password.Where(char.IsLower).Count() == 0 ||
                admin.Password.Where(char.IsDigit).Count() == 0 || !CheckSpecialCharacters(admin.Password))
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Password must contain at least 8 characters:\n\none lowercase letter\n" +
                            "one uppercase letter\none number\none special character\n\nplease try again.", "Notification");
                return false;
            }

            return true;
        }

        public static bool CheckSpecialCharacters(string password)
        {
            string specialChar = @"\|!#$%&/()=?»«@£§€{}.-;'<>_,";
            foreach (var item in specialChar)
            {
                if (password.Contains(item))
                    return true;
            }

            return false;
        }

    }
}
