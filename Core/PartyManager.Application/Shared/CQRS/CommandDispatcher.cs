using PartyManager.Application.Shared.Exceptions;
using PartyManager.Application.Shared.Responding;
using PartyManager.Application.Shared.Validation;
using System;
using System.Threading.Tasks;

namespace PartyManager.Application.Shared.CQRS
{
    internal class CommandDispatcher<TCommand, TOut> : DispatcherBase<TOut>
        where TCommand : ICommandBase<TOut>
        where TOut : Response, new()
    {
        private TCommand _command;

        public CommandDispatcher(TCommand command)
        {
            _command = command;
        }

        public override async Task<TOut> DispatchAsync(IServiceProvider serviceProvider)
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

                return await handler.Handle(_command);
            }
            catch (Exception exception)
            {
                return GetErrorResponse(exception);
            }
        }

        private TOut GetErrorResponse(Exception exception)
        {
            var responseTarget = ErrorHandler.AsHandledResponse(exception);

            var response = new TOut() as Response;

            response.Success = false;
            response.StatusCode = response.StatusCode;
            response.Message = responseTarget.Message;

            return (TOut)response;
        }
    }
}
