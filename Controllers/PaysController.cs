using backend_tpgk.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend_tpgk.Controllers;

[ApiController]
[Authorize(Roles = "Admin")]
[Route("[controller]")]
public class PaysController : ControllerBase
{
    private readonly IPaysService _paysService;

    public PaysController(IPaysService PaysService)
    {
        _paysService = PaysService;
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<Pays>>>> GetAll()
    {
        return Ok(await _paysService.GetAllPays());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<Pays>>> GetSingle(Guid id)
    {
        return Ok(await _paysService.GetPaysById(id));
    }

    [HttpPost]
    public async Task<ActionResult<ServiceResponse<Pays>>> AddPays([FromBody] Pays body)
    {
        return Ok(await _paysService.AddPays(body));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ServiceResponse<Pays>>> UpdatePays(Guid id, [FromBody] PaysDtos body)
    {
        return Ok(await _paysService.UpdatePays(id, body));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ServiceResponse<Pays>>> DeletePays(Guid id){
        return Ok(await _paysService.DeletePays(id));
    }
}
