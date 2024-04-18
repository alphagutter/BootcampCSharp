using Core.Interfaces.Services;
using Core.Requests.PetitionModel;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class PetitionController : BaseApiController
    {
        private readonly IPetitionService _petitionService;

        public PetitionController(IPetitionService petitionService)
        {
            _petitionService = petitionService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePetitionRequest petition)
        {
            return Ok(await _petitionService.Add(petition));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var petition = await _petitionService.GetById(id);
            return Ok(petition);
        }
    }
}
