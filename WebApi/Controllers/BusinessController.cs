﻿using Core.Interfaces.Services;
using Core.Requests;
using Core.Requests.BusinessModel;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class BusinessController : BaseApiController
{
    private readonly IBusinessService _service;

    public BusinessController(IBusinessService service)
    {
        _service = service;
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
=> Ok(await _service.GetById(id));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateBusinessModel request)
    {
        return Ok(await _service.Add(request));
    }
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateBusinessModel request)
    {
        return Ok(await _service.Update(request));
    }
    [HttpGet("filtered")]
    public async Task<IActionResult> GetFiltered([FromQuery] FiltersBusinessModel filter)
    {
        var account = await _service.GetFiltered(filter);
        return Ok(account);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        return Ok(await _service.Delete(id));
    }
}