using Core.Interfaces.Services;
using Core.Requests.ServiceModel;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class ServiceController : BaseApiController
{

    private readonly IServiceService _serviceService;

    public ServiceController(IServiceService serviceService)
    {
        _serviceService = serviceService;
    }

    /// <summary>
    /// Task to create a new Service
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateServiceModel model)
    {
        return Ok(await _serviceService.Add(model));
    }

    /// <summary>
    /// Task to search an Service object by Id
    /// </summary>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var account = await _serviceService.GetById(id);
        return Ok(account);
    }
}
