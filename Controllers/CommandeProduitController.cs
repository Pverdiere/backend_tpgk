using backend_tpgk.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace backend_tpgk.Controllers;

[ApiController]
[Route("[controller]")]
public class CommandeProduitController : ControllerBase
{
    private readonly ICommandeProduitService _commandeProduitService;

    public CommandeProduitController(ICommandeProduitService CommandeProduitService)
    {
        _commandeProduitService = CommandeProduitService;
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<CommandeProduit>>>> GetAll()
    {
        return Ok(await _commandeProduitService.GetAllCommandeProduits());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<CommandeProduit>>> GetSingle(Guid id)
    {
        return Ok(await _commandeProduitService.GetCommandeProduitById(id));
    }

    [HttpPost]
    public async Task<ActionResult<ServiceResponse<CommandeProduit>>> AddCommandeProduit([FromBody] CommandeProduit body)
    {
        return Ok(await _commandeProduitService.AddCommandeProduit(body));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ServiceResponse<CommandeProduit>>> UpdateCommandeProduit(Guid id, [FromBody] CommandeProduitDtos body)
    {
        return Ok(await _commandeProduitService.UpdateCommandeProduit(id, body));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ServiceResponse<CommandeProduit>>> DeleteCommandeProduit(Guid id){
        return Ok(await _commandeProduitService.DeleteCommandeProduit(id));
    }
}
