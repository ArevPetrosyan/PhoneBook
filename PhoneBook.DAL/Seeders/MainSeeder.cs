using Microsoft.EntityFrameworkCore;

namespace PhoneBook.DAL.Seeders
{
    internal static class MainSeeder
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            ContactTypeSeeder.SeedData(modelBuilder);
        }
    }
}
