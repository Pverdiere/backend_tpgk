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
                        Promotion = newProduit.Promotion,
                        Hauteur = (float)newProduit.Hauteur!,
                        Largeur = (float)newProduit.Largeur!,
                        Longueur = (float)newProduit.Longueur!,
                        Poids = (float)newProduit.Poids!,
                        Capacite = (int)newProduit.Capacite!,
                        Description = newProduit.Description!,
                        Couleur = newProduit.Couleur!,
                        UrlImg = "",
                        FabricantUuid = (Guid)newProduit.FabricantUuid!,
                        Fabricant = dbFabricant,
                        CreatedAt = DateTime.Now,
                        Enable = true
                    };

                    string[] subs = newProduit.File!.FileName.Split('.');

                    string filePath = $"img/{produit.Uuid}.{subs[^1]}";
                    produit.UrlImg = filePath;
                    FileStream fs = File.Create(filePath);
                    newProduit.File?.CopyTo(fs);
                    fs.Close();
                
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

        public async Task<ServiceResponse<List<ProduitDtos>>> GetAllProduits()
        {
            ServiceResponse<List<ProduitDtos>> serviceResponse = new();
            List<Produit> dbProduit = await _context.Produit.ToListAsync();
            List<ProduitDtos> response = new();

            foreach(Produit produit in dbProduit){
                ProduitDtos produitDtos = new();
                Type typeDtos = produitDtos.GetType();
                PropertyInfo[] propertyInfoDtos = typeDtos.GetProperties();
                Type type = produit.GetType();
                PropertyInfo[] props = type.GetProperties();
                List<string> exception = new()
                {
                    "Uuid",
                    "Fabricant",
                    "Utilisateurs",
                    "CommandeProduit",
                    "CreatedAt"
                };

                foreach(var prop in props){
                    if(prop.GetValue(produit) is not null){
                        if(prop.Name == "UrlImg"){
                            FileStream fs = new(produit.UrlImg, FileMode.Open);
                            byte[] bytes;
                            using MemoryStream memoryStream = new();
                            fs.CopyTo(memoryStream);
                            bytes = memoryStream.ToArray();
                            produitDtos.ImageBase64 = Convert.ToBase64String(bytes);
                            fs.Close();
                        }
                        else{
                            if(!exception.Contains(prop.Name)){
                                var propChange = propertyInfoDtos.Where(r => r.Name == prop.Name).First();
                                propChange.SetValue(produitDtos,prop.GetValue(produit));
                            }
                        }
                    }
                }
                response.Add(produitDtos);
            }
            
            serviceResponse.Data = response;
            return serviceResponse;
        }

        public async Task<ServiceResponse<ProduitDtos>> GetProduitById(Guid uuid)
        {
            ServiceResponse<ProduitDtos> serviceResponse = new();
            Produit? dbProduit = await _context.Produit.Where(r => r.Uuid == uuid).FirstOrDefaultAsync();
            if(dbProduit is null){
                serviceResponse.Message = "Produit not found";
            }else{
                ProduitDtos produitDtos = new();
                Type typeDtos = produitDtos.GetType();
                PropertyInfo[] propertyInfoDtos = typeDtos.GetProperties();
                Type type = dbProduit.GetType();
                PropertyInfo[] props = type.GetProperties();
                List<string> exception = new()
                {
                    "Uuid",
                    "Fabricant",
                    "Utilisateurs",
                    "CommandeProduit",
                    "CreatedAt"
                };

                foreach(var prop in props){
                    if(prop.GetValue(dbProduit) is not null){
                        if(prop.Name == "UrlImg"){
                            FileStream fs = new(dbProduit.UrlImg, FileMode.Open);
                            byte[] bytes;
                            using MemoryStream memoryStream = new();
                            fs.CopyTo(memoryStream);
                            bytes = memoryStream.ToArray();
                            produitDtos.ImageBase64 = Convert.ToBase64String(bytes);
                            fs.Close();
                        }
                        else{
                            if(!exception.Contains(prop.Name)){
                                var propChange = propertyInfoDtos.Where(r => r.Name == prop.Name).First();
                                propChange.SetValue(produitDtos,prop.GetValue(dbProduit));
                            }
                        }
                    }
                }
                serviceResponse.Data = produitDtos;
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
                                fs.Close();
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