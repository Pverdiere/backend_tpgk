using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace backend_tpgk.Services.RoleService
{
    public class RoleService : IRoleService
    {
        private readonly IActionResultTypeMapper _mapper;
        private readonly DataContext _context;

        public RoleService(IActionResultTypeMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public List<Role> AddRole(HttpContent newRole)
        {
            throw new NotImplementedException();
        }

        public List<Role> DeleteRole(Guid UuidDeletedRole)
        {
            throw new NotImplementedException();
        }

        public List<Role> GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public Role GetRoleById(Guid uuid)
        {
            throw new NotImplementedException();
        }

        public List<Role> UpdateRole(Guid uuid, HttpContent roleUpdated)
        {
            throw new NotImplementedException();
        }
    }
}