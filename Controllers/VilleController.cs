using backend_tpgk.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace backend_tpgk.Controllers;

[ApiController]
[Route("[controller]")]
public class VilleController : ControllerBase
{
    private readonly IVilleService _villeService;

    public VilleController(IVilleService villeService)
    {
        _villeService = villeService;
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<Ville>>>> GetAll()
    {
        return Ok(await _villeService.GetAllVilles());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<Ville>>> GetSingle(Guid id)
    {
        return Ok(await _villeService.GetVilleById(id));
    }

    [HttpPost]
    public async Task<ActionResult<ServiceResponse<Ville>>> AddVille([FromBody] Ville body)
    {
        return Ok(await _villeService.AddVille(body));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ServiceResponse<Ville>>> UpdateVille(Guid id, [FromBody] VilleDtos body)
    {
        return Ok(await _villeService.UpdateVille(id, body));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ServiceResponse<Ville>>> DeleteVille(Guid id){
        return Ok(await _villeService.DeleteVille(id));
    }
}
