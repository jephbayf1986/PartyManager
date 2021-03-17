using System.Collections.Generic;
using System.Linq;

namespace PartyManager.Application.Shared.Mapping
{
    public static class MappingExtension1
    {
        public static MappingExtension2<TIn> Map<TIn>(this TIn entityIn)
            where TIn : class
        {
            return new MappingExtension2<TIn>(entityIn);
        }
    }

    public class MappingExtension2<TIn>
        where TIn : class
    {
        private TIn _EntityIn;

        public MappingExtension2(TIn entityIn)
        {
            _EntityIn = entityIn;
        }

        public MappingExtension3<TIn, TOut> To<TOut>() 
            where TOut : class, new()
        {
            return new MappingExtension3<TIn, TOut>(_EntityIn);
        }
    }

    public class MappingExtension3<TIn, TOut>
        where TIn : class
        where TOut : class, new()
    {
        private TIn _EntityIn;

        public MappingExtension3(TIn entityIn)
        {
            _EntityIn = entityIn;
        }

        public TOut WithMapper<TMapper>()
            where TMapper : IMapper<TIn, TOut>, new()
        {
            var mapper = new TMapper();

            return mapper.Map(_EntityIn);
        }
    }

    public static class MappingExtension4
    {
        public static MappingExtension5<TIn> Map<TIn>(this IEnumerable<TIn> entitiesIn)
            where TIn : class
        {
            return new MappingExtension5<TIn>(entitiesIn);
        }
    }

    public class MappingExtension5<TIn>
        where TIn : class
    {
        private IEnumerable<TIn> _EntitiesIn;

        public MappingExtension5(IEnumerable<TIn> entitiesIn)
        {
            _EntitiesIn = entitiesIn;
        }

        public MappingExtension6<TIn, TOut> ToEnumerable<TOut>()
            where TOut : class, new()
        {
            return new MappingExtension6<TIn, TOut>(_EntitiesIn);
        }
    }

    public class MappingExtension6<TIn, TOut>
        where TIn : class
        where TOut : class, new()
    {
        private IEnumerable<TIn> _EntitiesIn;

        public MappingExtension6(IEnumerable<TIn> entitiesIn)
        {
            _EntitiesIn = entitiesIn;
        }

        public IEnumerable<TOut> WithMapper<TMapper>()
            where TMapper : IMapper<TIn, TOut>, new()
        {
            var mapper = new TMapper();

            return _EntitiesIn.Select(x => mapper.Map(x));
        }
    }
}