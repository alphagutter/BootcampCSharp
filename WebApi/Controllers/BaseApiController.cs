using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]

//we add an authorization for the access to the Api functions, can be abled after the token verification

//for now, only people with the 'Admin' role can use the Api functions
//[Authorize(Roles ="Admin")]
public class BaseApiController : ControllerBase
{
}
