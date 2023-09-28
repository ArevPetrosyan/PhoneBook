using Ardalis.Result;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.BLL.Filters;
using PhoneBook.BLL.Services.PersonService;
using PhoneBook.DTO.PersonDtos;

namespace PhoneBook.API.Controllers
{
    [Route("api/person")]
    public class PersonController : BaseController
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        // <summary>
        /// Add new person
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        [HttpPost("add")]
        public async Task<Result<PersonDto>> Add(CreatePersonDto person)
        {
            return await _personService.Add(person);
        }

        /// <summary>
		/// Update person
		/// </summary>
		/// <param name="person"></param>
		/// <returns></returns>
		[HttpPost("update")]
        public async Task<Result> Update(UpdatePersonDto person)
        {
            return await _personService.Update(person);
        }

        /// <summary>
        /// Get person by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("get-by-id")]
        public async Task<Result<PersonDto>> GetById(long id)
        {
            return await _personService.GetById(id);
        }

        /// <summary>
        /// Delete person
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        [HttpPost("delete")]
        public async Task<Result> Delete(DeletePersonDto person)
        {
            return await _personService.Delete(person);
        }

        /// <summary>
        /// Get all persons by filter
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-all")]
        public async Task<PagedResult<List<PersonDto>>> GetAll([FromQuery] PersonFilter filter)
        {
            return await _personService.GetAll(filter);
        }
    }
}
