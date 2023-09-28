using PhoneBook.DTO.ContactDtos;

namespace PhoneBook.DTO.PrivateOrganizationDtos
{
    public class UpdatePrivateOrganizationDto : UpdateContactDto
    {
        public long Id { get; set; }
        public string OrganizationType { get; set; }
        public string TaxId { get; set; }
    }
}
