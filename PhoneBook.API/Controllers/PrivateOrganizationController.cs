using Ardalis.Result;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.BLL.Filters;
using PhoneBook.BLL.Services.PrivateOrganizationService;
using PhoneBook.DTO.PrivateOrganizationDtos;

namespace PhoneBook.API.Controllers
{
    [Route("api/private-organization")]
    public class PrivateOrganizationController : BaseController
    {
        private readonly IPrivateOrganizationService _privateOrganizationService;

        public PrivateOrganizationController(IPrivateOrganizationService privateOrganizationService)
        {
            _privateOrganizationService = privateOrganizationService;
        }

        // <summary>
        /// Add new private Organization
        /// </summary>
        /// <param name="privateOrganization"></param>
        /// <returns></returns>
        [HttpPost("add")]
        public async Task<Result<PrivateOrganizationDto>> Add(CreatePrivateOrganizationDto privateOrganization)
        {
            return await _privateOrganizationService.Add(privateOrganization);
        }

        /// <summary>
		/// Update private Organization
		/// </summary>
		/// <param name="privateOrganization"></param>
		/// <returns></returns>
		[HttpPost("update")]
        public async Task<Result> Update(UpdatePrivateOrganizationDto privateOrganization)
        {
            return await _privateOrganizationService.Update(privateOrganization);
        }

        /// <summary>
        /// Get private Organization by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("get-by-id")]
        public async Task<Result<PrivateOrganizationDto>> GetById(long id)
        {
            return await _privateOrganizationService.GetById(id);
        }

        /// <summary>
        /// Delete private Organization
        /// </summary>
        /// <param name="privateOrganization"></param>
        /// <returns></returns>
        [HttpPost("delete")]
        public async Task<Result> Delete(DeletePrivateOrganizationDto privateOrganization)
        {
            return await _privateOrganizationService.Delete(privateOrganization);
        }

        /// <summary>
        /// Get all private Organization by filter
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-all")]
        public async Task<PagedResult<List<PrivateOrganizationDto>>> GetAll([FromQuery] PrivateOrganizationFilter filter)
        {
            return await _privateOrganizationService.GetAll(filter);
        }
    }
}
