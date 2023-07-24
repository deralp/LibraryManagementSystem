namespace LibraryManagementSystem.Domain;

public class Type : BaseEntity
{
    public string Name { get; set; }

    // Navigation property
    public ICollection<Book> Books { get; set; }
}