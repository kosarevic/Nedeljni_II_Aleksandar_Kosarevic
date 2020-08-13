using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Zadatak_1.Model;

namespace Zadatak_1.ViewModel
{
    class AdminViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<ClinicMaintance> AllMaintance { get; set; }

        public AdminViewModel()
        {
            FillList();
            Maintance = new ClinicMaintance();
            Clinic = new Clinic();
        }

        private ClinicMaintance maintance;

        public ClinicMaintance Maintance
        {
            get { return maintance; }
            set
            {
                if (maintance != value)
                {
                    maintance = value;
                    OnPropertyChanged("Maintance");
                }
            }
        }

        private Clinic clinic;

        public Clinic Clinic
        {
            get { return clinic; }
            set
            {
                if (clinic != value)
                {
                    clinic = value;
                    OnPropertyChanged("Clinic");
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

        public void FillList()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString()))
            {
                SqlCommand query = new SqlCommand("select * from tblClinicMaintance", conn);
                conn.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                if (AllMaintance == null)
                    AllMaintance = new ObservableCollection<ClinicMaintance>();

                foreach (DataRow row in dataTable.Rows)
                {
                    ClinicMaintance m = new ClinicMaintance
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
                        ClinicExpansion = bool.Parse(row[9].ToString()),
                        DisabledAccess = bool.Parse(row[10].ToString())
                    };
                    AllMaintance.Add(m);
                }
            }
        }

        public void AddClinicMaintance()
        {
            //User password is encrypted before being deposited in database.
            byte[] data = System.Text.Encoding.ASCII.GetBytes(maintance.Password);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            String hash = System.Text.Encoding.ASCII.GetString(data);

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString()))
            {
                var cmd = new SqlCommand(@"insert into tblClinicMaintance values (@FirstName, @LastName, @RegistrationNumber, @Gender, @DateOfBirth, @Citazenship, @Username, @Password, @ClinicExpansion, @DisabledAccess);", conn);
                cmd.Parameters.AddWithValue("@FirstName", maintance.FirstName);
                cmd.Parameters.AddWithValue("@LastName", maintance.LastName);
                cmd.Parameters.AddWithValue("@RegistrationNumber", maintance.RegistrationNumber);
                cmd.Parameters.AddWithValue("@Gender", maintance.Gender);
                cmd.Parameters.AddWithValue("@DateOfBirth", maintance.DateOfBirth);
                cmd.Parameters.AddWithValue("@Citazenship", maintance.Citazenship);
                cmd.Parameters.AddWithValue("@Username", maintance.Username);
                cmd.Parameters.AddWithValue("@Password", hash);
                cmd.Parameters.AddWithValue("@ClinicExpansion", maintance.ClinicExpansion);
                cmd.Parameters.AddWithValue("@DisabledAccess", maintance.DisabledAccess);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Clinic Maintance successfully created.", "Notification");
            }
        }

        public void EditClinicMaintance()
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString()))
            {
                var cmd = new SqlCommand(@"update tblClinicMaintance set FirstName=@FirstName, LastName=@LastName, RegistrationNumber=@RegistrationNumber, Gender=@Gender, DateOfBirth=@DateOfBirth, Citazenship=@Citazenship, Username=@Username, ClinicExpansion=@ClinicExpansion, DisabledAccess=@DisabledAccess where MaintanceID=@MaintanceID", conn);
                cmd.Parameters.AddWithValue("@MaintanceID", maintance.Id);
                cmd.Parameters.AddWithValue("@FirstName", maintance.FirstName);
                cmd.Parameters.AddWithValue("@LastName", maintance.LastName);
                cmd.Parameters.AddWithValue("@RegistrationNumber", maintance.RegistrationNumber);
                cmd.Parameters.AddWithValue("@Gender", maintance.Gender);
                cmd.Parameters.AddWithValue("@DateOfBirth", maintance.DateOfBirth);
                cmd.Parameters.AddWithValue("@Citazenship", maintance.Citazenship);
                cmd.Parameters.AddWithValue("@Username", maintance.Username);
                cmd.Parameters.AddWithValue("@ClinicExpansion", maintance.ClinicExpansion);
                cmd.Parameters.AddWithValue("@DisabledAccess", maintance.DisabledAccess);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Clinic Maintance successfully updated.", "Notification");
            }
        }

        public void DeleteClinicMaintance()
        {

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString()))
            {
                var cmd = new SqlCommand(@"Delete from tblClinicMaintance where MaintanceID=@MaintanceID;", conn);
                cmd.Parameters.AddWithValue("@MaintanceID", maintance.Id);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Clinic Maintance successfully deleted.", "Notification");
                AllMaintance.Remove(maintance);
            }
        }

        public void AddClinic()
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString()))
            {
                var cmd = new SqlCommand(@"insert into tblClinic values (@Title, @ConstructionDate, @Owner, @Adress, @Floors, @Rooms, @Balcony, @BackYard, @AmbulanceAccess, @DisabledAccess);", conn);
                cmd.Parameters.AddWithValue("@Title", clinic.Title);
                cmd.Parameters.AddWithValue("@ConstructionDate", clinic.ConstructionDate);
                cmd.Parameters.AddWithValue("@Owner", clinic.Owner);
                cmd.Parameters.AddWithValue("@Adress", clinic.Adress);
                cmd.Parameters.AddWithValue("@Floors", clinic.Floors);
                cmd.Parameters.AddWithValue("@Rooms", clinic.Rooms);
                cmd.Parameters.AddWithValue("@Balcony", clinic.Balcony);
                cmd.Parameters.AddWithValue("@BackYard", clinic.BackYard);
                cmd.Parameters.AddWithValue("@AmbulanceAccess", clinic.AmbulanceAccess);
                cmd.Parameters.AddWithValue("@DisabledAccess", clinic.DisabledAccess);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Clinic successfully created.", "Notification");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
