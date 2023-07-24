namespace LibraryManagementSystem.Domain;

public class Member : BaseEntity
{
    public Guid PersonId { get; set; }
    public DateTime MembershipStartDate { get; set; }
    public DateTime MembershipEndDate { get; set; }

    //Navigation Property
    public ICollection<Loan> Loans { get; set; }
    public Person Person { get; set; }
}