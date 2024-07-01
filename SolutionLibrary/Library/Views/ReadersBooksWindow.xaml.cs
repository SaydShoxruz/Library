using Library.Data;
using Library.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Reflection.Metadata.BlobBuilder;

namespace Library.Views
{
    /// <summary>
    /// Логика взаимодействия для ReadersBooksWindow.xaml
    /// </summary>
    public partial class ReadersBooksWindow : Window
    {
        private List<ReaderBook> readerBooks;
        JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
        };
        public ReadersBooksWindow(Reader reader)
        {
            InitializeComponent();
            List<string> books = new List<string>();
            readerBooks = ReaderBooksData.ReadReaderBooksFromFile();
            foreach (ReaderBook readerBook in readerBooks)
            {
                if (readerBook.Reader == reader.Username)
                {
                    readersBooksDataGrid.ItemsSource = readerBook.Books;
                }
            }
        }
    }
}
