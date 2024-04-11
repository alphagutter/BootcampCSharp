using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Requests.BankModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
/// <summary>
/// Templates that will show in the Api when the user opens it(for Banks table)
/// </summary>
public class BankController : BaseApiController
{
    private readonly IBankService _service;

    public BankController(IBankService service)
    {
        _service = service;
    }

    /// <summary>
    /// Task to create a new Bank
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateBankModel request)
    {
        //to create our Bank model, we need to validate all the requirements that we scripted in the CreateBankModel.js


        return Ok(await _service.Add(request));
    }


    /// <summary>
    /// Task for get a Bank from Id
    /// </summary>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var bank = await _service.GetById(id);
        return Ok(bank);
    }


    /// <summary>
    /// Task to update an existing Bank
    /// </summary>
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateBankModel request)
    {
        return Ok(await _service.Update(request));
    }




    /// <summary>
    /// Task to delete a Bank
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        return Ok(await _service.Delete(id));
    }



    /// <summary>
    /// Task to return all the existing Banks
    /// </summary>
    [HttpGet("all")]
    [Authorize (Roles ="Security")]
    public async Task<IActionResult> GetAll()
    {
        var banks = await _service.GetAll();
        return Ok(banks);
    }
}
