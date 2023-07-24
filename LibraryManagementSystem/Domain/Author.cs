namespace LibraryManagementSystem.Domain;

public class Author : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime? BirthDate { get; set; }
    public DateTime? DeathDate { get; set; }
    public string? CountryOfBirth { get; set; }

    // Navigation properties
    public ICollection<Book> Books { get; set; }
}