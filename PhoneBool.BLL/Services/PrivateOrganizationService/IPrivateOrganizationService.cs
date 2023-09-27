using Ardalis.Result;
using PhoneBook.DTO.PersonDtos;
using PhoneBook.DTO.PrivateOrganizationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.BLL.Services.PrivateOrganizationService
{
    public interface IPrivateOrganizationService
    {
        Task<Result<PrivateOrganizationDto>> Add(CreatePrivateOrganizationDto newPrivateOrganization);
        Task<Result> Update(UpdatePrivateOrganizationDto PrivateOrganization);
        Task<Result<PrivateOrganizationDto>> GetById(long id);
        Task<Result> Delete(DeletePrivateOrganizationDto PrivateOrganization);
    }
}
