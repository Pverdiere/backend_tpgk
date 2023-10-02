using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using backend_tpgk.Dtos;

namespace backend_tpgk.Services.FabricantService
{
    public class FabricantService : IFabricantService
    {
        private readonly DataContext _context;

        public FabricantService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<Fabricant>> AddFabricant(Fabricant newFabricant)
        {
            ServiceResponse<Fabricant> serviceResponse = new();
            System.Diagnostics.Debug.WriteLine(newFabricant);
            try{
                await _context.Fabricant.AddAsync(newFabricant);
                await _context.SaveChangesAsync();
                serviceResponse.Data = newFabricant;
            }catch(Exception ex){
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }
            
            return serviceResponse;
        }

        public async Task<ServiceResponse<Fabricant>> DeleteFabricant(Guid uuid)
        {
            ServiceResponse<Fabricant> serviceResponse = new();
            Fabricant? dbFabricant = await _context.Fabricant.Where(r => r.Uuid == uuid).FirstOrDefaultAsync();
            if(dbFabricant is null){
                serviceResponse.Message = "Fabricant not found";
            }else{
                try{
                    _context.Fabricant.Remove(dbFabricant);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = dbFabricant;
                }catch(Exception ex){
                    serviceResponse.Message = ex.Message;
                    serviceResponse.Success = false;
                }
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Fabricant>>> GetAllFabricants()
        {
            ServiceResponse<List<Fabricant>> serviceResponse = new();
            List<Fabricant> dbFabricant = await _context.Fabricant.ToListAsync();
            serviceResponse.Data = dbFabricant;
            return serviceResponse;
        }

        public async Task<ServiceResponse<Fabricant>> GetFabricantById(Guid uuid)
        {
            ServiceResponse<Fabricant> serviceResponse = new();
            Fabricant? dbFabricant = await _context.Fabricant.Where(r => r.Uuid == uuid).FirstOrDefaultAsync();
            if(dbFabricant is null){
                serviceResponse.Message = "Fabricant not found";
            }else{
                serviceResponse.Data = dbFabricant;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<Fabricant>> UpdateFabricant(Guid uuid, FabricantDtos updatedFabricant)
        {
            ServiceResponse<Fabricant> serviceResponse = new();
            Fabricant? dbFabricant = await _context.Fabricant.Where(r => r.Uuid == uuid).FirstOrDefaultAsync();
            if(dbFabricant is null){
                serviceResponse.Message = "Fabricant not found";
            }else{
                if(updatedFabricant.Name is not null) dbFabricant.Name = updatedFabricant.Name;
                try{
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = dbFabricant;
                }catch(Exception ex){
                    serviceResponse.Message = ex.Message;
                    serviceResponse.Success = false;
                }
            }
            return serviceResponse;
        }
    }
}