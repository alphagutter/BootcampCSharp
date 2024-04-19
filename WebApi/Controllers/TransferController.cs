//using Core.Interfaces.Services;
//using Core.Requests.TransferModel;
//using Microsoft.AspNetCore.Mvc;

//namespace WebApi.Controllers
//{
//    public class TransferController : BaseApiController
//    {
//        private readonly ITransferService _transferService;

//        public TransferController(ITransferService transferService)
//        {
//            _transferService = transferService;
//        }

//        [HttpPost]
//        public async Task<IActionResult> Transfer([FromBody] TransferRequest petition)
//        {
//            return Ok(await _transferService.Transfer(petition));
//        }

//        [HttpPost]
//        public async Task<IActionResult> ValidateRequest([FromBody] TransferRequest petition)
//        {
//            return Ok(await _transferService.ValidateRequest(petition));
//        }
        
//        [HttpPost]
//        public async Task<IActionResult> GetDestinationAccount([FromBody] TransferRequest petition)
//        {
//            return Ok(await _transferService.GetDestinationAccount(petition));
//        }


//    }
//}