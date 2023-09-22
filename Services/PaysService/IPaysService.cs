using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_tpgk.Dtos;

namespace backend_tpgk.Services.PaysService
{
    public interface IPaysService
    {
        Task<ServiceResponse<List<Pays>>> GetAllPays();
        Task<ServiceResponse<Pays>> GetPaysById(Guid uuid);
        Task<ServiceResponse<Pays>> AddPays(Pays newPays);
        Task<ServiceResponse<Pays>> DeletePays(Guid uuid);
        Task<ServiceResponse<Pays>> UpdatePays(Guid uuid, PaysDtos updatedPays);
    }
}