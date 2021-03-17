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

        public static bool ToBool(this object data)
        {
            var isBoolean = bool.TryParse(data.ToString(), out bool value);

            if (isBoolean)
            {
                return value;
            }

            throw new DataMappingException(data, typeof(bool));
        }

        public static bool? ToNullableBool(this object data)
        {
            if (data == null)
            {
                return (bool?)null;
            }

            return data.ToBool();
        }

        public static DateTime ToDateTime(this object data)
        {
            var isDate = DateTime.TryParse(data.ToString(), out DateTime value);

            if (isDate)
            {
                return value;
            }

            throw new DataMappingException(data, typeof(DateTime));
        }

        public static DateTime? ToNullableDateTime(this object data)
        {
            if (data == null)
            {
                return (DateTime?)null;
            }

            return data.ToDateTime();
        }
    }
}