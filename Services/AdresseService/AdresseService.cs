using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using backend_tpgk.Dtos;

namespace backend_tpgk.Services.AdresseService
{
    public class AdresseService : IAdresseService
    {
        private readonly DataContext _context;

        public AdresseService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<Adresse>> AddAdresse(Adresse newAdresse)
        {
            ServiceResponse<Adresse> serviceResponse = new();
            System.Diagnostics.Debug.WriteLine(newAdresse);
            try{
                Pays? dbPays = await _context.Pays.Where(r => r.Name == newAdresse.Pays.Name).FirstOrDefaultAsync();

                if(dbPays is null){
                    await _context.Pays.AddAsync(newAdresse.Pays);
                }else{
                    newAdresse.Pays.Uuid = dbPays.Uuid;
                }

                Ville? dbVille = await _context.Ville.Where(r => r.CodePostal == newAdresse.Ville.CodePostal).FirstOrDefaultAsync();

                if(dbVille is null){
                    await _context.Ville.AddAsync(newAdresse.Ville);
                }else{
                    newAdresse.Ville.Uuid = dbVille.Uuid;
                }

                Rue? dbRue = await _context.Rue.Where(r => r.Name == newAdresse.Rue.Name).FirstOrDefaultAsync();

                if(dbRue is null){
                    await _context.Rue.AddAsync(newAdresse.Rue);
                }else{
                    newAdresse.Rue.Uuid = dbRue.Uuid;
                }

                await _context.Adresse.AddAsync(newAdresse);
                await _context.SaveChangesAsync();
                serviceResponse.Data = newAdresse;
            }catch(Exception ex){
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }
            
            return serviceResponse;
        }

        public async Task<ServiceResponse<Adresse>> DeleteAdresse(Guid uuid)
        {
            ServiceResponse<Adresse> serviceResponse = new();
            Adresse? dbAdresse = await _context.Adresse.Where(r => r.Uuid == uuid).FirstOrDefaultAsync();
            if(dbAdresse is null){
                serviceResponse.Message = "Adresse not found";
            }else{
                try{
                    _context.Adresse.Remove(dbAdresse);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = dbAdresse;
                }catch(Exception ex){
                    serviceResponse.Message = ex.Message;
                    serviceResponse.Success = false;
                }
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Adresse>>> GetAllAdresses()
        {
            ServiceResponse<List<Adresse>> serviceResponse = new();
            List<Adresse> dbAdresse = await _context.Adresse.Include(a => a.Ville)
                .Include(a => a.Pays)
                .Include(a => a.Rue)
                .ToListAsync();
            serviceResponse.Data = dbAdresse;
            return serviceResponse;
        }

        public async Task<ServiceResponse<Adresse>> GetAdresseById(Guid uuid)
        {
            ServiceResponse<Adresse> serviceResponse = new();
            Adresse? dbAdresse = await _context.Adresse.Where(r => r.Uuid == uuid)
                .Include(a => a.Ville)
                .Include(a => a.Pays)
                .Include(a => a.Rue)
                .FirstOrDefaultAsync();
            if(dbAdresse is null){
                serviceResponse.Message = "Adresse not found";
            }else{
                serviceResponse.Data = dbAdresse;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<Adresse>> UpdateAdresse(Guid uuid, AdresseDtos updatedAdresse)
        {
            ServiceResponse<Adresse> serviceResponse = new();
            Adresse? dbAdresse = await _context.Adresse.Where(r => r.Uuid == uuid).FirstOrDefaultAsync();
            if(dbAdresse is null){
                serviceResponse.Message = "Adresse not found";
            }else{
                if(updatedAdresse.Number is not null) dbAdresse.Number = updatedAdresse.Number;
                if(updatedAdresse.Complement is not null) dbAdresse.Complement = updatedAdresse.Complement;

                if(updatedAdresse.Pays is not null){
                    Pays? dbPays = await _context.Pays.Where(r => r.Name == updatedAdresse.Pays.Name).FirstOrDefaultAsync();

                    if(dbPays is null){
                        await _context.Pays.AddAsync(updatedAdresse.Pays);
                        dbAdresse.Pays = updatedAdresse.Pays;
                    }else{
                        dbAdresse.Pays.Uuid = dbPays.Uuid;
                    }
                }

                if(updatedAdresse.Ville is not null){
                    Ville? dbVille = await _context.Ville.Where(r => r.CodePostal == updatedAdresse.Ville.CodePostal).FirstOrDefaultAsync();

                    if(dbVille is null){
                        await _context.Ville.AddAsync(updatedAdresse.Ville);
                        dbAdresse.Ville = updatedAdresse.Ville;
                    }else{
                        dbAdresse.Ville.Uuid = dbVille.Uuid;
                    }
                }

                if(updatedAdresse.Rue is not null){
                    Rue? dbRue = await _context.Rue.Where(r => r.Name == updatedAdresse.Rue.Name).FirstOrDefaultAsync();

                    if(dbRue is null){
                        await _context.Rue.AddAsync(updatedAdresse.Rue);
                        dbAdresse.Rue = updatedAdresse.Rue;
                    }else{
                        dbAdresse.Rue.Uuid = dbRue.Uuid;
                    }
                }

                try{
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = dbAdresse;
                }catch(Exception ex){
                    serviceResponse.Message = ex.Message;
                    serviceResponse.Success = false;
                }
            }
            return serviceResponse;
        }
    }
}