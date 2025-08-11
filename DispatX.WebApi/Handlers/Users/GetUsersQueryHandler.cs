using DispatX.Dispatcher.Contracts;
using DispatX.WebApi.DTOs;

namespace DispatX.WebApi.Handlers.Users;

public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<UserDto>>
{
    public async Task<List<UserDto>> HandleAsync(GetUsersQuery query)
    {

        var users = new List<UserDto>();
        for (int i = 1; i <= query.Count; i++)
        {
            users.Add(new UserDto() { Email = $"email.{i}@gmail.com", Name = $"User {i}" });
        }

        return users;
    }
}
