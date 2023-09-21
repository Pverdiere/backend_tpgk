using Microsoft.AspNetCore.Mvc;

namespace backend_tpgk.Controllers;

[ApiController]
[Route("[controller]")]
public class RoleController : ControllerBase
{
    private readonly IRoleService _roleService;

    public RoleController(IRoleService roleService)
    {
        _roleService = roleService;
    }

    [HttpGet]
    public ActionResult<List<Role>> GetAll()
    {
        return Ok(_roleService.GetAllRoles());
    }

    [HttpGet("{id}")]
    public ActionResult<Role> GetSingle(Guid id)
    {
        return Ok(_roleService.GetRoleById(id));
    }

    [HttpPost]
    public ActionResult<List<Role>> AddRole(HttpContent body)
    {
        return Ok(_roleService.AddRole(body));
    }

    [HttpPut("{id}")]
    public ActionResult<Role> UpdateRole(Guid id, HttpContent body)
    {
        return Ok(_roleService.UpdateRole(id, body));
    }

}
