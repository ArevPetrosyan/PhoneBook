using Ardalis.Result;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.BLL.Filters;
using PhoneBook.BLL.Services.ContactService;
using PhoneBook.DTO.ContactDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.API.Controllers
{
    [Route("api/contact")]
    public class ContactController : BaseController
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        /// <summary>
        /// Get contact by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("get-by-id")]
        public async Task<Result<ContactDto>> GetById(long id)
        {
            return await _contactService.GetById(id);
        }

        /// <summary>
        /// Delete contact
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        [HttpPost("delete")]
        public async Task<Result> Delete(DeleteContactDto contact)
        {
            return await _contactService.Delete(contact);
        }

        /// <summary>
        /// Get all contacts by filter
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-all")]
        public async Task<PagedResult<List<ContactDto>>> GetAll([FromQuery] ContactFilter filter)
        {
            return await _contactService.GetAll(filter);
        }
    }
}
