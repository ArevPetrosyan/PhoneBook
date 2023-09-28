namespace PhoneBook.DAL.Models
{
    public class PrivateOrganization : BaseEntity
    {
        public string OrganizationType { get; set; }
        public string TaxId { get; set; }
        public long ContactId { get; set; }
        public Contact? Contact { get; set; }
    }
}
