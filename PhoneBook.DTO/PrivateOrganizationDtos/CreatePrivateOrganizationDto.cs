using PhoneBook.DTO.ContactDtos;

namespace PhoneBook.DTO.PrivateOrganizationDtos
{
    public class CreatePrivateOrganizationDto : CreateContactDto
    {
        public string OrganizationType { get; set; }
        public string TaxId { get; set; }
    }
}
