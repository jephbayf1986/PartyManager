using Microsoft.Extensions.DependencyInjection;
using PartyManager.Application.Main.Party;

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