using backend_tpgk.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace backend_tpgk.Controllers;

[ApiController]
[Route("[controller]")]
public class RueController : ControllerBase
{
    private readonly IRueService _rueService;

    public RueController(IRueService rueService)
    {
        _rueService = rueService;
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<Rue>>>> GetAll()
    {
        return Ok(await _rueService.GetAllRues());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<Rue>>> GetSingle(Guid id)
    {
        return Ok(await _rueService.GetRueById(id));
    }

    [HttpPost]
    public async Task<ActionResult<ServiceResponse<Rue>>> AddRue([FromBody] Rue body)
    {
        return Ok(await _rueService.AddRue(body));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ServiceResponse<Rue>>> UpdateRue(Guid id, [FromBody] RueDtos body)
    {
        return Ok(await _rueService.UpdateRue(id, body));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ServiceResponse<Rue>>> DeleteRue(Guid id){
        return Ok(await _rueService.DeleteRue(id));
    }
}
