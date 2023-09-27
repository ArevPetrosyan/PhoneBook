using Ardalis.Result;
using Microsoft.EntityFrameworkCore;
using PhoneBook.BLL.Mappers;
using PhoneBook.BLL.Services.ContactService;
using PhoneBook.DAL;
using PhoneBook.DAL.Models;
using PhoneBook.DTO.ContactDtos;
using PhoneBook.DTO.PublicOrganizationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
