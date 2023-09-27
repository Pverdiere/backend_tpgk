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
            Utilisateur? dbUtilisateur = await _context.Utilisateur.Where(u => u.Uuid == newCommande.UtilisateurUuid).FirstOrDefaultAsync();
            if(dbUtilisateur is null){
                serviceResponse.Message = "L'utilisateur n'existe pas";
            }else{
                try{
                    newCommande.Utilisateurs = dbUtilisateur;
                    await _context.Commande.AddAsync(newCommande);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = newCommande;
                }catch(Exception ex){
                    serviceResponse.Message = ex.Message;
                    serviceResponse.Success = false;
                }
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

                if(updatedCommande.AddProduit is not null){
                    dbCommande.CommandeProduits ??= new();
                    foreach(AddOrRemove element in updatedCommande.AddProduit){
                        Produit? dbProduit = await _context.Produit.Where(p => p.Uuid == element.Uuid).FirstOrDefaultAsync();
                        if(dbProduit is not null){
                            CommandeProduit newCommandeProduit = new(){
                                ProduitUuid = dbProduit.Uuid,
                                Produit = dbProduit,
                                CommandeUuid = dbCommande.Uuid,
                                Commande = dbCommande,
                                Quantity = element.Quantity,
                                Prix = dbProduit.Prix,
                                Promotion = dbProduit.Promotion
                            };
                            dbCommande.CommandeProduits.Add(newCommandeProduit);
                        } 
                    }
                }

                if(updatedCommande.RemoveProduit is not null){
                    if(dbCommande.CommandeProduits is null){
                        serviceResponse.Message = "Le produit que vous essayez de supprimer n'existe pas dans cette commande.";
                    }else{
                        foreach(AddOrRemove element in updatedCommande.RemoveProduit){
                            Produit? dbProduit = await _context.Produit.Where(p => p.Uuid == element.Uuid).FirstOrDefaultAsync();
                            if(dbProduit is not null){
                                CommandeProduit? dbCommandeProduit = await _context.CommandeProduit.Where(cp => cp.CommandeUuid == dbCommande.Uuid && cp.ProduitUuid == dbProduit.Uuid).FirstOrDefaultAsync();
                                if(dbCommandeProduit is not null){
                                    int index = dbCommande.CommandeProduits.IndexOf(dbCommandeProduit);
                                    dbCommande.CommandeProduits.RemoveAt(index);
                                }
                            }
                            
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