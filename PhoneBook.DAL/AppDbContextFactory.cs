using Microsoft.EntityFrameworkCore;

namespace PhoneBook.DAL
{
    public class AppDbContextFactory : DesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContextFactory()
        {

        }

        protected override AppDbContext CreateNewInstance(DbContextOptions<AppDbContext> options)
        {
            return new AppDbContext(options);
        }
    }
}
