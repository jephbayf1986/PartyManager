using Microsoft.Extensions.DependencyInjection;
using PartyManager.Application.Main.Party.Commands;
using PartyManager.Application.Main.Party.Commands.Validators;
using PartyManager.Application.Main.Party.Models;
using PartyManager.Application.Main.Party.Queries;
using PartyManager.Application.Shared.CQRS;
using PartyManager.Application.Shared.Responding;
using PartyManager.Application.Shared.Validation;
using System.Collections.Generic;

namespace PartyManager.Application.Main.Party
{
    public static class PartyBinder
    {
        public static void BindParty(this IServiceCollection services)
        {
            services.AddScoped<ICommandHandler<CreateParty, Response<int>>, CreatePartyHandler>();

            services.AddScoped<IValidator<CreateParty>, CreatePartyValidator>();
            
            services.AddScoped<IQueryHandler<GetParties, IEnumerable<PartyDto>>, GetPartiesHandler>();
        }
    }
}