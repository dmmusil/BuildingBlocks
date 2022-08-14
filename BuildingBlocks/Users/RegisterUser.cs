using Microsoft.AspNetCore.Mvc;

namespace BuildingBlocks.Users;

[ApiController]
public class RegisterUser : ControllerBase
{
    private readonly IUserRepository _users;

    public RegisterUser(IUserRepository users) => _users = users;

    [HttpPost("users/register")]
    public async Task<IActionResult> Register([FromBody] User user)
    {   
        await _users.Register(user);
        return Created($"/users/{user.Name}", user);
    }
}

[ApiController]
public class GetUser : ControllerBase
{
    private readonly IUserRepository _users;

    public GetUser(IUserRepository users) => _users = users;

    [HttpGet("users/{name}")]
    public async Task<IActionResult> Get(string name)
    {
        var user = await _users.WithName(name);
        return user != null ? Ok(user) : NotFound();
    }
}

public interface IUserRepository
{
    Task Register(User user);
    Task<User?> WithName(string name);
}

class UserRepository : IUserRepository
{
    private readonly HashSet<User> _users = new();
    public Task Register(User user)
    {
        _users.Add(user);
        return Task.CompletedTask;
    }

    public Task<User?> WithName(string name) => Task.FromResult(_users.FirstOrDefault(u => u.Name == name));
}