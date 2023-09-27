using Ardalis.Result;
using PhoneBook.DTO.PublicOrganizationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.BLL.Services.PublicOrganizationService
{
    public interface IPublicOrganizationService
    {
        Task<Result<PublicOrganizationDto>> Add(CreatePublicOrganizationDto newPublicOrganization);
        Task<Result> Update(UpdatePublicOrganizationDto publicOrganization);
        Task<Result<PublicOrganizationDto>> GetById(long id);
        Task<Result> Delete(DeletePublicOrganizationDto publicOrganization);
    }
}
