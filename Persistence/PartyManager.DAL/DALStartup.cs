using Microsoft.Extensions.DependencyInjection;
using PartyManager.Application.Shared.DataAccess.Interfaces;
using PartyManager.DAL.DataProviders;
using PartyManager.DAL.Infrastructure;

namespace PartyManager.DAL
{
    public static class DALStartup
    {
        public static void RegisterDataProviders(this IServiceCollection services)
        {
            services.AddTransient<IDbCore, DbCore>();

            services.AddTransient<IPartyDataProvider, PartyDataProvider>();
            services.AddTransient<IPersonDataProvider, PersonDataProvider>();
            services.AddTransient<IPartyGuestDataProvider, PartyGuestDataProvider>();
            services.AddTransient<IDrinkDataProvider, DrinkDataProvider>();
        }
    }
}