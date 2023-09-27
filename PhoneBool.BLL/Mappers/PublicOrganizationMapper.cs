using PhoneBook.DAL.Models;
using PhoneBook.DTO.PublicOrganizationDtos;
using Riok.Mapperly.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.BLL.Mappers
{
    [Mapper(UseReferenceHandling = true)]
    public static partial class PublicOrganizationMapper
    {
        public static partial PublicOrganizationDto MapToPublicOrganizationDto(this PublicOrganization publicOrganization);
        public static partial List<PublicOrganizationDto> MapToPublicOrganizationDtos(this List<PublicOrganization> publicOrganization);
    }
}
