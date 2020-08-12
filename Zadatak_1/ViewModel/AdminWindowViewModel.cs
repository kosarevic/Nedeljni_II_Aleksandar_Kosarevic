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
using Zadatak_1.Model;

namespace Zadatak_1.ViewModel
{
    class AdminWindowViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<ClinicMaintance> AllMaintance { get; set; }

        public AdminWindowViewModel()
        {
            FillList();
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
                        Password = row[8].ToString()
                    };
                    AllMaintance.Add(m);
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
