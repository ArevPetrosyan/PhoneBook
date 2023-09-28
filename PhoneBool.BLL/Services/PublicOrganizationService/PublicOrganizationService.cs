using Ardalis.Result;
using Microsoft.EntityFrameworkCore;
using PhoneBook.BLL.Filters;
using PhoneBook.BLL.Mappers;
using PhoneBook.BLL.Services.ContactService;
using PhoneBook.DAL;
using PhoneBook.DAL.Models;
using PhoneBook.DTO.ContactDtos;
using PhoneBook.DTO.PublicOrganizationDtos;

namespace PhoneBook.BLL.Services.PublicOrganizationService
{
    public class PublicOrganizationService : IPublicOrganizationService
    {
        public readonly AppDbContext _db;
        public readonly IContactService _contactService;

        public PublicOrganizationService(AppDbContext db, IContactService contactService)
        {
            _db = db;
            _contactService = contactService;
        }

        public async Task<Result<PublicOrganizationDto>> Add(CreatePublicOrganizationDto newPublicOrganization)
        {
            var contact = newPublicOrganization as CreateContactDto;
            var createdContact = await _contactService.Add(contact);

            var publicOrganization = new PublicOrganization()
            {
                PublicInfo = newPublicOrganization.PublicInfo,
                Website = newPublicOrganization.Website,
                ContactId = createdContact.Value.Id
            };

            _db.PublicOrganizations.Add(publicOrganization);
            await _db.SaveChangesAsync();

            return await GetById(publicOrganization.Id);
        }

        public async Task<Result> Delete(DeletePublicOrganizationDto PublicOrganization)
        {
            var item = await _db.PublicOrganizations
                                   .FirstOrDefaultAsync(x => x.Id == PublicOrganization.Id);

            if (item is null)
                return Result.NotFound();

            item.IsDeleted = true;

            await _db.SaveChangesAsync();

            return Result.Success();
        }

        public async Task<PagedResult<List<PublicOrganizationDto>>> GetAll(PublicOrganizationFilter filter)
        {
            var query = _db.PublicOrganizations
                 .Include(x => x.Contact)
                 .AsQueryable();

            var entities = await filter.FilterObjects(query).ToListAsync();

            return new PagedResult<List<PublicOrganizationDto>>(await filter.GetPagedInfoAsync(query), entities.MapToPublicOrganizationDtos());
        }

        public async Task<Result<PublicOrganizationDto>> GetById(long id)
        {
            var item = await _db.PublicOrganizations
                                   .Include(x => x.Contact)
                                   .FirstOrDefaultAsync(x => x.Id == id);

            if (item is null)
                return Result.NotFound();

            return Result.Success(item.MapToPublicOrganizationDto());
        }

        public async Task<Result> Update(UpdatePublicOrganizationDto publicOrganization)
        {
            var item = await _db.PublicOrganizations.FirstOrDefaultAsync(x => x.Id == publicOrganization.Id);

            if (item is null)
                return Result.NotFound();

            await _contactService.Update(publicOrganization as UpdateContactDto);

            item.PublicInfo = publicOrganization.PublicInfo;
            item.Website = publicOrganization.Website;

            await _db.SaveChangesAsync();

            return Result.Success();
        }
    }
}
