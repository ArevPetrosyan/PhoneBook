using PhoneBook.DTO.ContactDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.DTO.PublicOrganizationDtos
{
    public class UpdatePublicOrganizationDto : UpdateContactDto
    {
        public long Id { get; set; }
        public string Website { get; set; }
        public string PublicInfo { get; set; }
    }
}
