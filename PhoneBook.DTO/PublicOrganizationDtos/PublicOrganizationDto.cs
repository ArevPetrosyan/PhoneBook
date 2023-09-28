using PhoneBook.DTO.ContactDtos;

namespace PhoneBook.DTO.PublicOrganizationDtos
{
    public class PublicOrganizationDto : BaseDeleteDtoWithDate
    {
        public string Website { get; set; }
        public string PublicInfo { get; set; }
        public long ContactId { get; set; }
        public ContactDto? Contact { get; set; }
    }
}
