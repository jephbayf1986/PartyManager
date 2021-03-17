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
            try
            {
                var handlerType = typeof(IQueryHandler<TQuery, TOut>);

                var handler1 = serviceProvider.GetService(handlerType);

                var handler = handler1 as IQueryHandler<TQuery, TOut>;

                return handler.Handle(_query);
            }
            catch (InvalidOperationException ex) 
                when (ex.Source == "Microsoft.Extensions.DependencyInjection")
            {
                throw new MissingHandlerException(typeof(TQuery));
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}