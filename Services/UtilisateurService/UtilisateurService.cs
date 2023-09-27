using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using backend_tpgk.Dtos;
using Isopoh.Cryptography.Argon2;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;


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
            newUtilisateur.Password = Argon2.Hash(newUtilisateur.Password);
            Role? dbRole = await _context.Role.Where(r => r.Uuid == newUtilisateur.RoleUuid).FirstOrDefaultAsync();
            if(dbRole is null){
                serviceResponse.Message = "Le role sélectionné n'éxiste pas";
                serviceResponse.Success = false;
            }else{
                try{
                    await _context.Utilisateur.AddAsync(newUtilisateur);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = newUtilisateur;
                }catch(Exception ex){
                    serviceResponse.Message = ex.Message;
                    serviceResponse.Success = false;
                }
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
            List<Utilisateur> dbUtilisateur = await _context.Utilisateur.Include(u => u.Role).ToListAsync();
            serviceResponse.Data = dbUtilisateur;
            return serviceResponse;
        }

        public async Task<ServiceResponse<Utilisateur>> GetUtilisateurById(Guid uuid)
        {
            ServiceResponse<Utilisateur> serviceResponse = new();
            Utilisateur? dbUtilisateur = await _context.Utilisateur.Where(r => r.Uuid == uuid).Include(u => u.Role).FirstOrDefaultAsync();
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

        public async Task<ServiceResponse<string>> Login(LoginDtos login){
            ServiceResponse<string> serviceResponse = new();
            Utilisateur? dbUtilisateur = await _context.Utilisateur.Where(r => r.Email == login.Email).Include(u => u.Role).FirstOrDefaultAsync();
            if(dbUtilisateur is not null && Argon2.Verify(dbUtilisateur.Password, login.Password)){
                Byte[] key = Encoding.ASCII.GetBytes("qsgriopghe56seg4r44qerg46es6rsgrg4g");
                SecurityTokenDescriptor tokenDescriptor = new(){
                    Subject = new ClaimsIdentity(new[]{
                        new Claim("Id", dbUtilisateur.Uuid.ToString()),
                        new Claim("Name", dbUtilisateur.Name),
                        new Claim("Lastname", dbUtilisateur.Lastname),
                        new Claim("Email", dbUtilisateur.Email),
                        new Claim("Role", dbUtilisateur.RoleUuid.ToString()),
                        new Claim("Birtday", dbUtilisateur.Birthday.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddHours(24),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
                };
                JwtSecurityTokenHandler tokenHandler = new();
                var token = tokenHandler.CreateToken(tokenDescriptor);
                string jwtToken = tokenHandler.WriteToken(token);
                serviceResponse.Data = jwtToken;
            }else{
                serviceResponse.Message = "Information de connexion invalide";
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }
    }
}