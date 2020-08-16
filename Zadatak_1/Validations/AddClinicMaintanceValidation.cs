﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Zadatak_1.Model;

namespace Zadatak_1.Validations
{
    static class AddClinicMaintanceValidation
    {

        public static bool Validate(ClinicMaintance maintance)
        {
            if (maintance.FirstName.Length < 1 || !maintance.FirstName.All(Char.IsLetter))
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("incorrect first name, try again.", "Notification");
                return false;
            }
            if (maintance.LastName.Length < 1 || !maintance.LastName.All(char.IsLetter))
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("incorrect last name, try again.", "Notification");
                return false;
            }
            if (maintance.RegistrationNumber.Length != 9 || !maintance.RegistrationNumber.All(char.IsDigit))
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("incorrect registration number (9 digits required), try again.", "Notification");
                return false;
            }
            else
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString()))
                {
                    var cmd = new SqlCommand(@"select RegistrationNumber from tblClinicAdministrator where RegistrationNumber = @RegistrationNumber", conn);
                    cmd.Parameters.AddWithValue("@RegistrationNumber", maintance.RegistrationNumber);
                    conn.Open();
                    SqlDataReader reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {
                        if (reader1[0].ToString() == maintance.RegistrationNumber)
                        {
                            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Registration number already exists in database, try again.", "Notification");
                            return false;
                        }
                    }
                    reader1.Close();
                    conn.Close();
                }
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString()))
                {
                    var cmd = new SqlCommand(@"select RegistrationNumber from tblClinicMaintance where RegistrationNumber = @RegistrationNumber", conn);
                    cmd.Parameters.AddWithValue("@RegistrationNumber", maintance.RegistrationNumber);
                    conn.Open();
                    SqlDataReader reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {
                        if (reader1[0].ToString() == maintance.RegistrationNumber)
                        {
                            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Registration number already exists in database, try again.", "Notification");
                            return false;
                        }
                    }
                    reader1.Close();
                    conn.Close();
                }
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString()))
                {
                    var cmd = new SqlCommand(@"select RegistrationNumber from tblClinicManager where RegistrationNumber = @RegistrationNumber", conn);
                    cmd.Parameters.AddWithValue("@RegistrationNumber", maintance.RegistrationNumber);
                    conn.Open();
                    SqlDataReader reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {
                        if (reader1[0].ToString() == maintance.RegistrationNumber)
                        {
                            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Registration number already exists in database, try again.", "Notification");
                            return false;
                        }
                    }
                    reader1.Close();
                    conn.Close();
                }
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString()))
                {
                    var cmd = new SqlCommand(@"select RegistrationNumber from tblClinicDoctor where RegistrationNumber = @RegistrationNumber", conn);
                    cmd.Parameters.AddWithValue("@RegistrationNumber", maintance.RegistrationNumber);
                    conn.Open();
                    SqlDataReader reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {
                        if (reader1[0].ToString() == maintance.RegistrationNumber)
                        {
                            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Registration number already exists in database, try again.", "Notification");
                            return false;
                        }
                    }
                    reader1.Close();
                    conn.Close();
                }
            }
            if (maintance.Gender == "" || maintance.Gender == null)
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("incorrect gender, try again.", "Notification");
                return false;
            }
            if (maintance.DateOfBirth.ToShortDateString() == "1/1/0001")
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("incorrect date of birth, try again.", "Notification");
                return false;
            }
            if (int.Parse(maintance.DateOfBirth.ToString("yyyy")) > int.Parse(DateTime.Now.ToString("yyyy")))
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Date of birth suggests that you are born in the future, please try again.", "Notification");
            }
            if (int.Parse(DateTime.Now.ToString("yyyy")) - int.Parse(maintance.DateOfBirth.ToString("yyyy")) > 100)
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Your date of birth suggests that you lived longer than 100 years, please try again.", "Notification");
                return false;
            }
            if ((int.Parse(DateTime.Now.ToString("yyyyMMdd")) - int.Parse(maintance.DateOfBirth.ToString("yyyyMMdd"))) / 10000 < 18)
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Your date of birth suggests are under aged (less than 18 y/o), please try again.", "Notification");
                return false;
            }
            if (maintance.Citazenship == "" || maintance.Citazenship == null)
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("incorrect citazenship, try again.", "Notification");
                return false;
            }
            if (maintance.Username == "" || maintance.Username == null)
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Username is incorrect, please try again.", "Notification");
                return false;
            }
            else
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString()))
                {
                    var cmd = new SqlCommand(@"select Username from tblClinicAdministrator where Username = @Username", conn);
                    cmd.Parameters.AddWithValue("@Username", maintance.Username);
                    conn.Open();
                    SqlDataReader reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {
                        if (reader1[0].ToString() == maintance.Username)
                        {
                            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Username already exists in database, try again.", "Notification");
                            return false;
                        }
                    }
                    reader1.Close();
                    conn.Close();
                }
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString()))
                {
                    var cmd = new SqlCommand(@"select Username from tblClinicMaintance where Username = @Username", conn);
                    cmd.Parameters.AddWithValue("@Username", maintance.Username);
                    conn.Open();
                    SqlDataReader reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {
                        if (reader1[0].ToString() == maintance.Username)
                        {
                            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Username already exists in database, try again.", "Notification");
                            return false;
                        }
                    }
                    reader1.Close();
                    conn.Close();
                }
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString()))
                {
                    var cmd = new SqlCommand(@"select Username from tblClinicManager where Username = @Username", conn);
                    cmd.Parameters.AddWithValue("@Username", maintance.Username);
                    conn.Open();
                    SqlDataReader reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {
                        if (reader1[0].ToString() == maintance.Username)
                        {
                            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Username already exists in database, try again.", "Notification");
                            return false;
                        }
                    }
                    reader1.Close();
                    conn.Close();
                }
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString()))
                {
                    var cmd = new SqlCommand(@"select Username from tblClinicDoctor where Username = @Username", conn);
                    cmd.Parameters.AddWithValue("@Username", maintance.Username);
                    conn.Open();
                    SqlDataReader reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {
                        if (reader1[0].ToString() == maintance.Username)
                        {
                            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Username already exists in database, try again.", "Notification");
                            return false;
                        }
                    }
                    reader1.Close();
                    conn.Close();
                }
            }
            if (maintance.Password == "" || maintance.Password == null)
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Password is incorrect, please try again.", "Notification");
                return false;
            }
            if (maintance.Password.Length < 8 || maintance.Password.Where(char.IsUpper).Count() == 0 || maintance.Password.Where(char.IsLower).Count() == 0 ||
                maintance.Password.Where(char.IsDigit).Count() == 0 || !CheckSpecialCharacters(maintance.Password))
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
