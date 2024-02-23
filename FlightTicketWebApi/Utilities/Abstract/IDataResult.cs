namespace FlightTicketWebApi.Utilities.Abstract;

public interface IDataResult<out T> : IResult
{
    T Data { get; }
}
