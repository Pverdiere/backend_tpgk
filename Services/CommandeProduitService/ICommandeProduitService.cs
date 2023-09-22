using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_tpgk.Dtos;

namespace backend_tpgk.Services.CommandeProduitService
{
    public interface ICommandeProduitService
    {
        Task<ServiceResponse<List<CommandeProduit>>> GetAllCommandeProduits();
        Task<ServiceResponse<CommandeProduit>> GetCommandeProduitById(Guid uuid);
        Task<ServiceResponse<CommandeProduit>> AddCommandeProduit(CommandeProduit newCommandeProduit);
        Task<ServiceResponse<CommandeProduit>> DeleteCommandeProduit(Guid UuidDeletedCommandeProduit);
        Task<ServiceResponse<CommandeProduit>> UpdateCommandeProduit(Guid uuid, CommandeProduitDtos CommandeProduitUpdated);
    }
}