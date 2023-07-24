using System.ComponentModel.DataAnnotations.Schema;
using LibraryManagementSystem.Data;

namespace LibraryManagementSystem.Domain;

public class Person : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? Address { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public int IdentificationNumberLastFour { get; set; }
    public ICollection<Role> Roles { get; set; }
}
