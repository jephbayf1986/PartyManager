using PartyManager.Application.Shared.Exceptions;
using System;
using System.Threading.Tasks;

namespace PartyManager.Application.Shared.CQRS
{
    internal class CommandDispatcher<TCommand, TOut> : DispatcherBase<TOut>
        where TCommand : ICommandBase<TOut>
    {
        private TCommand _command;

        public CommandDispatcher(TCommand query)
        {
            _command = query;
        }

        public override Task<TOut> DispatchAsync(IServiceProvider serviceProvider)
        {
            try
            {
                var handlerType = typeof(ICommandHandler<TCommand, TOut>);

                var handler1 = serviceProvider.GetService(handlerType);

                var handler = handler1 as ICommandHandler<TCommand, TOut>;

                return handler.Handle(_command);
            }
            catch (InvalidOperationException ex)
                when (ex.Source == "Microsoft.Extensions.DependencyInjection")
            {
                throw new MissingHandlerException(typeof(TCommand));
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
