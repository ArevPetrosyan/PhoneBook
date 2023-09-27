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
    public class PrivateOrganizationContactConfiguration : BaseConfiguration<PrivateOrganization>
    {
        public override void Configure(EntityTypeBuilder<PrivateOrganization> builder)
        {
            base.Configure(builder);

            builder.ToTable("PrivateOrganization");

            builder.Property(x => x.OrganizationType).IsRequired();

            builder.Property(x => x.TaxId).IsRequired();
        }
    }
}
