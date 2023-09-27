using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.DAL
{
    public static class AddDbContextExtention
    {

        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddDbContext<AppDbContext>(options =>
                                                   options.UseNpgsql(configuration.GetConnectionString("PhoneBook"), x =>
                                                   {
                                                       x.MigrationsHistoryTable("ef_migration_history");
                                                   })
                                               .UseSnakeCaseNamingConvention());
        }
    }
}
