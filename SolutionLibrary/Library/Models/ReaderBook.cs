using System.Text.Json.Serialization;

namespace Library.Models;

class ReaderBook
{
    public string Reader { get; set; }
    public List<string> Books { get; set; }
    [JsonPropertyName("date_time")]
    public DateTime? DateTime { get; set; }
}
