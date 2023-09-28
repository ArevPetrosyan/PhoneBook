using PhoneBook.DAL.Models;

namespace PhoneBook.BLL.Filters
{
    public class PrivateOrganizationFilter : BaseFilter<PrivateOrganization>
    {
        public long? Id { get; set; }
        public string? OrganizationType { get; set; }
        public string? TaxId { get; set; }
        public long? ContactId { get; set; }

        public override IQueryable<PrivateOrganization> CreateQuery(IQueryable<PrivateOrganization> query)
        {
            if (Query is not null)
                return Query;

            if (Id.HasValue)
            {
                query = query.Where(x => x.Id == Id.Value);
            }

            if (!string.IsNullOrWhiteSpace(OrganizationType))
            {
                query = query.Where(x => x.OrganizationType.ToLower().Replace(" ", "").Contains(OrganizationType.ToLower().Replace(" ", "")));
            }

            if (ContactId.HasValue)
            {
                query = query.Where(x => x.ContactId == ContactId);
            }

            if (!string.IsNullOrWhiteSpace(TaxId))
            {
                query = query.Where(x => x.TaxId.ToLower().Replace(" ", "").Contains(TaxId.ToLower().Replace(" ", "")));
            }

            return query.OrderByDescending(x => x.Id);
        }
    }
}
