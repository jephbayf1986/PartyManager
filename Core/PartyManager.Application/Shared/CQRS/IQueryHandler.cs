using System.Threading.Tasks;

namespace PartyManager.Application.Shared.CQRS
{
    public interface IQueryHandler<in TRequest, TReturn>
        where TRequest : IQuery<TReturn>
    {
        Task<TReturn> Handle(TRequest command);
    }
}