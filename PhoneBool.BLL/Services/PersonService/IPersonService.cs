using Ardalis.Result;
using PhoneBook.BLL.Filters;
using PhoneBook.DTO.PersonDtos;

namespace PhoneBook.BLL.Services.PersonService
{
    public interface IPersonService
    {
        Task<Result<PersonDto>> Add(CreatePersonDto newPerson);
        Task<Result> Update(UpdatePersonDto person);
        Task<Result<PersonDto>> GetById(long id);
        Task<Result> Delete(DeletePersonDto person);
        Task<PagedResult<List<PersonDto>>> GetAll(PersonFilter filter);
    }
}
