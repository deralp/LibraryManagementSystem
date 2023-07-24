namespace LibraryManagementSystem.Domain;

public class Role:BaseEntity
{
    public string Name { get; set; }

    public ICollection<Person> Persons { get; set; }

}