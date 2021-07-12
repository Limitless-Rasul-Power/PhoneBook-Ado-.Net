using GalaSoft.MvvmLight.Command;
using System.Linq;
using PhoneBook_via_Ado_Net.Static_Classes;
using PhoneBook_via_Ado_Net.Views.User_Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.ObjectModel;
using PhoneBook_via_Ado_Net.Models;

namespace PhoneBook_via_Ado_Net.ViewModels
{
    public class InsertViewModel : INotifyPropertyChanged
    {
        private string _fullName;
        private string _phoneNumber;

        public InsertViewModel()
        {
            BackCommand = new RelayCommand(Back);
            InsertCommand = new RelayCommand(Insert);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public RelayCommand BackCommand { get; set; }
        public RelayCommand InsertCommand { get; set; }
        public ObservableCollection<Contact> Contacts { get; set; } = new ObservableCollection<Contact>();

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; OnPropertyChanged(); }
        }

        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value; OnPropertyChanged(); }
        }

        private void Insert()
        {
            bool isFullNameOrPhoneNumberEmpty = string.IsNullOrWhiteSpace(FullName) || string.IsNullOrWhiteSpace(PhoneNumber);

            if (isFullNameOrPhoneNumberEmpty)
            {
                System.Windows.MessageBox.Show("Full name or phone number is empty or both are empty.", "Phone Book");
                return;
            }

            bool isValid = Regex.IsMatch(PhoneNumber, "^([0-9][0-9][0-9]) [0-9][0-9][0-9] [0-9][0-9][0-9][0-9]$");

            if (isValid == false)
            {
                System.Windows.MessageBox.Show("Number format is wrong.\nExample of Correct Format: XXX XXX XXXX", "Phone Book");
                return;
            }

            if (Contacts.FirstOrDefault(c => c.PhoneNumber == PhoneNumber) != null)
            {
                System.Windows.MessageBox.Show("This Phone Number already Exists.", "Phone Book");
                return;
            }

            ConnectToSqlAndInsertContact();
        }

        private void Back()
        {
            EntryUserControl userControl = new EntryUserControl { DataContext = new EntryViewModel() };
            ViewController.MainView.Content = userControl;
        }

        private void ConnectToSqlAndInsertContact()
        {            
            using (SqlConnection connection = new SqlConnection { ConnectionString = ConfigurationManager.ConnectionStrings["Contacts"].ConnectionString })
            {
                connection.Open();

                SqlCommand command = new SqlCommand
                {
                    Connection = connection,
                    CommandText = $"INSERT INTO Contacts VALUES(\'{FullName}\', \'{PhoneNumber}\');"
                };

                command.ExecuteNonQuery();
                command.CommandText = "SELECT TOP 1 * FROM Contacts ORDER BY ID DESC;";

                SqlDataReader reader = command.ExecuteReader();                
                reader.Read();

                Contacts.Add(new Contact
                {
                    ID = reader.GetInt32(FieldNames.ID),
                    FullName = reader.GetString(FieldNames.FullName),
                    PhoneNumber = reader.GetString(FieldNames.PhoneNumber)
                });


                FullName = PhoneNumber = default;
                System.Windows.MessageBox.Show("Contact added successfully.", "Phone Book");

                connection.Close();

            }
        }

        private void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}