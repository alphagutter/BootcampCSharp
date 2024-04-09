using Core.Interfaces.Services;
using Core.Requests.CurrencyModel;
using Core.Requests.CustomerModel;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class CurrencyController : BaseApiController
{
    private readonly ICurrencyService _currencyService;

   public CurrencyController(ICurrencyService currencyService)
    {
        _currencyService = currencyService;
    }

    /// <summary>
    /// Task to use all the filters for the table "Currencies" created
    /// </summary>
    [HttpGet("filtered")]
    public async Task<IActionResult> GetFiltered([FromQuery] FiltersCurrencyModel filter)
    {
        var currencies = await _currencyService.GetFiltered(filter);
        return Ok(currencies);
    }

    /// <summary>
    /// Task to create a new Currency
    /// </summary>
    [HttpPost("Add")]
    public async Task<IActionResult> Create([FromBody] CreateCurrencyModel request)
    {
        return Ok(await _currencyService.Add(request));

    }

    /// <summary>
    /// Task to search a Currency object for Id
    /// </summary>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var currency = await _currencyService.GetById(id);
        return Ok(currency);
    }

    /// <summary>
    /// Task for Update an existing Currency
    /// </summary>
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCurrencyModel request)
    {
        return Ok(await _currencyService.Update(request));
    }


    /// <summary>
    /// Task for delete and existing Currency
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        return Ok(await _currencyService.Delete(id));
    }

    /// <summary>
    /// Task to return all the existing Currency
    /// </summary>
    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        var currencys = await _currencyService.GetAll();
        return Ok(currencys);
    }
}
