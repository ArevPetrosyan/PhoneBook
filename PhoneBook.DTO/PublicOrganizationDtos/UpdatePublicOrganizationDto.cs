using PhoneBook.DTO.ContactDtos;

namespace PhoneBook.DTO.PublicOrganizationDtos
{
    public class UpdatePublicOrganizationDto : UpdateContactDto
    {
        public long Id { get; set; }
        public string Website { get; set; }
        public string PublicInfo { get; set; }
    }
}
