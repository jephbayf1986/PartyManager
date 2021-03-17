using System;

namespace PartyManager.Application.Shared.Exceptions
{
    public class DataMappingException : Exception
    {
        public DataMappingException(object fieldValue, Type targetType)
            : base($"An error occured mapping the database value '{fieldValue}' to type {targetType.Name}")
        {
        }
    }
}