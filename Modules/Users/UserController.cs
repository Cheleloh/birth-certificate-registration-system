using BirthCertificateRegistrationSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BirthCertificateRegistrationSystem.Modules.Users;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Create a new user")]
    public async Task<ActionResult<User>> CreateUser(UserRequest request)
    {
        var user = await _userService.createUser(request);
        return Ok(user);
    }
}