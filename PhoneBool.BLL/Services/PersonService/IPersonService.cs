using Ardalis.Result;
using PhoneBook.BLL.Filters;
using PhoneBook.DTO.ContactDtos;
using PhoneBook.DTO.PersonDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.BLL.Services.PersonService
{
    public interface IPersonService
    {
        Task<Result<PersonDto>> Add(CreatePersonDto newPerson);
        Task<Result> Update(UpdatePersonDto person);
        Task<Result<PersonDto>> GetById(long id);
        Task<Result> Delete(DeletePersonDto person);
        //Task<PagedResult<List<ContactDto>>> GetAll(ContactFilter filter);
    }
}
