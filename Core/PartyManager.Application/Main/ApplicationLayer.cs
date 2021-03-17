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
            var dispatcherBase = typeof(CommandDispatcher<,>);

            Type[] dispatcherTypeArgs = { command.GetType(), typeof(T), };

            Type dispatcherType = dispatcherBase.MakeGenericType(dispatcherTypeArgs);

            var dispatcher = Activator.CreateInstance(dispatcherType, command) as DispatcherBase<T>;

            return dispatcher.DispatchAsync(_serviceProvider);
        }

        public Task<T> Acquire<T>(IQuery<T> query)
        { 
            var dispatcherBase = typeof(QueryDispatcher<,>);
            
            Type[] dispatcherTypeArgs = { query.GetType(), typeof(T), };

            Type dispatcherType = dispatcherBase.MakeGenericType(dispatcherTypeArgs);

            var dispatcher = Activator.CreateInstance(dispatcherType, query) as DispatcherBase<T>;

            return dispatcher.DispatchAsync(_serviceProvider);
        }
    }
}