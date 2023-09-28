namespace PhoneBook.DAL.Models
{
    public class Contact : BaseEntity
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string TextComment { get; set; }
        public long ContactTypeId { get; set; }
        public ContactType? ContactType { get; set; }
    }
}
