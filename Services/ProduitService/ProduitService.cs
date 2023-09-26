using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using backend_tpgk.Dtos;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace backend_tpgk.Services.ProduitService
{
    public class ProduitService : IProduitService
    {
        private readonly DataContext _context;

        public ProduitService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<Produit>> AddProduit(ProduitDtos newProduit)
        {
            ServiceResponse<Produit> serviceResponse = new();
            try{
                Fabricant? dbFabricant = await _context.Fabricant.Where(f => f.Uuid == newProduit.FabricantUuid).FirstOrDefaultAsync();
                if(dbFabricant is null){
                    serviceResponse.Message = "Le fabricant sélectionné n'existe pas";
                    serviceResponse.Success = false;
                }else{
                    Produit produit = new(){
                        Code = newProduit.Code!,
                        Name = newProduit.Name!,
                        Prix = (float)newProduit.Prix!,
                        Promotion = (float)newProduit.Promotion!,
                        Hauteur = (float)newProduit.Hauteur!,
                        Largeur = (float)newProduit.Largeur!,
                        Longueur = (float)newProduit.Longueur!,
                        Poids = (float)newProduit.Poids!,
                        Capacite = (int)newProduit.Capacite!,
                        Description = newProduit.Description!,
                        Couleur = newProduit.Couleur!,
                        UrlImg = "",
                        FabricantUuid = (Guid)newProduit.FabricantUuid!,
                        CreatedAt = DateTime.Now,
                        Enable = true
                    };

                    string filePath = $"../../img/{produit.Uuid}";
                    produit.UrlImg = filePath;
                    FileStream fs = File.Create(filePath);
                    newProduit.File?.CopyTo(fs);
                
                    await _context.Produit.AddAsync(produit);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = produit;
                }
                
            }catch(Exception ex){
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }
            
            return serviceResponse;
        }

        public async Task<ServiceResponse<Produit>> DeleteProduit(Guid uuid)
        {
            ServiceResponse<Produit> serviceResponse = new();
            Produit? dbProduit = await _context.Produit.Where(r => r.Uuid == uuid).FirstOrDefaultAsync();
            if(dbProduit is null){
                serviceResponse.Message = "Produit not found";
            }else{
                try{
                    File.Delete(dbProduit.UrlImg);
                    _context.Produit.Remove(dbProduit);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = dbProduit;
                }catch(Exception ex){
                    serviceResponse.Message = ex.Message;
                    serviceResponse.Success = false;
                }
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Produit>>> GetAllProduits()
        {
            ServiceResponse<List<Produit>> serviceResponse = new();
            List<Produit> dbProduit = await _context.Produit.ToListAsync();
            serviceResponse.Data = dbProduit;
            return serviceResponse;
        }

        public async Task<ServiceResponse<Produit>> GetProduitById(Guid uuid)
        {
            ServiceResponse<Produit> serviceResponse = new();
            Produit? dbProduit = await _context.Produit.Where(r => r.Uuid == uuid).FirstOrDefaultAsync();
            if(dbProduit is null){
                serviceResponse.Message = "Produit not found";
            }else{
                serviceResponse.Data = dbProduit;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<Produit>> UpdateProduit(Guid uuid, ProduitDtos updatedProduit)
        {
            ServiceResponse<Produit> serviceResponse = new();
            Produit? dbProduit = await _context.Produit.Where(r => r.Uuid == uuid).FirstOrDefaultAsync();
            if(dbProduit is null){
                serviceResponse.Message = "Produit not found";
            }else{
                try{
                    Type type = updatedProduit.GetType();
                    PropertyInfo[] props = type.GetProperties();

                    foreach(var prop in props){
                        if(prop.GetValue(updatedProduit) is not null){
                            if(prop.Name == "File"){
                                string filePath = $"../../img/{dbProduit.Uuid}";
                                dbProduit.UrlImg = filePath;
                                FileStream fs = File.Create(filePath);
                                updatedProduit.File?.CopyTo(fs);
                            }else{
                                prop.SetValue(dbProduit,prop.GetValue(updatedProduit));
                            }
                        }
                    }

                    await _context.SaveChangesAsync();
                    serviceResponse.Data = dbProduit;
                }catch(Exception ex){
                    serviceResponse.Message = ex.Message;
                    serviceResponse.Success = false;
                }
            }
            return serviceResponse;
        }
    }
}