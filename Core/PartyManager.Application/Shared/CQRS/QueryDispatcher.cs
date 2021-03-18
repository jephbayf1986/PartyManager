using PartyManager.Application.Shared.Exceptions;
using System;
using System.Threading.Tasks;

namespace PartyManager.Application.Shared.CQRS
{
    internal class QueryDispatcher<TQuery, TOut> : DispatcherBase<TOut>
        where TQuery : IQuery<TOut>
    {
        private TQuery _query;

        public QueryDispatcher(TQuery query)
        {
            _query = query;
        }

        public override Task<TOut> DispatchAsync(IServiceProvider serviceProvider)
        {
            var handlerType = typeof(IQueryHandler<TQuery, TOut>);

            var handlerObject = serviceProvider.GetService(handlerType);

            if (handlerObject == null)
            {
                throw new MissingHandlerException(typeof(TQuery));
            }

            var handler = handlerObject as IQueryHandler<TQuery, TOut>;

            return handler.Handle(_query);
        }
    }
}