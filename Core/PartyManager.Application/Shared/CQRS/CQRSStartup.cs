using Microsoft.Extensions.DependencyInjection;
using PartyManager.Application.Shared.Validation;
using System;
using System.Linq;
using System.Reflection;

namespace PartyManager.Application.Shared.CQRS
{
    public static class CQRSStartup
    {
        public static void BindCQRSPipeline(this IServiceCollection services)
        {
            services.BindPipelineComponent(typeof(IQueryHandler<,>));
            services.BindPipelineComponent(typeof(ICommandHandler<,>));
            services.BindPipelineComponent(typeof(IValidator<>));
        }

        private static void BindPipelineComponent(this IServiceCollection services, Type componentInterface)
        {
            var assembly = Assembly.GetExecutingAssembly();

            var components = assembly.GetTypes()
                                        .Where(x => x.GetInterfaces().Any(i => i.IsGenericType
                                                                            && i.GetGenericTypeDefinition() == componentInterface));

            foreach (var component in components)
            {
                services.AddScoped(component.GetInterfaces()
                                          .First(i => i.IsGenericType && i.GetGenericTypeDefinition() == componentInterface), component);
            }
        }
    }
}