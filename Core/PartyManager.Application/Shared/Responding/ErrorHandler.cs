using PartyManager.Application.Shared.Exceptions;
using System;
using System.Linq;

namespace PartyManager.Application.Shared.Responding
{
    internal static class ErrorHandler
    {
        public static Response AsHandledResponse(this Exception error)
        {
            if (error is ValidationException)
            {
                return InvalidRequest((ValidationException)error);
            }

            if (error is NotFoundException)
            {
                return NotFoundError((NotFoundException)error);
            }

            return UndefinedError(error);
        }

        public static Response<T> WithDefaultPayload<T>(this Response response)
        {
            return new Response<T>()
            {
                Payload = default,
                Success = false,
                StatusCode = response.StatusCode,
                Message = response.Message
            };
        }

        private static Response NotFoundError(NotFoundException error)
            => Response.Fail(StatusCode.NotFound, error.Message);

        private static Response InvalidRequest(ValidationException error)
        {
            var result = error.ValidationResult;

            var message = $"The request returned {result.NumberOfFailures} validation error(s): {result.Failures.First().RuleBroken}";

            return Response.Fail(StatusCode.BadRequest, message);
        }

        private static Response UndefinedError(Exception error)
            => Response.Fail(StatusCode.InternalError, error.Message);
    }
}