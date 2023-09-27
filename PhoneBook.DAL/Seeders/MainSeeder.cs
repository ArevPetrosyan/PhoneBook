using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
