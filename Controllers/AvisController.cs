using backend_tpgk.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace backend_tpgk.Controllers;

[ApiController]
[Route("[controller]")]
public class AvisController : ControllerBase
{
    private readonly IAvisService _avisService;

    public AvisController(IAvisService AvisService)
    {
        _avisService = AvisService;
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<Avis>>>> GetAll()
    {
        return Ok(await _avisService.GetAllAvis());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<Avis>>> GetSingle(Guid id)
    {
        return Ok(await _avisService.GetAvisById(id));
    }

    [HttpPost]
    public async Task<ActionResult<ServiceResponse<Avis>>> AddAvis([FromBody] Avis body)
    {
        return Ok(await _avisService.AddAvis(body));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ServiceResponse<Avis>>> UpdateAvis(Guid id, [FromBody] AvisDtos body)
    {
        return Ok(await _avisService.UpdateAvis(id, body));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ServiceResponse<Avis>>> DeleteAvis(Guid id){
        return Ok(await _avisService.DeleteAvis(id));
    }
}
