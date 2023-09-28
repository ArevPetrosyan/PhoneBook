using PhoneBook.DTO.ContactDtos;

namespace PhoneBook.DTO.PersonDtos
{
    public class PersonDto : BaseDeleteDtoWithDate
    {
        public string Email { get; set; }
        public string Address { get; set; }
        public long ContactId { get; set; }
        public ContactDto? Contact { get; set; }
    }
}
