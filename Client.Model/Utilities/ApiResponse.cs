namespace Client.Model.Utilities;


public class ApiResponse<T>
{
    public int StatusCode { get; set; }
    public string Message { get; set; }
    public T Data { get; set; }
    public bool Success { get; set; }
    public int TotalCount { get; set; }

    public ApiResponse()
    {

    }

    public ApiResponse(int statusCode, string message, T data)
    {
        this.StatusCode = statusCode;
        this.Message = message;
        this.Data = data;
    }
}