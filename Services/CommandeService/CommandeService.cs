using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using backend_tpgk.Dtos;

namespace backend_tpgk.Services.CommandeService
{
    public class CommandeService : ICommandeService
    {
        private readonly DataContext _context;

        public CommandeService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<Commande>> AddCommande(Commande newCommande)
        {
            ServiceResponse<Commande> serviceResponse = new();
            System.Diagnostics.Debug.WriteLine(newCommande);
            try{
                await _context.Commande.AddAsync(newCommande);
                await _context.SaveChangesAsync();
                serviceResponse.Data = newCommande;
            }catch(Exception ex){
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }
            
            return serviceResponse;
        }

        public async Task<ServiceResponse<Commande>> DeleteCommande(Guid uuid)
        {
            ServiceResponse<Commande> serviceResponse = new();
            Commande? dbCommande = await _context.Commande.Where(r => r.Uuid == uuid).FirstOrDefaultAsync();
            if(dbCommande is null){
                serviceResponse.Message = "Commande not found";
            }else{
                try{
                    _context.Commande.Remove(dbCommande);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = dbCommande;
                }catch(Exception ex){
                    serviceResponse.Message = ex.Message;
                    serviceResponse.Success = false;
                }
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Commande>>> GetAllCommandes()
        {
            ServiceResponse<List<Commande>> serviceResponse = new();
            List<Commande> dbCommande = await _context.Commande.ToListAsync();
            serviceResponse.Data = dbCommande;
            return serviceResponse;
        }

        public async Task<ServiceResponse<Commande>> GetCommandeById(Guid uuid)
        {
            ServiceResponse<Commande> serviceResponse = new();
            Commande? dbCommande = await _context.Commande.Where(r => r.Uuid == uuid).FirstOrDefaultAsync();
            if(dbCommande is null){
                serviceResponse.Message = "Commande not found";
            }else{
                serviceResponse.Data = dbCommande;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<Commande>> UpdateCommande(Guid uuid, CommandeDtos updatedCommande)
        {
            ServiceResponse<Commande> serviceResponse = new();
            Commande? dbCommande = await _context.Commande.Where(r => r.Uuid == uuid).FirstOrDefaultAsync();
            if(dbCommande is null){
                serviceResponse.Message = "Commande not found";
            }else{
                if(updatedCommande.Status is not null) dbCommande.Status = updatedCommande.Status;
                dbCommande.UpdatedAt = updatedCommande.UpdatedAt;

                if(updatedCommande.AddCommandeProduit is not null){
                    if(dbCommande.CommandeProduits is null){
                        dbCommande.CommandeProduits = updatedCommande.AddCommandeProduit;
                    }else{
                        foreach(CommandeProduit element in updatedCommande.AddCommandeProduit){
                            dbCommande.CommandeProduits.Add(element);
                        }
                    }
                }

                if(updatedCommande.RemoveCommandeProduit is not null){
                    if(dbCommande.CommandeProduits is null){
                        serviceResponse.Message = "Le produit que vous essayez de supprimer n'existe pas dans cette commande.";
                    }else{
                        foreach(CommandeProduit element in updatedCommande.RemoveCommandeProduit){
                            int index = dbCommande.CommandeProduits.IndexOf(element);
                            dbCommande.CommandeProduits.RemoveAt(index);
                        }
                    }
                }

                try{
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = dbCommande;
                }catch(Exception ex){
                    serviceResponse.Message = ex.Message;
                    serviceResponse.Success = false;
                }
            }
            return serviceResponse;
        }
    }
}