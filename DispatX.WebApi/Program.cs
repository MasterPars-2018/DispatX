

using DispatX.Dispatcher;
using DispatX.Dispatcher.Contracts;
using DispatX.WebApi.Handlers.Users;
using Microsoft.AspNetCore.Components;

var builder = WebApplication.CreateBuilder(args);
 
builder.Services.AddDispatcher(); // Adding DispatX.Dispatcher
 

var app = builder.Build();

app.MapGet("/",( ) =>  Results.Ok("Call /users/{count}")   );

app.Map("/users/{count:int}", async (IDispatcher _dispatcher,int count) =>
{
    var data = await _dispatcher.SendAsync(new GetUsersQuery { Count = count });

    return Results.Ok(data);

});

app.UseHttpsRedirection();
app.UseRouting();
 
app.Run();
