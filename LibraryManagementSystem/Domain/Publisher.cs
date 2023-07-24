namespace LibraryManagementSystem.Domain
{
    public class Publisher : BaseEntity
    {
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public DateTime FoundationDate { get; set; }


        public ICollection<CopyBook> Books { get; set; }
    }
}
