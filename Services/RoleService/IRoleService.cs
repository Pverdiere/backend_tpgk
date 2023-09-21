using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_tpgk.Services.RoleService
{
    public interface IRoleService
    {
        List<Role> GetAllRoles();
        Role GetRoleById(Guid uuid);
        List<Role> AddRole(HttpContent newRole);
        List<Role> DeleteRole(Guid UuidDeletedRole);
        List<Role> UpdateRole(Guid uuid, HttpContent roleUpdated);
    }
}