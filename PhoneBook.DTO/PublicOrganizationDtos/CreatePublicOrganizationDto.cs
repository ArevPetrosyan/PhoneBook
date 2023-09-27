using PhoneBook.DTO.ContactDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.DTO.PublicOrganizationDtos
{
    public class CreatePublicOrganizationDto : CreateContactDto
    {
        public string Website { get; set; }
        public string PublicInfo { get; set; }
    }
}
