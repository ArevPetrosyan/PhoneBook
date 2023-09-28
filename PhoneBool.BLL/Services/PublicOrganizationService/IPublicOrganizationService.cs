using Ardalis.Result;
using PhoneBook.BLL.Filters;
using PhoneBook.DTO.PublicOrganizationDtos;

namespace PhoneBook.BLL.Services.PublicOrganizationService
{
    public interface IPublicOrganizationService
    {
        Task<Result<PublicOrganizationDto>> Add(CreatePublicOrganizationDto newPublicOrganization);
        Task<Result> Update(UpdatePublicOrganizationDto publicOrganization);
        Task<Result<PublicOrganizationDto>> GetById(long id);
        Task<Result> Delete(DeletePublicOrganizationDto publicOrganization);
        Task<PagedResult<List<PublicOrganizationDto>>> GetAll(PublicOrganizationFilter filter);
    }
}
