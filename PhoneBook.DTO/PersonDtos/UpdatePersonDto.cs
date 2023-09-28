using PhoneBook.DTO.ContactDtos;

namespace PhoneBook.DTO.PersonDtos
{
    public class UpdatePersonDto : UpdateContactDto
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
