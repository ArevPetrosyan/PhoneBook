using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhoneBook.BLL.Services.ContactService;
using PhoneBook.BLL.Services.PersonService;
using PhoneBook.BLL.Services.PrivateOrganizationService;
using PhoneBook.BLL.Services.PublicOrganizationService;

namespace PhoneBook.BLL
{
    public static class ServiceExtension
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {           
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IPrivateOrganizationService, PrivateOrganizationService>();
            services.AddScoped<IPublicOrganizationService, PublicOrganizationService>();

            services.AddMemoryCache();

            return services;
        }
    }
}
