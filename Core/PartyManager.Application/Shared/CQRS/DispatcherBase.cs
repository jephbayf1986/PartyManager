using System;
using System.Threading.Tasks;

namespace PartyManager.Application.Shared.CQRS
{
    internal abstract class DispatcherBase<TOut>
    {
        public abstract Task<TOut> DispatchAsync(IServiceProvider serviceProvider);
    }
}