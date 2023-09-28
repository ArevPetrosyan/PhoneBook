using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBook.DAL.Models;

namespace PhoneBook.DAL.Configurations
{
    public class PublicOrganizationContactConfiguration : BaseConfiguration<PublicOrganization>
    {
        public override void Configure(EntityTypeBuilder<PublicOrganization> builder)
        {
            base.Configure(builder);

            builder.ToTable("PublicOrganization");

            builder.Property(x => x.PublicInfo).IsRequired();

            builder.Property(x => x.Website).IsRequired();
        }
    }
}
