using System.Text.Json.Serialization;

namespace Library.Models;

class Book
{
     public int Id { get; set; }
     public string Title { get; set; }
     public string Author { get; set; }
     [JsonPropertyName("publication_year")]
     public object PublicationYear { get; set; }
     public List<string> Genre { get; set; }
     public string Description { get; set; }
     [JsonPropertyName("cover_image")]
     public string CoverImage { get; set; }

}
