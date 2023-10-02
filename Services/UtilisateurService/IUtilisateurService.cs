using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_tpgk.Dtos;

namespace backend_tpgk.Services.UtilisateurService
{
    public interface IUtilisateurService
    {
        Task<ServiceResponse<List<Utilisateur>>> GetAllUtilisateurs();
        Task<ServiceResponse<Utilisateur>> GetUtilisateurById(Guid uuid);
        Task<ServiceResponse<Utilisateur>> AddUtilisateur(Utilisateur newUtilisateur);
        Task<ServiceResponse<Utilisateur>> DeleteUtilisateur(Guid UuidDeletedUtilisateur);
        Task<ServiceResponse<Utilisateur>> UpdateUtilisateur(Guid uuid, UtilisateurDtos updatedUtilisateur);
        Task<ServiceResponse<string>> Login(LoginDtos login);
    }
}