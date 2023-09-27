using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBook.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
