using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_tpgk.Dtos;

namespace backend_tpgk.Services.VilleService
{
    public interface IVilleService
    {
        Task<ServiceResponse<List<Ville>>> GetAllVilles();
        Task<ServiceResponse<Ville>> GetVilleById(Guid uuid);
        Task<ServiceResponse<Ville>> AddVille(Ville newVille);
        Task<ServiceResponse<Ville>> DeleteVille(Guid UuidDeletedVille);
        Task<ServiceResponse<Ville>> UpdateVille(Guid uuid, VilleDtos roleUpdated);
    }
}