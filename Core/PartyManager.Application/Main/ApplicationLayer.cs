using PartyManager.Application.Shared.CQRS;
using System;
using System.Threading.Tasks;

namespace PartyManager.Application.Main
{
    public class ApplicationLayer : IApplicationLayer
    {
        private readonly IServiceProvider _serviceProvider;

        public ApplicationLayer(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task<T> Execute<T>(ICommandBase<T> command)
        {
            var dispatcher = GetDispatcherBase<T>(command, typeof(CommandDispatcher<,>));

            return dispatcher.DispatchAsync(_serviceProvider);
        }

        public Task<T> Get<T>(IQuery<T> query)
        { 
            var dispatcher = GetDispatcherBase<T>(query, typeof(QueryDispatcher<,>));

            return dispatcher.DispatchAsync(_serviceProvider);
        }

        private DispatcherBase<T> GetDispatcherBase<T>(object request, Type dispatcher)
        {
            Type[] dispatcherTypeArgs = { request.GetType(), typeof(T), };

            Type dispatcherType = dispatcher.MakeGenericType(dispatcherTypeArgs);

            return Activator.CreateInstance(dispatcherType, request) as DispatcherBase<T>;
        }
    }
}