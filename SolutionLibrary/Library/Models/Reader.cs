namespace Library.Models;

public class Reader
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string FullName { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public Gender Gender { get; set; } = Gender.UnKnown;
    public DateTime? BirthDay { get; set; } = null;
}
