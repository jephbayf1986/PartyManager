using System;

namespace PartyManager.Application.Shared.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(object id, string entityName)
            : base($"{entityName} with identity {id} does not exist")
        {
        }
    }
}