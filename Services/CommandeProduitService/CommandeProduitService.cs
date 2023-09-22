using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using backend_tpgk.Dtos;

namespace backend_tpgk.Services.CommandeProduitService
{
    public class CommandeProduitService : ICommandeProduitService
    {
        private readonly DataContext _context;

        public CommandeProduitService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<CommandeProduit>> AddCommandeProduit(CommandeProduit newCommandeProduit)
        {
            ServiceResponse<CommandeProduit> serviceResponse = new();
            System.Diagnostics.Debug.WriteLine(newCommandeProduit);
            try{
                await _context.CommandeProduit.AddAsync(newCommandeProduit);
                await _context.SaveChangesAsync();
                serviceResponse.Data = newCommandeProduit;
            }catch(Exception ex){
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }
            
            return serviceResponse;
        }

        public async Task<ServiceResponse<CommandeProduit>> DeleteCommandeProduit(Guid uuid)
        {
            ServiceResponse<CommandeProduit> serviceResponse = new();
            CommandeProduit? dbCommandeProduit = await _context.CommandeProduit.Where(r => r.Uuid == uuid).FirstOrDefaultAsync();
            if(dbCommandeProduit is null){
                serviceResponse.Message = "CommandeProduit not found";
            }else{
                try{
                    _context.CommandeProduit.Remove(dbCommandeProduit);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = dbCommandeProduit;
                }catch(Exception ex){
                    serviceResponse.Message = ex.Message;
                    serviceResponse.Success = false;
                }
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<CommandeProduit>>> GetAllCommandeProduits()
        {
            ServiceResponse<List<CommandeProduit>> serviceResponse = new();
            List<CommandeProduit> dbCommandeProduit = await _context.CommandeProduit.ToListAsync();
            serviceResponse.Data = dbCommandeProduit;
            return serviceResponse;
        }

        public async Task<ServiceResponse<CommandeProduit>> GetCommandeProduitById(Guid uuid)
        {
            ServiceResponse<CommandeProduit> serviceResponse = new();
            CommandeProduit? dbCommandeProduit = await _context.CommandeProduit.Where(r => r.Uuid == uuid).FirstOrDefaultAsync();
            if(dbCommandeProduit is null){
                serviceResponse.Message = "CommandeProduit not found";
            }else{
                serviceResponse.Data = dbCommandeProduit;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<CommandeProduit>> UpdateCommandeProduit(Guid uuid, CommandeProduitDtos updatedCommandeProduit)
        {
            ServiceResponse<CommandeProduit> serviceResponse = new();
            CommandeProduit? dbCommandeProduit = await _context.CommandeProduit.Where(r => r.Uuid == uuid).FirstOrDefaultAsync();
            if(dbCommandeProduit is null){
                serviceResponse.Message = "CommandeProduit not found";
            }else{
                if(updatedCommandeProduit.Produit is not null){
                    dbCommandeProduit.Produit = updatedCommandeProduit.Produit;
                }

                if(updatedCommandeProduit.Quantity is not null){
                    dbCommandeProduit.Quantity = (int)updatedCommandeProduit.Quantity;
                }

                if(updatedCommandeProduit.Prix is not null){
                    dbCommandeProduit.Prix = (float)updatedCommandeProduit.Prix;
                }

                if(updatedCommandeProduit.Promotion is not null){
                    dbCommandeProduit.Promotion = updatedCommandeProduit.Promotion;
                }

                try{
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = dbCommandeProduit;
                }catch(Exception ex){
                    serviceResponse.Message = ex.Message;
                    serviceResponse.Success = false;
                }
            }
            return serviceResponse;
        }
    }
}