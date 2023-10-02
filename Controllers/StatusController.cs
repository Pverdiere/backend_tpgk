using backend_tpgk.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend_tpgk.Controllers;

[ApiController]
[Authorize(Roles = "Responsable, Assistant, Admin")]
[Route("[controller]")]
public class StatusController : ControllerBase
{
    private readonly IStatusService _statusService;

    public StatusController(IStatusService StatusService)
    {
        _statusService = StatusService;
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<Status>>>> GetAll()
    {
        return Ok(await _statusService.GetAllStatus());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<Status>>> GetSingle(Guid id)
    {
        return Ok(await _statusService.GetStatusById(id));
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<ActionResult<ServiceResponse<Status>>> AddStatus([FromBody] Status body)
    {
        return Ok(await _statusService.AddStatus(body));
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    public async Task<ActionResult<ServiceResponse<Status>>> UpdateStatus(Guid id, [FromBody] StatusDtos body)
    {
        return Ok(await _statusService.UpdateStatus(id, body));
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ServiceResponse<Status>>> DeleteStatus(Guid id){
        return Ok(await _statusService.DeleteStatus(id));
    }
}
