using Microsoft.EntityFrameworkCore;
using PhoneBook.DAL.Models;

namespace PhoneBook.DAL.Seeders
{
    internal static class ContactTypeSeeder
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactType>().HasData(new ContactType
            {
                Id = 1,
                IsDeleted = false,
                Name = "Person"
            });

            modelBuilder.Entity<ContactType>().HasData(new ContactType
            {
                Id = 2,
                IsDeleted = false,
                Name = "Private organization"
            });

            modelBuilder.Entity<ContactType>().HasData(new ContactType
            {
                Id = 3,
                IsDeleted = false,
                Name = "Public organization"
            });
        }
    }
}
