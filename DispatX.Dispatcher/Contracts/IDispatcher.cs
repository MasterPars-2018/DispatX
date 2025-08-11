namespace DispatX.Dispatcher.Contracts;

public interface IDispatcher
{
    Task<TResult> SendAsync<TResult>(IRequest<TResult> query);
}
