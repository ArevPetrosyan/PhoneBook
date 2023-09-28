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
                CreatedDate = DateTime.Parse("2023-09-28 13:58:03").ToUniversalTime(),
                Name = "Person"
            });

            modelBuilder.Entity<ContactType>().HasData(new ContactType
            {
                Id = 2,
                IsDeleted = false,
                CreatedDate = DateTime.Parse("2023-09-28 13:58:03").ToUniversalTime(),
                Name = "Private organization"
            });

            modelBuilder.Entity<ContactType>().HasData(new ContactType
            {
                Id = 3,
                IsDeleted = false,
                CreatedDate = DateTime.Parse("2023-09-28 13:58:03").ToUniversalTime(),
                Name = "Public organization"
            });
        }
    }
}
