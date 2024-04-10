using Core.Interfaces.Services;
using Core.Requests.CreditCardModel;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;


/// <summary>
/// Templates that will show in the Api when the user opens it (for Credit Card table)
/// </summary>
public class CreditCardController : BaseApiController
{
    private readonly ICreditCardServices _creditCardService;

    public CreditCardController(ICreditCardServices creditCardService)
    {
        _creditCardService = creditCardService;
    }

    /// <summary>
    /// Task to use all the filters for the table "CreditCards" created
    /// </summary>
    [HttpGet("filtered")]
    public async Task<IActionResult> GetFiltered([FromQuery] FiltersCreditCardModel filter)
    {
        var creditCards = await _creditCardService.GetFiltered(filter);
        return Ok(creditCards);
    }

    /// <summary>
    /// Task to create a new CreditCard
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCreditCardModel request)
    {
        return Ok(await _creditCardService.Add(request));
    }

    /// <summary>
    /// Task to search a CreditCard object for Id
    /// </summary>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var creditCard = await _creditCardService.GetById(id);
        return Ok(creditCard);
    }

    /// <summary>
    /// Task for Update an existing CreditCard
    /// </summary>
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCreditCardModel request)
    {
        return Ok(await _creditCardService.Update(request));
    }

    /// <summary>
    /// Task for delete an existing CreditCard
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        return Ok(await _creditCardService.Delete(id));
    }

    /// <summary>
    /// Task to return all the existing CreditCards
    /// </summary>
    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        var creditCards = await _creditCardService.GetAll();
        return Ok(creditCards);
    }

}
