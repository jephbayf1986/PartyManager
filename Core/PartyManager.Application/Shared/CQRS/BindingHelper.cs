using Microsoft.Extensions.DependencyInjection;
using PartyManager.Application.Main.Parties;

namespace PartyManager.Application.Shared.CQRS
{
    public static class BindingHelper
    {
        public static void BindCQRS(this IServiceCollection services)
        {
            services.BindParty();
        }
    }
}