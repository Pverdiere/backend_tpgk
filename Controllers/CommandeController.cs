using backend_tpgk.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace backend_tpgk.Controllers;

[ApiController]
[Route("[controller]")]
public class CommandeController : ControllerBase
{
    private readonly ICommandeService _commandeService;

    public CommandeController(ICommandeService CommandeService)
    {
        _commandeService = CommandeService;
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<Commande>>>> GetAll()
    {
        return Ok(await _commandeService.GetAllCommandes());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<Commande>>> GetSingle(Guid id)
    {
        return Ok(await _commandeService.GetCommandeById(id));
    }

    [HttpPost]
    public async Task<ActionResult<ServiceResponse<Commande>>> AddCommande([FromBody] Commande body)
    {
        return Ok(await _commandeService.AddCommande(body));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ServiceResponse<Commande>>> UpdateCommande(Guid id, [FromBody] CommandeDtos body)
    {
        return Ok(await _commandeService.UpdateCommande(id, body));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ServiceResponse<Commande>>> DeleteCommande(Guid id){
        return Ok(await _commandeService.DeleteCommande(id));
    }
}
