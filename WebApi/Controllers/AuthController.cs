using Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;



/// <summary>
/// All the endpoint the Api has to be protected, allowing the access to different actions depending on the generated token
/// </summary>
public class AuthController : BaseApiController
{
    private readonly IJwtProvider _jwtProvider;

    //all the valid roles we can use
    private readonly List<string> _validRoles = new List<string>{"Admin", "Security", "Guest"};

    public AuthController(IJwtProvider jwtProvider)

    {
        _jwtProvider = jwtProvider;
    }

    [HttpGet("generate-token")]
    [AllowAnonymous]
    //this allows to be available for everyone to create a token(it generates depending on the role it has)
    public IActionResult Generate([FromQuery] IEnumerable<string> roles)
    {
        //verifies if the role is in the _validRoles var
        if (roles == null || !roles.Any() || !roles.All(role => _validRoles.Contains(role)))
        {
            return BadRequest("It is needed to proportioned a role.");
        }

        string token = _jwtProvider.GenerateAllRoles(roles);

        return Ok(token);
    }

    [HttpGet("protected-endpoint-security")]
    [Authorize(Roles = "Security")]
    public IActionResult ProtectedEndpointSecurity()
    {
        return Ok("This can only be seem for a Security");
    }

    [HttpGet("protected-endpoint-admin")]
    [Authorize(Roles = "Admin")]
    public IActionResult ProtectedEndpointAdmin()
    {

        return Ok("This can only be seem for an Admin");
    }

    [HttpGet("protected-endpoint-guest")]
    [Authorize(Roles = "Guest")]
    public IActionResult ProtectedEndpointGuest()
    {

        return Ok("This can only be seem for an Guest");
    }

    [HttpGet("protected-endpoint-allroles")]
    [Authorize(Roles = "Admin,Security,Guest")]
    public IActionResult ProtectedEndpointAllRoles()
    {

        return Ok("This endpoint can be seem by every role");
    }

}