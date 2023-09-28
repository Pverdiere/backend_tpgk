using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_tpgk.Dtos;

namespace backend_tpgk.Services.CommandeService
{
    public interface ICommandeService
    {
        Task<ServiceResponse<List<Commande>>> GetAllCommandes();
        Task<ServiceResponse<Commande>> GetCommandeById(Guid uuid);
        Task<ServiceResponse<Commande>> AddCommande(Commande newCommande);
        Task<ServiceResponse<Commande>> DeleteCommande(Guid UuidDeletedCommande);
        Task<ServiceResponse<Commande>> UpdateCommande(Guid uuid, CommandeDtos CommandeUpdated);
        Task<ServiceResponse<List<Commande>>> GetCommandeByUser(Guid uuidUtilisateur);
    }
}