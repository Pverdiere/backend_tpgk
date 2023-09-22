using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_tpgk.Dtos;

namespace backend_tpgk.Services.RoleService
{
    public interface IRoleService
    {
        Task<ServiceResponse<List<Role>>> GetAllRoles();
        Task<ServiceResponse<Role>> GetRoleById(Guid uuid);
        Task<ServiceResponse<Role>> AddRole(Role newRole);
        Task<ServiceResponse<Role>> DeleteRole(Guid UuidDeletedRole);
        Task<ServiceResponse<Role>> UpdateRole(Guid uuid, RoleDtos roleUpdated);
    }
}