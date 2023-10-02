using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using backend_tpgk.Dtos;

namespace backend_tpgk.Services.AvisService
{
    public class AvisService : IAvisService
    {
        private readonly DataContext _context;
        private readonly ICommandeService _commandeService;

        public AvisService(DataContext context, ICommandeService commandeService)
        {
            _context = context;
            _commandeService = commandeService;
        }

        public async Task<ServiceResponse<Avis>> AddAvis(Avis newAvis)
        {
            ServiceResponse<Avis> serviceResponse = new();
            ServiceResponse<List<Commande>> serviceResponseCommande = await _commandeService.GetCommandeByUser(newAvis.UtilisateurUuid);
            if(serviceResponseCommande.Data!.Count() > 0 && serviceResponseCommande.Data!.Exists(c => c.CommandeProduits!.Find(cp => cp.ProduitUuid == newAvis.ProduitUuid)?.ProduitUuid == newAvis.ProduitUuid)){
                try{
                    await _context.Avis.AddAsync(newAvis);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = newAvis;
                }catch(Exception ex){
                    serviceResponse.Message = ex.Message;
                    serviceResponse.Success = false;
                }
            }else{
                serviceResponse.Message = "Vous ne pouvez pas donner votre avis sur un produit non commandé.";
                serviceResponse.Success = false;
            }
            
            return serviceResponse;
        }

        public async Task<ServiceResponse<Avis>> DeleteAvis(Guid uuid)
        {
            ServiceResponse<Avis> serviceResponse = new();
            Avis? dbAvis = await _context.Avis.Where(r => r.Uuid == uuid).FirstOrDefaultAsync();
            if(dbAvis is null){
                serviceResponse.Message = "Avis not found";
            }else{
                try{
                    _context.Avis.Remove(dbAvis);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = dbAvis;
                }catch(Exception ex){
                    serviceResponse.Message = ex.Message;
                    serviceResponse.Success = false;
                }
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Avis>>> GetAllAvis()
        {
            ServiceResponse<List<Avis>> serviceResponse = new();
            List<Avis> dbAvis = await _context.Avis.ToListAsync();
            serviceResponse.Data = dbAvis;
            return serviceResponse;
        }

        public async Task<ServiceResponse<Avis>> GetAvisById(Guid uuid)
        {
            ServiceResponse<Avis> serviceResponse = new();
            Avis? dbAvis = await _context.Avis.Where(r => r.Uuid == uuid).FirstOrDefaultAsync();
            if(dbAvis is null){
                serviceResponse.Message = "Avis not found";
            }else{
                serviceResponse.Data = dbAvis;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<Avis>> UpdateAvis(Guid uuid, AvisDtos updatedAvis)
        {
            ServiceResponse<Avis> serviceResponse = new();
            Avis? dbAvis = await _context.Avis.Where(r => r.Uuid == uuid).FirstOrDefaultAsync();
            if(dbAvis is null){
                serviceResponse.Message = "Avis not found";
            }else{
                if(updatedAvis.Content is not null) dbAvis.Content = updatedAvis.Content;
                if(updatedAvis.Validation is not null) dbAvis.Validation = updatedAvis.Validation;
                try{
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = dbAvis;
                }catch(Exception ex){
                    serviceResponse.Message = ex.Message;
                    serviceResponse.Success = false;
                }
            }
            return serviceResponse;
        }
    }
}