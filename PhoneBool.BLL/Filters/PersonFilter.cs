using PhoneBook.DAL.Models;

namespace PhoneBook.BLL.Filters
{
    public class PersonFilter : BaseFilter<Person>
    {
        public long? Id { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public long? ContactId { get; set; }

        public override IQueryable<Person> CreateQuery(IQueryable<Person> query)
        {
            if (Query is not null)
                return Query;

            if (Id.HasValue)
            {
                query = query.Where(x => x.Id == Id.Value);
            }

            if (!string.IsNullOrWhiteSpace(Email))
            {
                query = query.Where(x => x.Email.ToLower().Replace(" ", "").Contains(Email.ToLower().Replace(" ", "")));
            }

            if (ContactId.HasValue)
            {
                query = query.Where(x => x.ContactId == ContactId);
            }

            if (!string.IsNullOrWhiteSpace(Address))
            {
                query = query.Where(x => x.Address.ToLower().Replace(" ", "").Contains(Address.ToLower().Replace(" ", "")));
            }

            return query.OrderByDescending(x => x.Id);
        }
    }
}
