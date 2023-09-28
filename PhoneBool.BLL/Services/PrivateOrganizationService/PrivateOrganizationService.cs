using Ardalis.Result;
using Microsoft.EntityFrameworkCore;
using PhoneBook.BLL.Filters;
using PhoneBook.BLL.Mappers;
using PhoneBook.BLL.Services.ContactService;
using PhoneBook.DAL;
using PhoneBook.DAL.Models;
using PhoneBook.DTO.ContactDtos;
using PhoneBook.DTO.PrivateOrganizationDtos;

namespace PhoneBook.BLL.Services.PrivateOrganizationService
{
    public class PrivateOrganizationService : IPrivateOrganizationService
    {
        private readonly AppDbContext _db;
        private readonly IContactService _contactService;

        public PrivateOrganizationService(AppDbContext db, IContactService contactService)
        {
            _db = db;
            _contactService = contactService;
        }

        public async Task<Result<PrivateOrganizationDto>> Add(CreatePrivateOrganizationDto newPrivateOrganization)
        {
            var contact = newPrivateOrganization as CreateContactDto;
            var createdContact = await _contactService.Add(contact);

            var privateOrganization = new PrivateOrganization()
            {
                OrganizationType = newPrivateOrganization.OrganizationType,
                TaxId = newPrivateOrganization.TaxId,
                ContactId = createdContact.Value.Id
            };

            _db.PrivateOrganizations.Add(privateOrganization);
            await _db.SaveChangesAsync();

            return await GetById(privateOrganization.Id);
        }

        public async Task<Result> Delete(DeletePrivateOrganizationDto privateOrganization)
        {
            var item = await _db.PrivateOrganizations
                                   .FirstOrDefaultAsync(x => x.Id == privateOrganization.Id);

            if (item is null)
                return Result.NotFound();

            item.IsDeleted = true;

            await _db.SaveChangesAsync();

            return Result.Success();
        }

        public async Task<PagedResult<List<PrivateOrganizationDto>>> GetAll(PrivateOrganizationFilter filter)
        {
            var query = _db.PrivateOrganizations
                 .Include(x => x.Contact)
                 .AsQueryable();

            var entities = await filter.FilterObjects(query).ToListAsync();

            return new PagedResult<List<PrivateOrganizationDto>>(await filter.GetPagedInfoAsync(query), entities.MapToPrivateOrganizationDtos());
        }

        public async Task<Result<PrivateOrganizationDto>> GetById(long id)
        {
            var item = await _db.PrivateOrganizations
                                   .Include(x => x.Contact)
                                   .FirstOrDefaultAsync(x => x.Id == id);

            if (item is null)
                return Result.NotFound();

            return Result.Success(item.MapToPrivateOrganizationDto());
        }

        public async Task<Result> Update(UpdatePrivateOrganizationDto privateOrganization)
        {
            var item = await _db.PrivateOrganizations.FirstOrDefaultAsync(x => x.Id == privateOrganization.Id);

            if (item is null)
                return Result.NotFound();

            await _contactService.Update(privateOrganization as UpdateContactDto);

            item.TaxId = privateOrganization.TaxId.Trim();
            item.OrganizationType = privateOrganization.OrganizationType;

            await _db.SaveChangesAsync();

            return Result.Success();
        }
    }
}
