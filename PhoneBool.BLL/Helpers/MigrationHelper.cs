using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PhoneBook.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.BLL.Helpers
{
    public static class MigrationHelper
    {
        public static async Task DatabaseMigrate(this WebApplication app)
        {
            await using var scope = app.Services.CreateAsyncScope();
            using var db = scope.ServiceProvider.GetService<AppDbContext>();
            await db.Database.MigrateAsync();
        }
    }
}
