using Core.Interfaces.Services;
using Core.Requests.DepositModel;

using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class DepositController : BaseApiController
    {
        private readonly IDepositService _depositService;

        public DepositController(IDepositService depositService)
        {
            _depositService = depositService;
        }

        /// <summary>
        /// Task to create a new Deposit
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDepositModel request)
        {
            return Ok(await _depositService.Add(request));
        }

        /// <summary>
        /// Task to search a Deposit object by Id
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var deposit = await _depositService.GetById(id);
            return Ok(deposit);
        }
    }
}
