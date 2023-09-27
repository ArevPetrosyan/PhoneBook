using PhoneBook.DTO.ContactDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.DTO.PrivateOrganizationDtos
{
    public class UpdatePrivateOrganizationDto : UpdateContactDto
    {
        public long Id { get; set; }
        public string OrganizationType { get; set; }
        public string TaxId { get; set; }
    }
}
