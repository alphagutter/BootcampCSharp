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

    public AuthController(IJwtProvider jwtProvider)
    {
        _jwtProvider = jwtProvider;
    }

    [HttpGet("generate-token")]
    //this allows to be available for everyone to create a token(it generates depending on the role it has)
    [AllowAnonymous]
    public IActionResult Generate()
    {
        string token = _jwtProvider.Generate();

        return Ok(token);
    }


    [HttpGet("protected-endpoint-security")]
    [Authorize(Roles = "Security")]
    public IActionResult ProtectedEndpoint()
    {
        return Ok("This can only be seem for a Security");
    }

    [HttpGet("protected-endpoint-admin")]
    [Authorize(Roles = "Admin")]
    public IActionResult ProtectedEndpoint2()
    {

        return Ok("This can only be seem for an Admin");
    }


}