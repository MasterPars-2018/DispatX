using DispatX.Dispatcher.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DispatX.Dispatcher;

public sealed class InMemoryRequestDispatcher : IDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public InMemoryRequestDispatcher(IServiceProvider serviceProvider)
        => _serviceProvider = serviceProvider;

    public async Task<TResult> SendAsync<TResult>(IRequest<TResult> request)
    {
        ArgumentNullException.ThrowIfNull(request);
        using var scope = _serviceProvider.CreateScope();
        var handlerType = typeof(IRequestHandler<,>).MakeGenericType(request.GetType(), typeof(TResult));
        var handler = scope.ServiceProvider.GetRequiredService(handlerType);

        return await (Task<TResult>)handlerType.GetMethod(nameof(IRequestHandler<IRequest<TResult>, TResult>.HandleAsync))?
            .Invoke(handler, new[] { request });
    }
}
