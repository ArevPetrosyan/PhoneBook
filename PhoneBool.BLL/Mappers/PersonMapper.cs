using PhoneBook.DAL.Models;
using PhoneBook.DTO.PersonDtos;
using Riok.Mapperly.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.BLL.Mappers
{
    [Mapper(UseReferenceHandling = true)]
    public static partial class PersonMapper
    {
        public static partial PersonDto MapToPersonDto(this Person person);
        public static partial List<PersonDto> MapToPersonDtos(this List<Person> persons);
    }
}
