using FlightTicketWebUI.Utilities.Abstract;
using Newtonsoft.Json;

namespace FlightTicketWebUI.Utilities.Concrete;

public class DataResult<T> : Result, IDataResult<T>
{
    [JsonConstructor]
    public DataResult(T data, bool success, string message) : base(success, message)
    {
        Data = data;
    }

    //[JsonConstructor]
    public DataResult(T data, bool success) : base(success)
    {
        Data = data;
    }

    public T Data { get; }
}
