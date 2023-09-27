using Ardalis.Result;
using PhoneBook.BLL.Filters;
using PhoneBook.DTO.ContactDtos;
using PhoneBook.DTO.PersonDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.BLL.Services.ContactService
{
    public interface IContactService
    {
        Task<Result<ContactDto>> Add(CreateContactDto newContact);
        Task<Result> Update(UpdateContactDto contact);
        Task<Result<ContactDto>> GetById(long id);
        Task<Result> Delete(DeleteContactDto contact);
        Task<PagedResult<List<ContactDto>>> GetAll(ContactFilter filter);
    }
}
