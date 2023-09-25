using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using backend_tpgk.Dtos;

namespace backend_tpgk.Services.UtilisateurService
{
    public class UtilisateurService : IUtilisateurService
    {
        private readonly DataContext _context;

        public UtilisateurService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<Utilisateur>> AddUtilisateur(Utilisateur newUtilisateur)
        {
            ServiceResponse<Utilisateur> serviceResponse = new();
            System.Diagnostics.Debug.WriteLine(newUtilisateur);
            try{
                await _context.Utilisateur.AddAsync(newUtilisateur);
                await _context.SaveChangesAsync();
                serviceResponse.Data = newUtilisateur;
            }catch(Exception ex){
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }
            
            return serviceResponse;
        }

        public async Task<ServiceResponse<Utilisateur>> DeleteUtilisateur(Guid uuid)
        {
            ServiceResponse<Utilisateur> serviceResponse = new();
            Utilisateur? dbUtilisateur = await _context.Utilisateur.Where(r => r.Uuid == uuid).FirstOrDefaultAsync();
            if(dbUtilisateur is null){
                serviceResponse.Message = "Utilisateur not found";
            }else{
                try{
                    _context.Utilisateur.Remove(dbUtilisateur);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = dbUtilisateur;
                }catch(Exception ex){
                    serviceResponse.Message = ex.Message;
                    serviceResponse.Success = false;
                }
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Utilisateur>>> GetAllUtilisateurs()
        {
            ServiceResponse<List<Utilisateur>> serviceResponse = new();
            List<Utilisateur> dbUtilisateur = await _context.Utilisateur.ToListAsync();
            serviceResponse.Data = dbUtilisateur;
            return serviceResponse;
        }

        public async Task<ServiceResponse<Utilisateur>> GetUtilisateurById(Guid uuid)
        {
            ServiceResponse<Utilisateur> serviceResponse = new();
            Utilisateur? dbUtilisateur = await _context.Utilisateur.Where(r => r.Uuid == uuid).FirstOrDefaultAsync();
            if(dbUtilisateur is null){
                serviceResponse.Message = "Utilisateur not found";
            }else{
                serviceResponse.Data = dbUtilisateur;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<Utilisateur>> UpdateUtilisateur(Guid uuid, UtilisateurDtos updatedUtilisateur)
        {
            ServiceResponse<Utilisateur> serviceResponse = new();
            Utilisateur? dbUtilisateur = await _context.Utilisateur.Where(r => r.Uuid == uuid).FirstOrDefaultAsync();
            if(dbUtilisateur is null){
                serviceResponse.Message = "Utilisateur not found";
            }else{
                try{
                    Type type = updatedUtilisateur.GetType();
                    PropertyInfo[] props = type.GetProperties();

                    foreach(var prop in props){
                        if(prop.GetValue(updatedUtilisateur) is not null){
                            prop.SetValue(dbUtilisateur,prop.GetValue(updatedUtilisateur));
                        }
                    }

                    await _context.SaveChangesAsync();
                    serviceResponse.Data = dbUtilisateur;
                }catch(Exception ex){
                    serviceResponse.Message = ex.Message;
                    serviceResponse.Success = false;
                }
            }
            return serviceResponse;
        }
    }
}