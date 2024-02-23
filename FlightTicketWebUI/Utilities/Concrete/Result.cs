using Newtonsoft.Json;

namespace FlightTicketWebUI.Utilities.Concrete;

public class Result : Abstract.IResult
{
    public Result(bool success, string message) : this(success)
    {
        Message = message;
    }

    [JsonConstructorAttribute]
    public Result()
    {
    }

    public Result(bool success)
    {
        Success = success;
    }

    public bool Success { get; }
    public string Message { get; }
}
