using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBook.DAL.Models;

namespace PhoneBook.DAL.Configurations
{
    public class ContactTypeConfiguration : BaseConfiguration<ContactType>
    {
        public override void Configure(EntityTypeBuilder<ContactType> builder)
        {
            base.Configure(builder);

            builder.ToTable("ContactType");

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(256);
        }
    }
}
