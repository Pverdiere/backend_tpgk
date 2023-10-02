using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_tpgk.Dtos;

namespace backend_tpgk.Services.FabricantService
{
    public interface IFabricantService
    {
        Task<ServiceResponse<List<Fabricant>>> GetAllFabricants();
        Task<ServiceResponse<Fabricant>> GetFabricantById(Guid uuid);
        Task<ServiceResponse<Fabricant>> AddFabricant(Fabricant newFabricant);
        Task<ServiceResponse<Fabricant>> DeleteFabricant(Guid UuidDeletedFabricant);
        Task<ServiceResponse<Fabricant>> UpdateFabricant(Guid uuid, FabricantDtos updatedFabricant);
    }
}