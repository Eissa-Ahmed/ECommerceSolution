namespace Ecommerce.Core.ResponseManage;

public class Response<T>
{
    public Response()
    {
        Errors = new List<string>();
    }
    public HttpStatusCode StatusCode { get; set; }
    public bool Succeeded { get; set; }
    public string Message { get; set; } = null!;
    public List<string> Errors { get; set; }
    public T? Data { get; set; }
    public object? Meta { get; set; }
}
