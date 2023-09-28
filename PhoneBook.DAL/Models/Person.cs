namespace PhoneBook.DAL.Models
{
    public class Person : BaseEntity
    {
        public string Email { get; set; }
        public string Address { get; set; }
        public long ContactId { get; set; }
        public Contact? Contact { get; set; }
    }
}
