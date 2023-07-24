namespace LibraryManagementSystem.Domain;

public class Loan : BaseEntity
{
    public Guid BookId { get; set; }
    public Guid MemberId { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public int PenaltyPayment { get; set; }

    //Navigation Properties
    public Book Book { get; set; }
    public Member Member { get; set; }
}