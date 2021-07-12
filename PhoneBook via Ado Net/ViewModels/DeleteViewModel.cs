using GalaSoft.MvvmLight.Command;
using PhoneBook_via_Ado_Net.Models;
using PhoneBook_via_Ado_Net.Static_Classes;
using PhoneBook_via_Ado_Net.Views.User_Controls;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.SqlClient;

namespace PhoneBook_via_Ado_Net.ViewModels
{
    public class DeleteViewModel
    {
        public DeleteViewModel()
        {
            DeleteCommand = new RelayCommand<Contact>(DeleteContact);
            BackCommand = new RelayCommand(Back);           
        }

        public ObservableCollection<Contact> Contacts { get; set; } = new ObservableCollection<Contact>();
        public RelayCommand<Contact> DeleteCommand { get; set; }
        public RelayCommand BackCommand { get; set; }

        private void DeleteContact(Contact contact)
        {
            ConnectToSqlAndDeleteContact(contact);
            Contacts.Remove(contact);
        }

        private void Back()
        {
            EntryUserControl userControl = new EntryUserControl { DataContext = new EntryViewModel() };
            ViewController.MainView.Content = userControl;
        }

        private void ConnectToSqlAndDeleteContact(Contact contact)
        {
            using (SqlConnection connection = new SqlConnection { ConnectionString = ConfigurationManager.ConnectionStrings["Contacts"].ConnectionString })
            {
                connection.Open();

                SqlCommand command = new SqlCommand
                {
                    Connection = connection,
                    CommandText = $"DELETE FROM Contacts WHERE ID = {contact.ID};"
                };

                command.ExecuteNonQuery();

                System.Windows.MessageBox.Show("Contact deleted successfully.", "Phone Book");

                connection.Close();
            }
        }

    }
}