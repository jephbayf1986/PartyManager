using Microsoft.Extensions.DependencyInjection;
using PartyManager.Application.Main.Parties.Commands;
using PartyManager.Application.Main.Parties.Commands.Validators;
using PartyManager.Application.Main.Parties.Models;
using PartyManager.Application.Main.Parties.Queries;
using PartyManager.Application.Shared.CQRS;
using PartyManager.Application.Shared.Responding;
using PartyManager.Application.Shared.Validation;
using System.Collections.Generic;

namespace PartyManager.Application.Main.Parties
{
    public static class PartyBinder
    {
        public static void BindParty(this IServiceCollection services)
        {
            services.AddScoped<ICommandHandler<CreateParty, Response<int>>, CreatePartyHandler>();

            services.AddScoped<IValidator<CreateParty>, CreatePartyValidator>();
            
            services.AddScoped<IQueryHandler<GetPartySummaries, IEnumerable<PartySummaryDto>>, GetPartySummariesHandler>();
        }
    }
}