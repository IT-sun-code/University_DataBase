using System.Windows;
using System.Windows.Controls;
using DataBase.ViewModel;

namespace DataBase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class SignIn : Window
    {
        public SignIn()
        {
            DataContext = new SignInViewModel();
            InitializeComponent();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext != null) 
                (DataContext as SignInViewModel).Password = ((PasswordBox)sender).Password;
        }
    }
}
