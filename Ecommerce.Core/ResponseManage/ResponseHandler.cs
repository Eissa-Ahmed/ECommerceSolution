namespace Ecommerce.Core.ResponseManage;

public class ResponseHandler
{
    public Response<T> Deleted<T>(string? Message = null)
    {
        return new Response<T>()
        {
            StatusCode = System.Net.HttpStatusCode.OK,
            Succeeded = true,
            Message = Message
        };
    }
    public Response<T> Success<T>(T entity, object? Meta = null)
    {
        return new Response<T>()
        {
            Data = entity,
            StatusCode = HttpStatusCode.OK,
            Succeeded = true,
            Message = "Success",
            Meta = Meta
        };
    }
    public Response<T> Unauthorized<T>(string? Message = null)
    {
        return new Response<T>()
        {
            StatusCode = System.Net.HttpStatusCode.Unauthorized,
            Succeeded = true,
            Message = Message
        };
    }
    public Response<T> BadRequest<T>(string? Message = null)
    {
        return new Response<T>()
        {
            StatusCode = System.Net.HttpStatusCode.BadRequest,
            Succeeded = false,
            Errors = new List<string>() { Message }
        };
    }

    public Response<T> UnprocessableEntity<T>(string? Message = null)
    {
        return new Response<T>()
        {
            StatusCode = System.Net.HttpStatusCode.UnprocessableEntity,
            Succeeded = false,
            Message = Message
        };
    }


    public Response<T> NotFound<T>(string? message = null)
    {
        return new Response<T>()
        {
            StatusCode = System.Net.HttpStatusCode.NotFound,
            Succeeded = false,
            Message = message
        };
    }

    public Response<T> Created<T>(T entity, object? Meta = null)
    {
        return new Response<T>()
        {
            Data = entity,
            StatusCode = System.Net.HttpStatusCode.Created,
            Succeeded = true,
            Message = "Success",
            Meta = Meta
        };
    }
}
