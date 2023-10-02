using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_tpgk.Dtos;

namespace backend_tpgk.Services.StatusService
{
    public interface IStatusService
    {
        Task<ServiceResponse<List<Status>>> GetAllStatus();
        Task<ServiceResponse<Status>> GetStatusById(Guid uuid);
        Task<ServiceResponse<Status>> AddStatus(Status newStatus);
        Task<ServiceResponse<Status>> DeleteStatus(Guid uuid);
        Task<ServiceResponse<Status>> UpdateStatus(Guid uuid, StatusDtos updatedStatus);
    }
}