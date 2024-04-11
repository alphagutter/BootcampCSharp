using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
//we add an authorization for the access to the Api funcions, can be abled after the token verification
[Authorize]
public class BaseApiController : ControllerBase
{
}
