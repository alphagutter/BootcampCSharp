using Core.Interfaces.Services;
using Core.Requests.AccountModel;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


namespace WebApi.Controllers;

/// <summary>
/// Templates that will show in the Api when the user opens it (for Account table)
/// </summary>
public class AccountController : BaseApiController
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    /// <summary>
    /// Task to use all the filters for the table "Accounts" created
    /// </summary>
    [HttpGet("filtered")]
    public async Task<IActionResult> GetFiltered([FromQuery] FiltersAccountModel filter)
    {
        var accounts = await _accountService.GetFiltered(filter);
        return Ok(accounts);
    }

    /// <summary>
    /// Task to create a new Account
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAccountRequest request)
    {
        return Ok(await _accountService.Add(request));
    }

    /// <summary>
    /// Task to search an Account object by Id
    /// </summary>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var account = await _accountService.GetById(id);
        return Ok(account);
    }

    /// <summary>
    /// Task to update an existing Account
    /// </summary>
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateAccountModel request)
    {
        return Ok(await _accountService.Update(request));
    }

    /// <summary>
    /// Task to delete an existing Account
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        return Ok(await _accountService.Delete(id));
    }

    /// <summary>
    /// Task to return all the existing Accounts
    /// </summary>
    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        var accounts = await _accountService.GetAll();
        return Ok(accounts);
    }
}
