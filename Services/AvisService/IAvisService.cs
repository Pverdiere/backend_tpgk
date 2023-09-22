using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_tpgk.Dtos;

namespace backend_tpgk.Services.AvisService
{
    public interface IAvisService
    {
        Task<ServiceResponse<List<Avis>>> GetAllAvis();
        Task<ServiceResponse<Avis>> GetAvisById(Guid uuid);
        Task<ServiceResponse<Avis>> AddAvis(Avis newAvis);
        Task<ServiceResponse<Avis>> DeleteAvis(Guid uuid);
        Task<ServiceResponse<Avis>> UpdateAvis(Guid uuid, AvisDtos updatedAvis);
    }
}