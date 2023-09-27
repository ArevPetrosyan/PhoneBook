using PhoneBook.DTO.ContactDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.DTO.PersonDtos
{
    public class CreatePersonDto : CreateContactDto
    {
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
