using PhoneBook.DTO.ContactDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
