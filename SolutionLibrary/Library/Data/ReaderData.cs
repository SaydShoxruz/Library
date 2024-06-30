using Library.Models;
using System.IO;
using System.Text.Json;

namespace Library.Data;

public class ReaderData
{
    private const string PATH = @"C:\Users\user\Desktop\Library\SolutionLibrary\Library\Data\Readers.json";

    private static JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions()
    {
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
    };

    public static List<Reader> ReadReaderFromFile()
    {
        using(StreamReader streamReader = new StreamReader(PATH))
        {
            string storedJsonData = streamReader.ReadToEnd();

            var storedReaders = JsonSerializer.Deserialize<List<Reader>>(storedJsonData, jsonSerializerOptions);

            return storedReaders;
        }
    }

    public static void WriteReadersToFile(
        List<Reader> readers)
    {
        using(StreamWriter streamWriter = new StreamWriter(PATH))
        {
            var jsonData = JsonSerializer.Serialize(readers, jsonSerializerOptions);

            streamWriter.Write(jsonData);
        }
    }
}
