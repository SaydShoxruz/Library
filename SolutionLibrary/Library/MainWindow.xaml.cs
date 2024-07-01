using Library.Views;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Library
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool IsSignIn = true;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SignInButton_Clicked(object sender, RoutedEventArgs e)
        {
            SignInDialog signInDialog = new SignInDialog();
            this.Close();
            signInDialog.ShowDialog();
        }

        private void LogInButton_Clicked(object sender, RoutedEventArgs e)
        {
            LogInDialog logInDialog = new LogInDialog();
            this.Close();
            logInDialog.ShowDialog();
        }

        private void SkipButton_Clicked(object sender, RoutedEventArgs e)
        {
            IsSignIn = false;
            ReaderWindow readerWindow = new ReaderWindow(IsSignIn);
            this.Close();
            readerWindow.Show();
        }
    }
}