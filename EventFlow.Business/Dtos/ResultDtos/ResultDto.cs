namespace EventFlow.Business.Dtos;

public class ResultDto
{
    public bool IsSuccess { get; set; }
    public int StatusCode { get; set; }
    public string Message { get; set; } = string.Empty;

    public ResultDto()
    {
        IsSuccess = true;
        StatusCode = 200;
        Message = "Successfully";
    }

    public ResultDto(string message) : this()
    {
        Message = message;
    }

    public ResultDto(string message, int statusCode) : this(message)
    {
        Message = message;
        StatusCode = statusCode;
    }

    public ResultDto(string message, int statusCode, bool isSucced) : this(message, statusCode)
    {
        Message = message;
        StatusCode = statusCode;
        IsSuccess = isSucced;
    }
}


public class ResultDto<T> : ResultDto
{
    public T? Data { get; set; }
    public ResultDto() : base()
    {
    }
    public ResultDto(T data) : base()
    {
        Data = data;
    }
    public ResultDto(T data, string message) : base(message)
    {
        Data = data;
        Message = message;
    }
    public ResultDto(T data, string message, int statusCode) : base(message, statusCode)
    {
        Data = data;
        Message = message;
        StatusCode = statusCode;
    }
    public ResultDto(T data, string message, int statusCode, bool isSucced) : base(message, statusCode, isSucced)
    {
        Data = data;
        Message = message;
        StatusCode = statusCode;
        IsSuccess = isSucced;
    }
}