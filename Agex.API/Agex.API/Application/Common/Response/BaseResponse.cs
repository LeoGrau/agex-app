namespace Agex.API.Application.Common.Response;

public class BaseResponse <T> where T : class
{
    public BaseResponse(T data, string message = "")
    {
        Message = message;
        Success = true;
        Data = data;
    }

    public BaseResponse(string message = "")
    {
        Message = message;
        Success = false;
        Data = null;
    }

    public string Message { get; set; } 
    public bool Success { get; set; }
    public T? Data { get; set; }
    
}