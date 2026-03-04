using EventFlow.Business.Dtos.EventDtos;
using EventFlow.Business.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventFlow.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventController(IEventService _service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var events = await _service.GetAllAsync();
        return Ok(events);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] EventCreateDto dto)
    {
        await _service.CreateAsync(dto);
        return Ok("Created");
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] EventUpdateDto dto)
    {
        await _service.UpdateAsync(dto);
        return Ok("Updated");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        await _service.DeleteAsync(id);
        return Ok("Deleted");
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var Event = await _service.GetAsync(id);
        return Ok(Event);
    }
}
