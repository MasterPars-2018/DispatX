using DispatX.Dispatcher.Contracts;
using DispatX.WebApi.DTOs;

namespace DispatX.WebApi.Handlers.Users;

public class GetUsersQuery : IRequest<List<UserDto>>
{
    public int Count { get; set; } = 10;
}
