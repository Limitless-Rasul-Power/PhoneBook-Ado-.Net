using GalaSoft.MvvmLight.Command;
using PhoneBook_via_Ado_Net.Models;
using PhoneBook_via_Ado_Net.Static_Classes;
using PhoneBook_via_Ado_Net.Views.User_Controls;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.SqlClient;

namespace PhoneBook_via_Ado_Net.ViewModels
{
    public class EntryViewModel
    {
        public EntryViewModel()
        {
            InsertCommand = new RelayCommand(Insert);
            DeleteCommand = new RelayCommand(Delete);
            UpdateCommand = new RelayCommand(Update);
            ConnectToSqlAntFetchContacts();
        }

        public RelayCommand InsertCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand UpdateCommand { get; set; }
        public ObservableCollection<Contact> Contacts { get; set; } = new ObservableCollection<Contact>();

        private void Insert()
        {
            InsertViewModel viewModel = new InsertViewModel { Contacts = this.Contacts };
            InsertUserControl userControl = new InsertUserControl { DataContext = viewModel };
            ViewController.MainView.Content = userControl;
        }

        private void Delete()
        {
            if (Contacts.Count == 0)
                return;

            DeleteViewModel viewModel = new DeleteViewModel { Contacts = this.Contacts };
            DeleteUserControl userControl = new DeleteUserControl { DataContext = viewModel };
            ViewController.MainView.Content = userControl;
        }
        
        private void Update()
        {
            if (Contacts.Count == 0)
                return;

            UpdateViewModel viewModel = new UpdateViewModel { Contacts = this.Contacts, 
                                                              SelectedContact = Contacts[0],
                                                              UpdatedPhoneNumber = Contacts[0].PhoneNumber,
                                                              UpdatedFullName = Contacts[0].FullName };
            UpdateUserControl userControl = new UpdateUserControl { DataContext = viewModel };
            ViewController.MainView.Content = userControl;
        }

        private void ConnectToSqlAntFetchContacts()
        {
            using (SqlConnection connection = new SqlConnection { ConnectionString = ConfigurationManager.ConnectionStrings["Contacts"].ConnectionString })
            {
                connection.Open();

                SqlCommand command = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "SELECT * FROM Contacts"
                };

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Contacts.Add(new Contact
                    {
                        ID = reader.GetInt32(FieldNames.ID),
                        FullName = reader.GetString(FieldNames.FullName),
                        PhoneNumber = reader.GetString(FieldNames.PhoneNumber)
                    });
                }

                connection.Close();
            }
        }
    }
}