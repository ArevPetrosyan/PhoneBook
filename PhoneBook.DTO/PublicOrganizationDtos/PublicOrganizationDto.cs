using PhoneBook.DTO.ContactDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.DTO.PublicOrganizationDtos
{
    public class PublicOrganizationDto : BaseDeleteDtoWithDate
    {
        public string Website { get; set; }
        public string PublicInfo { get; set; }
        public long ContactId { get; set; }
        public ContactDto? Contact { get; set; }
    }
}
