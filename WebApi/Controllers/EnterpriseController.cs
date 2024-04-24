﻿using Core.Interfaces.Services;
using Core.Requests;
using Core.Requests.EnterpriseModel;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class EnterpriseController : BaseApiController
{
    private readonly IEnterpriseService _service;

    public EnterpriseController(IEnterpriseService service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] int id)
    {
        return Ok(await _service.GetById(id));

    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateEnterpriseModel request)
    {
        return Ok(await _service.Add(request));
    }
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateEnterpriseModel request)
    {
        return Ok(await _service.Update(request));
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        return Ok(await _service.Delete(id));
    }
}