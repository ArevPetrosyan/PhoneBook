using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PhoneBook.DAL.Models;

namespace PhoneBook.DAL.Configurations
{
    public abstract class BaseConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.IsDeleted);

            builder.HasIndex(x => x.CreatedDate);
        }
    }
}
