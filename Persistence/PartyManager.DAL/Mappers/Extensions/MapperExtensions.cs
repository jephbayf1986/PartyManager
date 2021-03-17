using PartyManager.Application.Shared.Exceptions;
using System;

namespace PartyManager.DAL.Mappers.Extensions
{
    internal static class MapperExtensions
    {
        public static int ToInt(this object data)
        {
            var isNumeric = int.TryParse(data.ToString(), out int value);

            if (isNumeric)
            {
                return value;
            }

            throw new DataMappingException(data, typeof(int));
        }

        public static int? ToNullableInt(this object data)
        {
            if (data == null)
            {
                return (int?)null;
            }

            return data.ToInt();
        }

        public static DateTime ToDateTime(this object data)
        {
            var isDate = DateTime.TryParse(data.ToString(), out DateTime value);

            if (isDate)
            {
                return value;
            }

            throw new DataMappingException(data, typeof(int));
        }
    }
}