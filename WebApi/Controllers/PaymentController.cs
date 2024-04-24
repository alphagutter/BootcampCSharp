using Core.Interfaces.Services;
using Core.Requests.AccountModel;
using Core.Requests.PaymentModel;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class PaymentController : BaseApiController
{

    private readonly IPaymentService _paymentService;

    public PaymentController(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    /// <summary>
    /// Task to create a new Payment
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePaymentRequest request)
    {
        return Ok(await _paymentService.Add(request));
    }

    /// <summary>
    /// Task to search an Payment object by Id
    /// </summary>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var account = await _paymentService.GetById(id);
        return Ok(account);
    }
}
