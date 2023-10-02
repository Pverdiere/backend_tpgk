using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_tpgk.Dtos;

namespace backend_tpgk.Services.RueService
{
    public interface IRueService
    {
        Task<ServiceResponse<List<Rue>>> GetAllRues();
        Task<ServiceResponse<Rue>> GetRueById(Guid uuid);
        Task<ServiceResponse<Rue>> AddRue(Rue newRue);
        Task<ServiceResponse<Rue>> DeleteRue(Guid UuidDeletedRue);
        Task<ServiceResponse<Rue>> UpdateRue(Guid uuid, RueDtos roleUpdated);
    }
}