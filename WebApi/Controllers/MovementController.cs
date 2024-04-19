using Core.Interfaces.Services;
using Core.Requests.MovementModel;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class MovementController : BaseApiController
    {
        private readonly IMovementService _movementService;

        public MovementController(IMovementService movementService)
        {
            _movementService = movementService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMovementRequest petition)
        {
            return Ok(await _movementService.Add(petition));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var petition = await _movementService.GetById(id);
            return Ok(petition);
        }
    }
}