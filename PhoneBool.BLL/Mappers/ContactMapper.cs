using PhoneBook.DAL.Models;
using PhoneBook.DTO.ContactDtos;
using Riok.Mapperly.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.BLL.Mappers
{
    [Mapper(UseReferenceHandling = true)]
    public static partial class ContactMapper
    {
        public static partial ContactDto MapToContactDto(this Contact contact);
        public static partial List<ContactDto> MapToContactDtos(this List<Contact> contacts);
    }
}
