using Library.Data;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Library.Views
{
    /// <summary>
    /// Логика взаимодействия для SignInDialog.xaml
    /// </summary>
    public partial class SignInDialog : Window
    {
        private List<Reader> readers;
        private bool isEditingMode;
        public SignInDialog()
        {
            
            InitializeComponent();

            var allGenders = Enum.GetNames(typeof(Gender));

            genderComboBox.ItemsSource = null;
            genderComboBox.ItemsSource = allGenders;
            genderComboBox.SelectedIndex = 2;

            birthDatePicker.SelectedDate = new DateTime(2000, 1, 1);
        }

        private void SaveButton_Clicked(object sender, RoutedEventArgs e)
        {
            string username = userNameTextBox.Text;
            string password = passwordTextBox.Password;
            string fullname = fullNameTextBox.Text;
            string phoneNumber = phoneNumberTextBox.Text;
            string address = addressTextBox.Text;
            DateTime dateTime = DateTime.Parse(birthDatePicker.Text);
            Gender gender = (Gender)genderComboBox.SelectedIndex;

            readers = ReaderData.ReadReaderFromFile();
            if (!isEditingMode)
            {
                Reader reader = new()
                {
                    Username = username,
                    Password = password,
                    FullName = fullname,
                    PhoneNumber = phoneNumber,
                    Address = address,
                    Gender = gender,
                    BirthDay = dateTime,
                };
                readers.Add(reader);
            }

            else
            {
                var storedReader = readers.FirstOrDefault(readers => readers.Username == username);

                if (storedReader is null)
                {
                    MessageBox.Show(
                        $"Not found such reader with {username}",
                        "Error",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);

                    return;
                }

                storedReader.Address = address;
                storedReader.Gender = gender;
                storedReader.BirthDay = dateTime;
                storedReader.PhoneNumber = phoneNumber;
                storedReader.FullName = fullname;
                storedReader.Password = password;

            }

            ReaderData.WriteReadersToFile(readers);

            string message = "successfully";
            if (isEditingMode)
            {
                message = $"Edited {message}";
            }
            else
            {
                message = $"Added {message}";
            }

            MessageBox.Show(
                message,
                "Information",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
            LogInDialog logInDialog = new LogInDialog();
            this.Close();
            logInDialog.ShowDialog();
        }
    }
}
