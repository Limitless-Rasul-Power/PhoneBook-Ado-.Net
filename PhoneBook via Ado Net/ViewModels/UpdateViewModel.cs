using GalaSoft.MvvmLight.Command;
using PhoneBook_via_Ado_Net.Models;
using PhoneBook_via_Ado_Net.Static_Classes;
using PhoneBook_via_Ado_Net.Views.User_Controls;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace PhoneBook_via_Ado_Net.ViewModels
{
    public class UpdateViewModel : INotifyPropertyChanged
    {
        private string _updatedFullName;
        private string _updatedPhoneNumber;

        public UpdateViewModel()
        {
            BackCommand = new RelayCommand(Back);
            SaveCommand = new RelayCommand(Save);
            SelectionChangedCommand = new RelayCommand<object>(SelectionChanged);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public RelayCommand BackCommand { get; set; }
        public RelayCommand SaveCommand { get; set; }
        public RelayCommand<object> SelectionChangedCommand { get; set; }                        
        public Contact SelectedContact { get; set; }
        public ObservableCollection<Contact> Contacts { get; set; }


        public string UpdatedFullName
        {
            get { return _updatedFullName; }
            set { _updatedFullName = value; OnPropertyChanged(); }
        }

        public string UpdatedPhoneNumber
        {
            get { return _updatedPhoneNumber; }
            set { _updatedPhoneNumber = value; OnPropertyChanged(); }
        }


        private void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void Back()
        {
            EntryUserControl userControl = new EntryUserControl { DataContext = new EntryViewModel() };
            ViewController.MainView.Content = userControl;
        }

        private void SelectionChanged(object selectedItem)
        {
            SelectedContact = selectedItem as Contact;
            UpdatedFullName = SelectedContact.FullName;
            UpdatedPhoneNumber = SelectedContact.PhoneNumber;

        }
        private void Save()
        {   
            if(SelectedContact.FullName != UpdatedFullName && SelectedContact.PhoneNumber == UpdatedPhoneNumber && 
                string.IsNullOrWhiteSpace(UpdatedFullName) == false)
            {
                ConnectToSqlAndUpdateContact();
                return;
            }

            if(SelectedContact.PhoneNumber == UpdatedPhoneNumber)
            {
                System.Windows.MessageBox.Show("Nothing has changed.", "Phone Book");                
                return;
            }

            if (Contacts.FirstOrDefault(c => c.PhoneNumber == UpdatedPhoneNumber) != null)
            {
                System.Windows.MessageBox.Show("This Phone Number already Exists.", "Phone Book");                
                return;
            }

            bool isFullNameOrPhoneNumberEmpty = string.IsNullOrWhiteSpace(UpdatedFullName) || string.IsNullOrWhiteSpace(UpdatedPhoneNumber);

            if (isFullNameOrPhoneNumberEmpty)
            {
                System.Windows.MessageBox.Show("Full name or phone number is empty or both are empty.", "Phone Book");                
                return;
            }

            bool isValid = Regex.IsMatch(UpdatedPhoneNumber, "^([0-9][0-9][0-9]) [0-9][0-9][0-9] [0-9][0-9][0-9][0-9]$");

            if (isValid == false)
            {
                System.Windows.MessageBox.Show("Number format is wrong.\nExample of Correct Format: XXX XXX XXXX", "Phone Book");                
                return;
            }

            ConnectToSqlAndUpdateContact();
            
        }
   
        private void ConnectToSqlAndUpdateContact()
        {
            using (SqlConnection connection = new SqlConnection { ConnectionString = ConfigurationManager.ConnectionStrings["Contacts"].ConnectionString })
            {
                connection.Open();

                SqlCommand command = new SqlCommand
                {
                    Connection = connection,
                    CommandText = $"UPDATE Contacts\nSET FullName = \'{UpdatedFullName}\', PhoneNumber = \'{UpdatedPhoneNumber}\' WHERE ID = {SelectedContact.ID}"
                };

                command.ExecuteNonQuery();


                SelectedContact.FullName = UpdatedFullName;
                SelectedContact.PhoneNumber = UpdatedPhoneNumber;

                System.Windows.MessageBox.Show("Successfully updated.", "Phone Book.");

                connection.Close();
            }
        }

    }
}