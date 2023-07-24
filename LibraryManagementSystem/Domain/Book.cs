namespace LibraryManagementSystem.Domain;

public class Book : BaseEntity
{
    public string Name { get; set; }
    public DateTime ReleaseDate { get; set; }
    public bool HasSeries { get; set; }
    public int SeriesNumber { get; set; }
    public int NumberOfCopy { get; set; }
    public int RemainNumberOfCopies { get; set; }


    //Navigation Properties
    public ICollection<Author> Authors { get; set; }
    public ICollection<Type> Types { get; set; }
    public ICollection<CopyBook> CopyBooks { get; set; }
}