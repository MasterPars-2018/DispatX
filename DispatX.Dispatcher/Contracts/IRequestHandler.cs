namespace DispatX.Dispatcher.Contracts;

public interface IRequestHandler<in TQuery, TResult> where TQuery : class, IRequest<TResult>
{
    Task<TResult> HandleAsync(TQuery query);
}
