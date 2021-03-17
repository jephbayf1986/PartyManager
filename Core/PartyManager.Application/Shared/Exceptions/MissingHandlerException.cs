using System;

namespace PartyManager.Application.Shared.Exceptions
{
    public class MissingHandlerException : Exception
    {
        public MissingHandlerException(Type requestType)
            : base ($"A handler was not found for request {requestType.Name}")
        {
        }
    }
}