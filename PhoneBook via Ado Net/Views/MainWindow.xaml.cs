using PhoneBook_via_Ado_Net.Static_Classes;
using System.Windows;

namespace PhoneBook_via_Ado_Net.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ViewController.SetMainView(ContentControlMain);            
        }
    }
}