using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBook.DAL.Models;

namespace PhoneBook.DAL.Configurations
{
    public class PersonContactConfiguration : BaseConfiguration<Person>
    {
        public override void Configure(EntityTypeBuilder<Person> builder)
        {
            base.Configure(builder);

            builder.ToTable("Person");

            builder.Property(x => x.Address).IsRequired();

            builder.Property(x => x.Email).IsRequired();
        }
    }
}
