using backend_tpgk.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace backend_tpgk.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
public class ProduitController : ControllerBase
{
    private readonly IProduitService _produitService;

    public ProduitController(IProduitService ProduitService)
    {
        _produitService = ProduitService;
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<ProduitDtos>>>> GetAll()
    {
        return Ok(await _produitService.GetAllProduits());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<ProduitDtos>>> GetSingle(Guid id)
    {
        return Ok(await _produitService.GetProduitById(id));
    }

    [Authorize(Roles = "Responsable, Assistant, Admin")]
    [HttpPost]
    public async Task<ActionResult<ServiceResponse<Produit>>> AddProduit([FromForm] ProduitDtos body)
    {
        return Ok(await _produitService.AddProduit(body));
    }

    [Authorize(Roles = "Responsable, Assistant, Admin")]
    [HttpPut("{id}")]
    public async Task<ActionResult<ServiceResponse<Produit>>> UpdateProduit(Guid id, [FromForm] ProduitDtos body)
    {
        return Ok(await _produitService.UpdateProduit(id, body));
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ServiceResponse<Produit>>> DeleteProduit(Guid id){
        return Ok(await _produitService.DeleteProduit(id));
    }
}
