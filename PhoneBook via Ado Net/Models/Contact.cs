using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PhoneBook_via_Ado_Net.Models
{
    public class Contact : INotifyPropertyChanged
    {
        private string _fullName;
        private string _phoneNumber;
        public event PropertyChangedEventHandler PropertyChanged;

        public int ID { get; set; }

        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value; OnPropertyChanged(); }
        }
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; OnPropertyChanged(); }
        }

        private void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}