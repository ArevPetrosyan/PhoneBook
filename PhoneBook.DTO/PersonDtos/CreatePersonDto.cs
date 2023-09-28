using PhoneBook.DTO.ContactDtos;

namespace PhoneBook.DTO.PersonDtos
{
    public class CreatePersonDto : CreateContactDto
    {
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
