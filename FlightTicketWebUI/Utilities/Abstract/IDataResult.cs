namespace FlightTicketWebUI.Utilities.Abstract;

public interface IDataResult<out T> : IResult
{
    T Data { get; }
}
