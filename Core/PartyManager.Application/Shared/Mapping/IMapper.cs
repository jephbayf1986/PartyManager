namespace PartyManager.Application.Shared.Mapping
{
    public interface IMapper<TIn, TOut>
        where TIn : class
        where TOut : class, new()
    {
        TOut Map(TIn entityIn);
    }
}
