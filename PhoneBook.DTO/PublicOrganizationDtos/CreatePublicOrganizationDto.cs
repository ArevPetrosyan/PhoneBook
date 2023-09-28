using PhoneBook.DTO.ContactDtos;

namespace PhoneBook.DTO.PublicOrganizationDtos
{
    public class CreatePublicOrganizationDto : CreateContactDto
    {
        public string Website { get; set; }
        public string PublicInfo { get; set; }
    }
}
