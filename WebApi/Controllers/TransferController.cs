using Core.Interfaces.Services;
using Core.Requests.TransferModel;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class TransferController : BaseApiController
    {
        private readonly ITransferService _transferService;

        public TransferController(ITransferService transferService)
        {
            _transferService = transferService;
        }


        [HttpPost]
        public async Task<IActionResult> Transfer([FromBody] TransferRequest request)
        {
            return Ok(await _transferService.Transfer(request));
        }
    }
}