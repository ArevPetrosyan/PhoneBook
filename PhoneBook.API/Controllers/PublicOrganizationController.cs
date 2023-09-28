using Ardalis.Result;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.BLL.Filters;
using PhoneBook.BLL.Services.PublicOrganizationService;
using PhoneBook.DTO.PublicOrganizationDtos;

namespace PhoneBook.API.Controllers
{

    [Route("api/public-organization")]
    public class PublicOrganizationController : BaseController
    {
        private readonly IPublicOrganizationService _publicOrganizationService;

        public PublicOrganizationController(IPublicOrganizationService publicOrganizationService)
        {
            _publicOrganizationService = publicOrganizationService;
        }

        // <summary>
        /// Add new public Organization
        /// </summary>
        /// <param name="publicOrganization"></param>
        /// <returns></returns>
        [HttpPost("add")]
        public async Task<Result<PublicOrganizationDto>> Add(CreatePublicOrganizationDto publicOrganization)
        {
            return await _publicOrganizationService.Add(publicOrganization);
        }

        /// <summary>
		/// Update public Organization
		/// </summary>
		/// <param name="publicOrganization"></param>
		/// <returns></returns>
		[HttpPost("update")]
        public async Task<Result> Update(UpdatePublicOrganizationDto publicOrganization)
        {
            return await _publicOrganizationService.Update(publicOrganization);
        }

        /// <summary>
        /// Get public Organization by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("get-by-id")]
        public async Task<Result<PublicOrganizationDto>> GetById(long id)
        {
            return await _publicOrganizationService.GetById(id);
        }

        /// <summary>
        /// Delete public Organization
        /// </summary>
        /// <param name="publicOrganization"></param>
        /// <returns></returns>
        [HttpPost("delete")]
        public async Task<Result> Delete(DeletePublicOrganizationDto publicOrganization)
        {
            return await _publicOrganizationService.Delete(publicOrganization);
        }

        /// <summary>
        /// Get all public Organization by filter
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-all")]
        public async Task<PagedResult<List<PublicOrganizationDto>>> GetAll([FromQuery] PublicOrganizationFilter filter)
        {
            return await _publicOrganizationService.GetAll(filter);
        }
    }
}
