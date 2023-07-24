namespace LibraryManagementSystem.Domain;

public class User : BaseEntity
{
    public Guid PersonId { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }

    public Person Person { get; set; }
    
}