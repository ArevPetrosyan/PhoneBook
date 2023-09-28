using PhoneBook.DAL.Models;

namespace PhoneBook.BLL.Filters
{
    public class PublicOrganizationFilter : BaseFilter<PublicOrganization>
    {
        public long? Id { get; set; }
        public string? Website { get; set; }
        public string? PublicInfo { get; set; }
        public long? ContactId { get; set; }

        public override IQueryable<PublicOrganization> CreateQuery(IQueryable<PublicOrganization> query)
        {
            if (Query is not null)
                return Query;

            if (Id.HasValue)
            {
                query = query.Where(x => x.Id == Id.Value);
            }

            if (!string.IsNullOrWhiteSpace(Website))
            {
                query = query.Where(x => x.Website.ToLower().Replace(" ", "").Contains(Website.ToLower().Replace(" ", "")));
            }

            if (ContactId.HasValue)
            {
                query = query.Where(x => x.ContactId == ContactId);
            }

            if (!string.IsNullOrWhiteSpace(PublicInfo))
            {
                query = query.Where(x => x.PublicInfo.ToLower().Replace(" ", "").Contains(PublicInfo.ToLower().Replace(" ", "")));
            }

            return query.OrderByDescending(x => x.Id);
        }
    }
}
