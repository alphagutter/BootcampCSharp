using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Requests.ExtractionModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    /// <summary>
    /// Templates that will show in the Api when the user opens it(for Extractions table)
    /// </summary>
    public class ExtractionController : BaseApiController
    {
        private readonly IExtractionService _service;

        public ExtractionController(IExtractionService service)
        {
            _service = service;
        }

        /// <summary>
        /// Task to create a new Extraction
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateExtractionRequest request)
        {
            //to create our Extraction model, we need to validate all the requirements that we scripted in the CreateExtractionRequest.js
            return Ok(await _service.Add(request));
        }

        /// <summary>
        /// Task for get an Extraction by Id
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var extraction = await _service.GetById(id);
            return Ok(extraction);
        }
    }
}
