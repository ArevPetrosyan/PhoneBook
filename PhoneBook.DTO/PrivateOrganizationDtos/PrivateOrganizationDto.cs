using PhoneBook.DTO.ContactDtos;

namespace PhoneBook.DTO.PrivateOrganizationDtos
{
    public class PrivateOrganizationDto : BaseDeleteDtoWithDate
    {
        public string OrganizationType { get; set; }

        public string TaxId { get; set; }
        public long ContactId { get; set; }
        public ContactDto? Contact { get; set; }
    }
}
