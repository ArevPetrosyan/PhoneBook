using PhoneBook.DAL.Models;
using PhoneBook.DTO.ContactDtos;
using Riok.Mapperly.Abstractions;

namespace PhoneBook.BLL.Mappers
{
    [Mapper(UseReferenceHandling = true)]
    public static partial class ContactMapper
    {
        public static partial ContactDto MapToContactDto(this Contact contact);
        public static partial List<ContactDto> MapToContactDtos(this List<Contact> contacts);
    }
}
