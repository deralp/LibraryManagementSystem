namespace LibraryManagementSystem.Domain;

public class CopyBook : BaseEntity
{
    public Guid BookId { get; set; }
    public Guid PublisherId { get; set; }
    public string ISBN { get; set; }


    public Publisher Publisher { get; set; }
    public Book Book { get; set; }

}