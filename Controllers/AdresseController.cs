using backend_tpgk.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace backend_tpgk.Controllers;

[ApiController]
[Route("[controller]")]
public class AdresseController : ControllerBase
{
    private readonly IAdresseService _adresseService;

    public AdresseController(IAdresseService AdresseService)
    {
        _adresseService = AdresseService;
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<Adresse>>>> GetAll()
    {
        return Ok(await _adresseService.GetAllAdresses());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<Adresse>>> GetSingle(Guid id)
    {
        return Ok(await _adresseService.GetAdresseById(id));
    }

    [HttpPost]
    public async Task<ActionResult<ServiceResponse<Adresse>>> AddAdresse([FromBody] Adresse body)
    {
        return Ok(await _adresseService.AddAdresse(body));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ServiceResponse<Adresse>>> UpdateAdresse(Guid id, [FromBody] AdresseDtos body)
    {
        return Ok(await _adresseService.UpdateAdresse(id, body));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ServiceResponse<Adresse>>> DeleteAdresse(Guid id){
        return Ok(await _adresseService.DeleteAdresse(id));
    }
}
