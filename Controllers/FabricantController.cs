using backend_tpgk.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend_tpgk.Controllers;

[ApiController]
[Authorize(Roles = "Responsable, Assistant, Admin")]
[Route("[controller]")]
public class FabricantController : ControllerBase
{
    private readonly IFabricantService _fabricantService;

    public FabricantController(IFabricantService roleService)
    {
        _fabricantService = roleService;
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<Fabricant>>>> GetAll()
    {
        return Ok(await _fabricantService.GetAllFabricants());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<Fabricant>>> GetSingle(Guid id)
    {
        return Ok(await _fabricantService.GetFabricantById(id));
    }

    [HttpPost]
    public async Task<ActionResult<ServiceResponse<Fabricant>>> AddFabricant([FromBody] Fabricant body)
    {
        return Ok(await _fabricantService.AddFabricant(body));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ServiceResponse<Fabricant>>> UpdateFabricant(Guid id, [FromBody] FabricantDtos body)
    {
        return Ok(await _fabricantService.UpdateFabricant(id, body));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ServiceResponse<Fabricant>>> DeleteFabricant(Guid id){
        return Ok(await _fabricantService.DeleteFabricant(id));
    }
}
