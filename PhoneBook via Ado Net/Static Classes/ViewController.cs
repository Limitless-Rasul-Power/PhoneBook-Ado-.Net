using PhoneBook_via_Ado_Net.ViewModels;
using PhoneBook_via_Ado_Net.Views.User_Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook_via_Ado_Net.Static_Classes
{
    public static class ViewController
    {
        public static System.Windows.Controls.ContentControl  MainView { get; set; }

        public static void SetMainView(System.Windows.Controls.ContentControl control)
        {
            MainView = control;
            EntryUserControl userControl = new EntryUserControl { DataContext = new EntryViewModel() };
            MainView.Content = userControl;
        }
    }
}