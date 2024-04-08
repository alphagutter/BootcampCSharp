using Core.Interfaces.Services;
using Core.Requests.CustomerModel;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

/// <summary>
/// Templates that will show in the Api when the user opens it (for Customer table)
/// </summary>
public class CustomerController : BaseApiController
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    /// <summary>
    /// Task to use all the filters for the table "Customers" created
    /// </summary>
    [HttpGet("filtered")]
    public async Task<IActionResult> GetFiltered([FromQuery] FilterCustomersModel filter)
    {
        var customers = await _customerService.GetFiltered(filter);
        return Ok(customers);
    }

    /// <summary>
    /// Task to create a new Customer
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCustomerModel request)
    {
        return Ok(await _customerService.Add(request));




    }

    /// <summary>
    /// Task to search a Customer object for Id
    /// </summary>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var customer = await _customerService.GetById(id);
        return Ok(customer);
    }

    /// <summary>
    /// Task for Update an existing Customer
    /// </summary>
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCustomerModel request)
    {
        return Ok(await _customerService.Update(request));
    }


    /// <summary>
    /// Task for delete and existing Customer
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        return Ok(await _customerService.Delete(id));
    }

    /// <summary>
    /// Task to return all the existing Customers
    /// </summary>
    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        var customers = await _customerService.GetAll();
        return Ok(customers);
    }
}