using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_tpgk.Services.RoleService
{
    public interface IRoleService
    {
        Task<ServiceResponse<List<Role>>> GetAllRoles();
        Task<ServiceResponse<Role>> GetRoleById(Guid uuid);
        Task<ServiceResponse<Role>> AddRole(Role newRole);
        Task<ServiceResponse<Role>> DeleteRole(Guid UuidDeletedRole);
        Task<ServiceResponse<Role>> UpdateRole(Guid uuid, Role roleUpdated);
    }
}