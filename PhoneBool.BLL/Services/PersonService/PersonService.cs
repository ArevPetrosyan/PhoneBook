using Ardalis.Result;
using Microsoft.EntityFrameworkCore;
using PhoneBook.BLL.Filters;
using PhoneBook.BLL.Mappers;
using PhoneBook.BLL.Services.ContactService;
using PhoneBook.DAL;
using PhoneBook.DAL.Models;
using PhoneBook.DTO.ContactDtos;
using PhoneBook.DTO.PersonDtos;

namespace PhoneBook.BLL.Services.PersonService
{
    public class PersonService : IPersonService
    {
        private readonly AppDbContext _db;
        private readonly IContactService _contactService;

        public PersonService(AppDbContext db, IContactService contactService)
        {
            _db = db;
            _contactService = contactService;
        }

        public async Task<Result<PersonDto>> Add(CreatePersonDto newPerson)
        {
            var contact = newPerson as CreateContactDto;
            var createdContact = await _contactService.Add(contact);

            var person = new Person()
            {
                Email = newPerson.Email.Trim(),
                Address = newPerson.Address.Trim(),
                ContactId = createdContact.Value.Id
            };

            _db.Persons.Add(person);
            await _db.SaveChangesAsync();

            return await GetById(person.Id);
        }

        public async Task<Result> Delete(DeletePersonDto person)
        {
            var personItem = await _db.Persons
                                    .FirstOrDefaultAsync(x => x.Id == person.Id);

            if (personItem is null)
                return Result.NotFound();

            personItem.IsDeleted = true;

            await _db.SaveChangesAsync();

            return Result.Success();
        }

        public async Task<PagedResult<List<PersonDto>>> GetAll(PersonFilter filter)
        {
            var query = _db.Persons
                 .Include(x => x.Contact)
                 .AsQueryable();

            var entities = await filter.FilterObjects(query).ToListAsync();

            return new PagedResult<List<PersonDto>>(await filter.GetPagedInfoAsync(query), entities.MapToPersonDtos());
        }

        public async Task<Result<PersonDto>> GetById(long id)
        {
            var person = await _db.Persons
                                   .Include(x => x.Contact)
                                   .FirstOrDefaultAsync(x => x.Id == id);

            if (person is null)
                return Result.NotFound();

            return Result.Success(person.MapToPersonDto());
        }

        public async Task<Result> Update(UpdatePersonDto person)
        {
            var personItem = await _db.Persons.FirstOrDefaultAsync(x => x.Id == person.Id);

            if (personItem is null)
                return Result.NotFound();

            await _contactService.Update(person as UpdateContactDto);

            personItem.Email = person.Email.Trim();
            personItem.Address = person.Address;

            await _db.SaveChangesAsync();

            return Result.Success();
        }
    }
}
