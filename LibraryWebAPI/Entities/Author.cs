namespace LibraryWebAPI.Entities;

public class Author
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public DateTime BirthDate { get; set; }
    public string Country { get; set; }
}