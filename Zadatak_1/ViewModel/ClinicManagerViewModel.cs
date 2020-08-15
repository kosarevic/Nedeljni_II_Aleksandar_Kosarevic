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
using Zadatak_1.View;

namespace Zadatak_1.ViewModel
{
    class ClinicManagerViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<ClinicDoctor> Doctors { get; set; }

        public ClinicManagerViewModel()
        {
            FillList();
            Doctor = new ClinicDoctor();
        }

        private ClinicDoctor doctor;

        public ClinicDoctor Doctor
        {
            get { return doctor; }
            set
            {
                if (doctor != value)
                {
                    doctor = value;
                    OnPropertyChanged("Doctor");
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

        private List<string> shifts;

        public List<string> Shifts
        {
            get { return new List<string> { "Morning shift", "Afternoon shift", "Night shift", "24 hours" }; }
            set { shifts = value; }
        }

        public void FillList()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString()))
            {
                SqlCommand query = new SqlCommand("select * from tblClinicDoctor", conn);
                conn.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                if (Doctors == null)
                    Doctors = new ObservableCollection<ClinicDoctor>();

                foreach (DataRow row in dataTable.Rows)
                {
                    if (LoginWindow.CurrentManager.Id == int.Parse(row[14].ToString()))
                    {
                        ClinicDoctor d = new ClinicDoctor
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
                            UniqueNumber = row[9].ToString(),
                            Account = row[10].ToString(),
                            Unit = row[11].ToString(),
                            Shift = row[12].ToString(),
                            PatientAcceess = bool.Parse(row[13].ToString()),
                            ManagerID = int.Parse(row[14].ToString())
                        };
                        Doctors.Add(d); 
                    }
                }
            }
        }

        public void AddClinicDoctor()
        {
            byte[] data = System.Text.Encoding.ASCII.GetBytes(doctor.Password);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            String hash = System.Text.Encoding.ASCII.GetString(data);

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString()))
            {
                var cmd = new SqlCommand(@"insert into tblClinicDoctor values (@FirstName, @LastName, @RegistrationNumber, @Gender, @DateOfBirth, @Citazenship, @Username, @Password, @UniqueNumber, @Account, @Unit, @Shift, @PatientAccess, @ManagerID);", conn);
                cmd.Parameters.AddWithValue("@FirstName", doctor.FirstName);
                cmd.Parameters.AddWithValue("@LastName", doctor.LastName);
                cmd.Parameters.AddWithValue("@RegistrationNumber", doctor.RegistrationNumber);
                cmd.Parameters.AddWithValue("@Gender", doctor.Gender);
                cmd.Parameters.AddWithValue("@DateOfBirth", doctor.DateOfBirth);
                cmd.Parameters.AddWithValue("@Citazenship", doctor.Citazenship);
                cmd.Parameters.AddWithValue("@Username", doctor.Username);
                cmd.Parameters.AddWithValue("@Password", hash);
                cmd.Parameters.AddWithValue("@UniqueNumber", doctor.UniqueNumber);
                cmd.Parameters.AddWithValue("@Account", doctor.Account);
                cmd.Parameters.AddWithValue("@Unit", doctor.Unit);
                cmd.Parameters.AddWithValue("@Shift", doctor.Shift);
                cmd.Parameters.AddWithValue("@PatientAccess", doctor.PatientAcceess);
                cmd.Parameters.AddWithValue("@ManagerID", LoginWindow.CurrentManager.Id);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Clinic doctor successfully created.", "Notification");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
