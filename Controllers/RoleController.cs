using backend_tpgk.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend_tpgk.Controllers;

[ApiController]
[Authorize(Roles = "Admin")]
[Route("[controller]")]
public class RoleController : ControllerBase
{
    private readonly IRoleService _roleService;

    public RoleController(IRoleService roleService)
    {
        _roleService = roleService;
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<Role>>>> GetAll()
    {
        return Ok(await _roleService.GetAllRoles());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<Role>>> GetSingle(Guid id)
    {
        return Ok(await _roleService.GetRoleById(id));
    }

    [HttpPost]
    public async Task<ActionResult<ServiceResponse<Role>>> AddRole([FromBody] Role body)
    {
        return Ok(await _roleService.AddRole(body));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ServiceResponse<Role>>> UpdateRole(Guid id, [FromBody] RoleDtos body)
    {
        return Ok(await _roleService.UpdateRole(id, body));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ServiceResponse<Role>>> DeleteRole(Guid id){
        return Ok(await _roleService.DeleteRole(id));
    }
}
