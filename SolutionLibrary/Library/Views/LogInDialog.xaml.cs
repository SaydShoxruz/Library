using Library.Data;
using Library.Models;
using System.Windows;

namespace Library.Views
{
    /// <summary>
    /// Логика взаимодействия для LogInDialog.xaml
    /// </summary>
    public partial class LogInDialog : Window
    {
        List<Reader> readers;
        Reader? reader;
        public LogInDialog()
        {
            InitializeComponent();
            readers = ReaderData.ReadReaderFromFile();
        }

        private bool isRegistratedAccaunt()
        {
            foreach (Reader storedReader in readers)
            {
                if (storedReader.Username == usernameTextBox.Text && storedReader.Password == passwordBox.Password)
                {
                    reader = storedReader;
                    return true;
                }
            }
            return false;
        }

        private void NextButton_Clicked(object sender, RoutedEventArgs e)
        {
            if (isRegistratedAccaunt())
            {
                if (reader.Username == "mashennik")
                {
                    AdminWindow adminWindow = new AdminWindow();
                    this.Close();
                    adminWindow.Show();
                }
                else
                {
                    ReaderWindow readerWindow = new ReaderWindow(true);
                    ReaderWindow.Reader = reader;
                    this.Close();
                    readerWindow.Show();
                }
            }
            else
            {
                var message = MessageBox.Show("Username or Password entered incorrectly!\n" +
                                              "Do you want to proceed to registering a new account?",
                                              "Error",
                                              MessageBoxButton.YesNo,
                                              MessageBoxImage.Error);
                if (message == MessageBoxResult.Yes)
                {
                    SignInDialog signInDialog = new SignInDialog();
                    this.Close();
                    signInDialog.ShowDialog();
                }
            }
        }
    }
}
