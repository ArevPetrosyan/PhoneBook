using PhoneBook.DAL.Models;

namespace PhoneBook.BLL.Filters
{
    public class ContactFilter : BaseFilter<Contact>
    {
        public long? Id { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public long? ContactTypeId { get; set; }
        public string? TextComment { get; set; }

        public override IQueryable<Contact> CreateQuery(IQueryable<Contact> query)
        {
            if (Query is not null)
                return Query;

            if (Id.HasValue)
            {
                query = query.Where(x => x.Id == Id.Value);
            }

            if (!string.IsNullOrWhiteSpace(Name))
            {
                query = query.Where(x => x.Name.ToLower().Replace(" ", "").Contains(Name.ToLower().Replace(" ", "")));
            }

            if (ContactTypeId.HasValue)
            {
                query = query.Where(x => x.ContactTypeId == ContactTypeId);
            }

            if (!string.IsNullOrWhiteSpace(PhoneNumber))
            {
                query = query.Where(x => x.PhoneNumber.ToLower().Replace(" ", "").Contains(PhoneNumber.ToLower().Replace(" ", "")));
            }

            if (!string.IsNullOrWhiteSpace(TextComment))
            {
                query = query.Where(x => x.TextComment.ToLower().Replace(" ", "").Contains(TextComment.ToLower().Replace(" ", "")));
            }

            return query.OrderByDescending(x => x.Id);
        }
    }
}
