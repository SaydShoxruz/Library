using Library.Data;
using Library.Models;
using System.Net.Http;
using System.Text.Json;
using System.Windows;
using System.Windows.Input;

namespace Library.Views
{
    /// <summary>
    /// Логика взаимодействия для ReaderWindow.xaml
    /// </summary>
    public partial class ReaderWindow : Window
    {
        private readonly HttpClient _httpClient;
        private const string URL = "https://freetestapi.com/api/v1/books?search=";
        public bool signIn;
        public static Reader Reader;

        JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
        };
        private List<Book> books;
        public ReaderWindow(bool isSignIn)
        {
            InitializeComponent();

            _httpClient = new HttpClient();
            signIn = isSignIn;

            var storedBooks = BookData.ReadBooksFromFile();

            if (storedBooks.Count() == 0)
            {
                books = PopulateData();
                BookData.WriteBooksToFile(books);
            }
            else
            {
                books = storedBooks;
            }
            booksDataGrid.ItemsSource = books;
        }
        private List<Book> PopulateData()
        {
            string jsonData = _httpClient.GetStringAsync(URL).Result;

            var deserializedData = JsonSerializer.Deserialize<List<Book>>(jsonData, jsonSerializerOptions);

            return deserializedData;
        }
        private void AboutUsMenuItem_Clicked(object sender, RoutedEventArgs e)
        {
            AboutLibraryWindow aboutLibraryWindow = new AboutLibraryWindow();
            aboutLibraryWindow.Show();
        }

        private void ContactUsMenuItem_Clicked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Phone Number: (88)175-22-00\nTelegram: @mashennik_uz",
                            "Information",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information);
        }

        private void SearchBookButton_Clicked(object sender, RoutedEventArgs e)
        {
            var searchedText = SearchBookTextBox.Text;

            var searchedBook = books.Where(book =>
                    book.Id.ToString().Contains(searchedText) ||
                    book.Title.Contains(searchedText) ||
                    book.Author.Contains(searchedText) ||
                    book.PublicationYear.ToString().Contains(searchedText) ||
                    book.Genre.Contains(searchedText) ||
                    book.Description.Contains(searchedText) ||
                    book.CoverImage.Contains(searchedText));

            booksDataGrid.ItemsSource = searchedBook;
        }

        private void AllMenuItem_Clicked(object sender, RoutedEventArgs e)
        {
            booksDataGrid.ItemsSource = books;
        }

        private void ClassicMenuItem_Clicked(object sender, RoutedEventArgs e)
        {
            var searchedBook = books.Where(book =>
                    book.Genre.Contains("Classic"));

            booksDataGrid.ItemsSource = searchedBook;
        }

        private void FictionMenuItem_Clicked(object sender, RoutedEventArgs e)
        {
            var searchedBook = books.Where(book =>
                    book.Genre.Contains("Fiction"));

            booksDataGrid.ItemsSource = searchedBook;
        }

        private void DystopianMenuItem_Clicked(object sender, RoutedEventArgs e)
        {
            var searchedBook = books.Where(book =>
                    book.Genre.Contains("Dystopian"));

            booksDataGrid.ItemsSource = searchedBook;
        }

        private void ScienceFictionMenuItem_Clicked(object sender, RoutedEventArgs e)
        {
            var searchedBook = books.Where(book =>
                    book.Genre.Contains("Science Fiction"));

            booksDataGrid.ItemsSource = searchedBook;
        }

        private void RomanceMenuItem_Clicked(object sender, RoutedEventArgs e)
        {
            var searchedBook = books.Where(book =>
                    book.Genre.Contains("Romance"));

            booksDataGrid.ItemsSource = searchedBook;
        }

        private void AdventureMenuItem_Clicked(object sender, RoutedEventArgs e)
        {
            var searchedBook = books.Where(book =>
                    book.Genre.Contains("Adventure"));

            booksDataGrid.ItemsSource = searchedBook;
        }

        private void FantasyMenuItem_Clicked(object sender, RoutedEventArgs e)
        {
            var searchedBook = books.Where(book =>
                    book.Genre.Contains("Fantasy"));

            booksDataGrid.ItemsSource = searchedBook;
        }

        private void ComingOfAgeMenuItem_Clicked(object sender, RoutedEventArgs e)
        {
            var searchedBook = books.Where(book =>
                    book.Genre.Contains("Coming-of-age"));

            booksDataGrid.ItemsSource = searchedBook;
        }

        private void MagicalRealismMenuItem_Clicked(object sender, RoutedEventArgs e)
        {
            var searchedBook = books.Where(book =>
                    book.Genre.Contains("Magical Realism"));

            booksDataGrid.ItemsSource = searchedBook;
        }

        private void LiteraryFictionMenuItem_Clicked(object sender, RoutedEventArgs e)
        {
            var searchedBook = books.Where(book =>
                    book.Genre.Contains("Literary Fiction"));

            booksDataGrid.ItemsSource = searchedBook;
        }

        private void MythologyMenuItem_Clicked(object sender, RoutedEventArgs e)
        {
            var searchedBook = books.Where(book =>
                    book.Genre.Contains("Mythology"));

            booksDataGrid.ItemsSource = searchedBook;
        }

        private void EpicMenuItem_Clicked(object sender, RoutedEventArgs e)
        {
            var searchedBook = books.Where(book =>
                    book.Genre.Contains("Epic"));

            booksDataGrid.ItemsSource = searchedBook;
        }

        private void PoetryMenuItem_Clicked(object sender, RoutedEventArgs e)
        {
            var searchedBook = books.Where(book =>
                    book.Genre.Contains("Poetry"));

            booksDataGrid.ItemsSource = searchedBook;
        }

        private void HorrorMenuItem_Clicked(object sender, RoutedEventArgs e)
        {
            var searchedBook = books.Where(book =>
                    book.Genre.Contains("Horror"));

            booksDataGrid.ItemsSource = searchedBook;
        }

        private void TakeBookButton_Clicked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("The book has been successfully ordered for a period of 10 days.",
                            "Information",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information);
        }

        private void AccauntButton_Clicked(object sender, RoutedEventArgs e)
        {
            if (DrawerPanel.Visibility == Visibility.Collapsed)
            {
                DrawerPanel.Visibility = Visibility.Visible;
            }
            else
            {
                DrawerPanel.Visibility = Visibility.Collapsed;
            }
        }

        private void BooksDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void EditButton_Clicked(object sender, RoutedEventArgs e)
        {

        }

        private void CheckButton_Clicked(object sender, RoutedEventArgs e)
        {
            if (signIn)
            {
                ReadersBooksWindow readersBooksWindow = new ReadersBooksWindow(Reader);
                this.Close();

                readersBooksWindow.Show();
            }
            else
            {
                var message = MessageBox.Show("Unfortunately, you are not logged in to your account.\n" +
                                              "Do you want to login or sign in?",
                                              "Error",
                                              MessageBoxButton.YesNo,
                                              MessageBoxImage.Error);
                if (message == MessageBoxResult.Yes)
                {
                    MainWindow mainWindow = new MainWindow();
                    this.Close();
                    mainWindow.Show();
                }
            }
        }

        private void LogOutButton_Clicked(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }
    }
}
