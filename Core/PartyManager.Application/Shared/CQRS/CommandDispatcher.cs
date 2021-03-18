using PartyManager.Application.Shared.Exceptions;
using PartyManager.Application.Shared.Validation;
using System;
using System.Threading.Tasks;

namespace PartyManager.Application.Shared.CQRS
{
    internal class CommandDispatcher<TCommand, TOut> : DispatcherBase<TOut>
        where TCommand : ICommandBase<TOut>
    {
        private TCommand _command;

        public CommandDispatcher(TCommand command)
        {
            _command = command;
        }

        public override Task<TOut> DispatchAsync(IServiceProvider serviceProvider)
        {
            try
            {
                var validatorObject = serviceProvider.GetService(typeof(IValidator<TCommand>));

                if (validatorObject != null)
                {
                    var validator = validatorObject as IValidator<TCommand>;

                    validator.Validate(_command);
                }

                var handlerType = typeof(ICommandHandler<TCommand, TOut>);

                var handlerObject = serviceProvider.GetService(handlerType);

                if (handlerObject == null)
                {
                    throw new MissingHandlerException(typeof(TCommand));
                }

                var handler = handlerObject as ICommandHandler<TCommand, TOut>;

                return handler.Handle(_command);
            }
            catch (Exception exception)
            {
                // ToDo: Handle Exception and cast to type
                //return ErrorHandler.AsHandledResponse(exception);
                throw;
            }
        }
    }
}
