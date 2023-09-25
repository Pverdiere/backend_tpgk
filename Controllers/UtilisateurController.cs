using backend_tpgk.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace backend_tpgk.Controllers;

[ApiController]
[Route("[controller]")]
public class UtilisateurController : ControllerBase
{
    private readonly IUtilisateurService _utilisateurService;

    public UtilisateurController(IUtilisateurService utilisateurService)
    {
        _utilisateurService = utilisateurService;
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<Utilisateur>>>> GetAll()
    {
        return Ok(await _utilisateurService.GetAllUtilisateurs());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<Utilisateur>>> GetSingle(Guid id)
    {
        return Ok(await _utilisateurService.GetUtilisateurById(id));
    }

    [HttpPost]
    public async Task<ActionResult<ServiceResponse<Utilisateur>>> AddUtilisateur([FromBody] Utilisateur body)
    {
        return Ok(await _utilisateurService.AddUtilisateur(body));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ServiceResponse<Utilisateur>>> UpdateUtilisateur(Guid id, [FromBody] UtilisateurDtos body)
    {
        return Ok(await _utilisateurService.UpdateUtilisateur(id, body));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ServiceResponse<Utilisateur>>> DeleteUtilisateur(Guid id){
        return Ok(await _utilisateurService.DeleteUtilisateur(id));
    }
}
