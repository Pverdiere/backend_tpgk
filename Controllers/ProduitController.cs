using backend_tpgk.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace backend_tpgk.Controllers;

[ApiController]
[Route("[controller]")]
public class ProduitController : ControllerBase
{
    private readonly IProduitService _produitService;

    public ProduitController(IProduitService ProduitService)
    {
        _produitService = ProduitService;
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<Produit>>>> GetAll()
    {
        return Ok(await _produitService.GetAllProduits());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<Produit>>> GetSingle(Guid id)
    {
        return Ok(await _produitService.GetProduitById(id));
    }

    [HttpPost]
    public async Task<ActionResult<ServiceResponse<Produit>>> AddProduit([FromForm] ProduitDtos body)
    {
        return Ok(await _produitService.AddProduit(body));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ServiceResponse<Produit>>> UpdateProduit(Guid id, [FromForm] ProduitDtos body)
    {
        return Ok(await _produitService.UpdateProduit(id, body));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ServiceResponse<Produit>>> DeleteProduit(Guid id){
        return Ok(await _produitService.DeleteProduit(id));
    }
}
