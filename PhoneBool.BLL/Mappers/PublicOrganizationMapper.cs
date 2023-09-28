using PhoneBook.DAL.Models;
using PhoneBook.DTO.PublicOrganizationDtos;
using Riok.Mapperly.Abstractions;

namespace PhoneBook.BLL.Mappers
{
    [Mapper(UseReferenceHandling = true)]
    public static partial class PublicOrganizationMapper
    {
        public static partial PublicOrganizationDto MapToPublicOrganizationDto(this PublicOrganization publicOrganization);
        public static partial List<PublicOrganizationDto> MapToPublicOrganizationDtos(this List<PublicOrganization> publicOrganization);
    }
}
