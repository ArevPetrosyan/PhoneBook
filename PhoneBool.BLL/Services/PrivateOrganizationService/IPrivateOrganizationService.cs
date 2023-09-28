using Ardalis.Result;
using PhoneBook.BLL.Filters;
using PhoneBook.DTO.PrivateOrganizationDtos;

namespace PhoneBook.BLL.Services.PrivateOrganizationService
{
    public interface IPrivateOrganizationService
    {
        Task<Result<PrivateOrganizationDto>> Add(CreatePrivateOrganizationDto newPrivateOrganization);
        Task<Result> Update(UpdatePrivateOrganizationDto PrivateOrganization);
        Task<Result<PrivateOrganizationDto>> GetById(long id);
        Task<Result> Delete(DeletePrivateOrganizationDto PrivateOrganization);
        Task<PagedResult<List<PrivateOrganizationDto>>> GetAll(PrivateOrganizationFilter filter);
    }
}
