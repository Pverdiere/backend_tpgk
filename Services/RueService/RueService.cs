using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using backend_tpgk.Dtos;

namespace backend_tpgk.Services.RueService
{
    public class RueService : IRueService
    {
        private readonly DataContext _context;

        public RueService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<Rue>> AddRue(Rue newRue)
        {
            ServiceResponse<Rue> serviceResponse = new();
            System.Diagnostics.Debug.WriteLine(newRue);
            try{
                await _context.Rue.AddAsync(newRue);
                await _context.SaveChangesAsync();
                serviceResponse.Data = newRue;
            }catch(Exception ex){
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }
            
            return serviceResponse;
        }

        public async Task<ServiceResponse<Rue>> DeleteRue(Guid uuid)
        {
            ServiceResponse<Rue> serviceResponse = new();
            Rue? dbRue = await _context.Rue.Where(r => r.Uuid == uuid).FirstOrDefaultAsync();
            if(dbRue is null){
                serviceResponse.Message = "Rue not found";
            }else{
                try{
                    _context.Rue.Remove(dbRue);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = dbRue;
                }catch(Exception ex){
                    serviceResponse.Message = ex.Message;
                    serviceResponse.Success = false;
                }
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Rue>>> GetAllRues()
        {
            ServiceResponse<List<Rue>> serviceResponse = new();
            List<Rue> dbRue = await _context.Rue.ToListAsync();
            serviceResponse.Data = dbRue;
            return serviceResponse;
        }

        public async Task<ServiceResponse<Rue>> GetRueById(Guid uuid)
        {
            ServiceResponse<Rue> serviceResponse = new();
            Rue? dbRue = await _context.Rue.Where(r => r.Uuid == uuid).FirstOrDefaultAsync();
            if(dbRue is null){
                serviceResponse.Message = "Rue not found";
            }else{
                serviceResponse.Data = dbRue;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<Rue>> UpdateRue(Guid uuid, RueDtos updatedRue)
        {
            ServiceResponse<Rue> serviceResponse = new();
            Rue? dbRue = await _context.Rue.Where(r => r.Uuid == uuid).FirstOrDefaultAsync();
            if(dbRue is null){
                serviceResponse.Message = "Rue not found";
            }else{
                if(updatedRue.Name is not null) dbRue.Name = updatedRue.Name;
                try{
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = dbRue;
                }catch(Exception ex){
                    serviceResponse.Message = ex.Message;
                    serviceResponse.Success = false;
                }
            }
            return serviceResponse;
        }
    }
}