using Library.Models;
using System.IO;
using System.Text.Json;

namespace Library.Data;

class BookData
{
    private const string PATH = @"C:\Users\Shokhruz\Desktop\Library\SolutionLibrary\Library\Data\Books.json";

    private static JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions()
    {
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
    };

    public static List<Book> ReadBooksFromFile()
    {
        using (StreamReader streamReader = new StreamReader(PATH))
        {
            string storedData = streamReader.ReadToEnd();
            return  JsonSerializer.Deserialize<List<Book>>(storedData, jsonSerializerOptions);
        }
    }

    public static void WriteBooksToFile(List<Book> books)
    {
        using (StreamWriter streamWriter = new StreamWriter(PATH))
        {
            var jsonData = JsonSerializer.Serialize(books, jsonSerializerOptions);

            streamWriter.Write(jsonData);
        }
    }
}
