using System.Security.Claims;
using backend_tpgk.Dtos;
using backend_tpgk.Requirement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend_tpgk.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
public class UtilisateurController : ControllerBase
{
    private readonly IUtilisateurService _utilisateurService;

    public UtilisateurController(IUtilisateurService utilisateurService)
    {
        _utilisateurService = utilisateurService;
    }

    [Authorize(Roles = "Responsable, Admin")]
    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<Utilisateur>>>> GetAll()
    {
        return Ok(await _utilisateurService.GetAllUtilisateurs());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<Utilisateur>>> GetSingle(Guid id)
    {
        bool roleIsClient = false;
        string uuid = "";

        foreach(Claim claim in User.Claims){
            if(claim.Type == "Id") uuid = claim.Value;
            if(claim.Type == "Role" && (claim.Value == "Client" || claim.Value == "Modérateur" || claim.Value == "Assistant")) roleIsClient = true;
        }

        if(roleIsClient && uuid != id.ToString()) return new ForbidResult();
        
        return Ok(await _utilisateurService.GetUtilisateurById(id));
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<ActionResult<ServiceResponse<Utilisateur>>> AddUtilisateur([FromBody] Utilisateur body)
    {
        return Ok(await _utilisateurService.AddUtilisateur(body));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ServiceResponse<Utilisateur>>> UpdateUtilisateur(Guid id, [FromBody] UtilisateurDtos body)
    {
        bool roleIsClient = false;
        string uuid = "";

        foreach(Claim claim in User.Claims){
            if(claim.Type == "Id") uuid = claim.Value;
            if(claim.Type == "Role" && (claim.Value == "Client" || claim.Value == "Modérateur" || claim.Value == "Assistant")) roleIsClient = true;
        }

        if(roleIsClient && uuid != id.ToString()) return new ForbidResult();

        return Ok(await _utilisateurService.UpdateUtilisateur(id, body));
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ServiceResponse<Utilisateur>>> DeleteUtilisateur(Guid id){
        bool roleIsClient = false;
        string uuid = "";

        foreach(Claim claim in User.Claims){
            if(claim.Type == "Id") uuid = claim.Value;
            if(claim.Type == "Role" && (claim.Value == "Client" || claim.Value == "Modérateur" || claim.Value == "Assistant")) roleIsClient = true;
        }

        if(roleIsClient && uuid != id.ToString()) return new ForbidResult();

        return Ok(await _utilisateurService.DeleteUtilisateur(id));
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<ActionResult<ServiceResponse<string>>> Login([FromBody] LoginDtos login){
        return Ok(await _utilisateurService.Login(login));
    }
}
