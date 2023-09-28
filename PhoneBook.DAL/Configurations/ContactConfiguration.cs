using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBook.DAL.Models;

namespace PhoneBook.DAL.Configurations
{
    public class ContactConfiguration : BaseConfiguration<Contact>
    {
        public override void Configure(EntityTypeBuilder<Contact> builder)
        {
            base.Configure(builder);

            builder.ToTable("Contact");

            builder.Property(x => x.PhoneNumber).IsRequired();

            builder.Property(x => x.ContactTypeId).IsRequired();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(256);
        }
    }
}
