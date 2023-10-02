using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using backend_tpgk.Dtos;

namespace backend_tpgk.Services.RoleService
{
    public class RoleService : IRoleService
    {
        private readonly DataContext _context;

        public RoleService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<Role>> AddRole(Role newRole)
        {
            ServiceResponse<Role> serviceResponse = new();
            System.Diagnostics.Debug.WriteLine(newRole);
            try{
                await _context.Role.AddAsync(newRole);
                await _context.SaveChangesAsync();
                serviceResponse.Data = newRole;
            }catch(Exception ex){
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }
            
            return serviceResponse;
        }

        public async Task<ServiceResponse<Role>> DeleteRole(Guid uuid)
        {
            ServiceResponse<Role> serviceResponse = new();
            Role? dbRole = await _context.Role.Where(r => r.Uuid == uuid).FirstOrDefaultAsync();
            if(dbRole is null){
                serviceResponse.Message = "Role not found";
            }else{
                try{
                    _context.Role.Remove(dbRole);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = dbRole;
                }catch(Exception ex){
                    serviceResponse.Message = ex.Message;
                    serviceResponse.Success = false;
                }
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Role>>> GetAllRoles()
        {
            ServiceResponse<List<Role>> serviceResponse = new();
            List<Role> dbRole = await _context.Role.ToListAsync();
            serviceResponse.Data = dbRole;
            return serviceResponse;
        }

        public async Task<ServiceResponse<Role>> GetRoleById(Guid uuid)
        {
            ServiceResponse<Role> serviceResponse = new();
            Role? dbRole = await _context.Role.Where(r => r.Uuid == uuid).FirstOrDefaultAsync();
            if(dbRole is null){
                serviceResponse.Message = "Role not found";
            }else{
                serviceResponse.Data = dbRole;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<Role>> UpdateRole(Guid uuid, RoleDtos updatedRole)
        {
            ServiceResponse<Role> serviceResponse = new();
            Role? dbRole = await _context.Role.Where(r => r.Uuid == uuid).FirstOrDefaultAsync();
            if(dbRole is null){
                serviceResponse.Message = "Role not found";
            }else{
                if(updatedRole.Name is not null) dbRole.Name = updatedRole.Name;
                try{
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = dbRole;
                }catch(Exception ex){
                    serviceResponse.Message = ex.Message;
                    serviceResponse.Success = false;
                }
            }
            return serviceResponse;
        }
    }
}