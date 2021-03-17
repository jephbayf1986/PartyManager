namespace PartyManager.Application.Shared.Responding
{
    internal static class SuccessHandler
    {
        internal static Response ReturnSuccess(string message = "Request completed successfully")
            => Response.Succeed(StatusCode.Ok, message);

        internal static Response<T> ReturnInsertSuccess<T>(T id, string entityName)
        {
            var message = $"New {entityName} has been successfully created with Identity {id}";

            return Response<T>.Succeed(id, StatusCode.Created, message);
        }

        internal static Response ReturnInsertSuccess(string entityName)
        {
            var message = $"New {entityName} has been successfully created";

            return Response.Succeed(StatusCode.Created, message);
        }

        internal static Response ReturnUpdateSuccess(string entityName)
        {
            var message = $"{entityName} has been updated successfully";

            return Response.Succeed(StatusCode.Ok, message);
        }

        internal static Response ReturnDeleteSuccess(string entityName)
        {
            var message = $"{entityName} has been deleted successfully";

            return Response.Succeed(StatusCode.Ok, message);
        }

        internal static Response ReturnNoChangeSuccess(string entityName)
        {
            var message = $"No changes have been made to {entityName}";

            return Response.Succeed(StatusCode.Ok, message);
        }
    }
}