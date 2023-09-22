using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using backend_tpgk.Dtos;

namespace backend_tpgk.Services.PaysService
{
    public class PaysService : IPaysService
    {
        private readonly DataContext _context;

        public PaysService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<Pays>> AddPays(Pays newPays)
        {
            ServiceResponse<Pays> serviceResponse = new();
            System.Diagnostics.Debug.WriteLine(newPays);
            try{
                await _context.Pays.AddAsync(newPays);
                await _context.SaveChangesAsync();
                serviceResponse.Data = newPays;
            }catch(Exception ex){
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }
            
            return serviceResponse;
        }

        public async Task<ServiceResponse<Pays>> DeletePays(Guid uuid)
        {
            ServiceResponse<Pays> serviceResponse = new();
            Pays? dbPays = await _context.Pays.Where(r => r.Uuid == uuid).FirstOrDefaultAsync();
            if(dbPays is null){
                serviceResponse.Message = "Pays not found";
            }else{
                try{
                    _context.Pays.Remove(dbPays);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = dbPays;
                }catch(Exception ex){
                    serviceResponse.Message = ex.Message;
                    serviceResponse.Success = false;
                }
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Pays>>> GetAllPays()
        {
            ServiceResponse<List<Pays>> serviceResponse = new();
            List<Pays> dbPays = await _context.Pays.ToListAsync();
            serviceResponse.Data = dbPays;
            return serviceResponse;
        }

        public async Task<ServiceResponse<Pays>> GetPaysById(Guid uuid)
        {
            ServiceResponse<Pays> serviceResponse = new();
            Pays? dbPays = await _context.Pays.Where(r => r.Uuid == uuid).FirstOrDefaultAsync();
            if(dbPays is null){
                serviceResponse.Message = "Pays not found";
            }else{
                serviceResponse.Data = dbPays;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<Pays>> UpdatePays(Guid uuid, PaysDtos updatedPays)
        {
            ServiceResponse<Pays> serviceResponse = new();
            Pays? dbPays = await _context.Pays.Where(r => r.Uuid == uuid).FirstOrDefaultAsync();
            if(dbPays is null){
                serviceResponse.Message = "Pays not found";
            }else{
                if(updatedPays.Name is not null) dbPays.Name = updatedPays.Name;
                try{
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = dbPays;
                }catch(Exception ex){
                    serviceResponse.Message = ex.Message;
                    serviceResponse.Success = false;
                }
            }
            return serviceResponse;
        }
    }
}