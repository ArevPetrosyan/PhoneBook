using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhoneBook.DAL;
using PhoneBook.BLL.Services.ContactService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.BLL
{
    public static class ServiceExtension
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {           
            services.AddScoped<IContactService, ContactService>();

            services.AddMemoryCache();

            return services;
        }
    }
}
