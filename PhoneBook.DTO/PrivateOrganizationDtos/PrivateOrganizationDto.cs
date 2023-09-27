using PhoneBook.DTO.ContactDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.DTO.PrivateOrganizationDtos
{
    public class PrivateOrganizationDto : BaseDeleteDtoWithDate
    {
        public string OrganizationType { get; set; }

        public string TaxId { get; set; }
        public long ContactId { get; set; }
        public ContactDto? Contact { get; set; }
    }
}
