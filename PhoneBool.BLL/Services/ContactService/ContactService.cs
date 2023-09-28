using Ardalis.Result;
using PhoneBook.DAL;
using PhoneBook.DTO.ContactDtos;
using PhoneBook.DAL.Models;
using PhoneBook.BLL.Mappers;
using Microsoft.EntityFrameworkCore;
using PhoneBook.BLL.Filters;

namespace PhoneBook.BLL.Services.ContactService
{
    public class ContactService : IContactService
    {
        private readonly AppDbContext _db;

        public ContactService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Result<ContactDto>> Add(CreateContactDto newContact)
        {
            var contact = new Contact()
            {
                Name = newContact.Name.Trim(),
                PhoneNumber = newContact.PhoneNumber,
                ContactTypeId = newContact.ContactTypeId,
                TextComment = newContact.TextComment
            };

            _db.Contacts.Add(contact);
            await _db.SaveChangesAsync();

            return await GetById(contact.Id);
        }

        public async Task<Result> Delete(DeleteContactDto contact)
        {
            var contactItem = await _db.Contacts
                                    .FirstOrDefaultAsync(x => x.Id == contact.Id);

            if (contactItem is null)
                return Result.NotFound();

            contactItem.IsDeleted = true;

            await _db.SaveChangesAsync();

            return Result.Success();
        }

        public async Task<Result<ContactDto>> GetById(long id)
        {
            var contact = await _db.Contacts
                                   .Include(x => x.ContactType)
                                   .FirstOrDefaultAsync(x => x.Id == id);

            if (contact is null)
                return Result.NotFound();

            return Result.Success(contact.MapToContactDto());
        }

        public async Task<Result> Update(UpdateContactDto contact)
        {
            var contactItem = await _db.Contacts.FirstOrDefaultAsync(x => x.Id == contact.Id);

            if (contactItem is null)
                return Result.NotFound();

            contactItem.Name = contact.Name.Trim();
            contactItem.PhoneNumber = contact.PhoneNumber;
            contactItem.ContactTypeId = contact.ContactTypeId;
            contactItem.TextComment = contact.TextComment;

            await _db.SaveChangesAsync();

            return Result.Success();
        }

        public async Task<PagedResult<List<ContactDto>>> GetAll(ContactFilter filter)
        {
            var query = _db.Contacts
                .Include(x => x.ContactType)
                .AsQueryable();

            var entities = await filter.FilterObjects(query).ToListAsync();

            return new PagedResult<List<ContactDto>>(await filter.GetPagedInfoAsync(query), entities.MapToContactDtos());
        }
    }
}
