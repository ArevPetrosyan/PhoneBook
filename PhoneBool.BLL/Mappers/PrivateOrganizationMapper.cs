using PhoneBook.DAL.Models;
using PhoneBook.DTO.PrivateOrganizationDtos;
using Riok.Mapperly.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.BLL.Mappers
{
    [Mapper(UseReferenceHandling = true)]
    public static partial class PrivateOrganizationMapper
    {
        public static partial PrivateOrganizationDto MapToPrivateOrganizationDto(this PrivateOrganization privateOrganization);
        public static partial List<PrivateOrganizationDto> MapToPrivateOrganizationDtos(this List<PrivateOrganization> privateOrganization);
    }
}
