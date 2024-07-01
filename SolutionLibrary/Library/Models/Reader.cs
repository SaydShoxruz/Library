using System.Text.Json.Serialization;

namespace Library.Models;

public class Reader
{
    public string Username { get; set; }
    public string Password { get; set; }
    [JsonPropertyName("full_name")]
    public string FullName { get; set; }
    [JsonPropertyName("phone_number")]
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public Gender Gender { get; set; } = Gender.UnKnown;
    [JsonPropertyName("birth_day")]
    public DateTime? BirthDay { get; set; } = null;
}
