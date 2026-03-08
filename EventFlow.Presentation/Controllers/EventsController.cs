using EventFlow.Business.Dtos.EventDtos;
using EventFlow.Business.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace EventFlow.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventsController(IEventService _service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var events = await _service.GetAllAsync();
        return Ok(events);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var Event = await _service.GetByIdAsync(id);
        return Ok(Event);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromForm] EventCreateDto dto)
    {
        var result = await _service.CreateAsync(dto);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromForm] EventUpdateDto dto)
    {
        var result = await _service.UpdateAsync(dto);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var result = await _service.DeleteAsync(id);
        return Ok(result);
    }
}
