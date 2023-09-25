using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using backend_tpgk.Dtos;

namespace backend_tpgk.Services.VilleService
{
    public class VilleService : IVilleService
    {
        private readonly DataContext _context;

        public VilleService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<Ville>> AddVille(Ville newVille)
        {
            ServiceResponse<Ville> serviceResponse = new();
            try{
                await _context.Ville.AddAsync(newVille);
                await _context.SaveChangesAsync();
                serviceResponse.Data = newVille;
            }catch(Exception ex){
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }
            
            return serviceResponse;
        }

        public async Task<ServiceResponse<Ville>> DeleteVille(Guid uuid)
        {
            ServiceResponse<Ville> serviceResponse = new();
            Ville? dbVille = await _context.Ville.Where(r => r.Uuid == uuid).FirstOrDefaultAsync();
            if(dbVille is null){
                serviceResponse.Message = "Ville not found";
            }else{
                try{
                    _context.Ville.Remove(dbVille);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = dbVille;
                }catch(Exception ex){
                    serviceResponse.Message = ex.Message;
                    serviceResponse.Success = false;
                }
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Ville>>> GetAllVilles()
        {
            ServiceResponse<List<Ville>> serviceResponse = new();
            List<Ville> dbVille = await _context.Ville.ToListAsync();
            serviceResponse.Data = dbVille;
            return serviceResponse;
        }

        public async Task<ServiceResponse<Ville>> GetVilleById(Guid uuid)
        {
            ServiceResponse<Ville> serviceResponse = new();
            Ville? dbVille = await _context.Ville.Where(r => r.Uuid == uuid).FirstOrDefaultAsync();
            if(dbVille is null){
                serviceResponse.Message = "Ville not found";
            }else{
                serviceResponse.Data = dbVille;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<Ville>> UpdateVille(Guid uuid, VilleDtos updatedVille)
        {
            ServiceResponse<Ville> serviceResponse = new();
            Ville? dbVille = await _context.Ville.Where(r => r.Uuid == uuid).FirstOrDefaultAsync();
            if(dbVille is null){
                serviceResponse.Message = "Ville not found";
            }else{
                if(updatedVille.Name is not null) dbVille.Name = updatedVille.Name;
                if(updatedVille.CodePostal is not null) dbVille.CodePostal = updatedVille.CodePostal;
                try{
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = dbVille;
                }catch(Exception ex){
                    serviceResponse.Message = ex.Message;
                    serviceResponse.Success = false;
                }
            }
            return serviceResponse;
        }
    }
}