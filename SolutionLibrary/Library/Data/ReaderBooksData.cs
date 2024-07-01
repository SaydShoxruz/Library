using Library.Models;
using System.IO;
using System.Text.Json;

namespace Library.Data;

class ReaderBooksData
{
    private const string PATH = @"C:\Users\Shokhruz\Desktop\Library\SolutionLibrary\Library\Data\ReaderBooks.json";
    private static JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions()
    {
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
    };

    public static List<ReaderBook> ReadReaderBooksFromFile()
    {
        using (StreamReader streamReader = new StreamReader(PATH))
        {
            string storedData = streamReader.ReadToEnd();
            return JsonSerializer.Deserialize<List<ReaderBook>>(storedData, jsonSerializerOptions);
        }
    }

    public static void WriteReaderBooksToFile(List<ReaderBook> books)
    {
        using (StreamWriter streamWriter = new StreamWriter(PATH))
        {
            var jsonData = JsonSerializer.Serialize(books, jsonSerializerOptions);

            streamWriter.Write(jsonData);
        }
    }
}
