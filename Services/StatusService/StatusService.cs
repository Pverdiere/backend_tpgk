using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using backend_tpgk.Dtos;

namespace backend_tpgk.Services.StatusService
{
    public class StatusService : IStatusService
    {
        private readonly DataContext _context;

        public StatusService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<Status>> AddStatus(Status newStatus)
        {
            ServiceResponse<Status> serviceResponse = new();
            System.Diagnostics.Debug.WriteLine(newStatus);
            try{
                await _context.Status.AddAsync(newStatus);
                await _context.SaveChangesAsync();
                serviceResponse.Data = newStatus;
            }catch(Exception ex){
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }
            
            return serviceResponse;
        }

        public async Task<ServiceResponse<Status>> DeleteStatus(Guid uuid)
        {
            ServiceResponse<Status> serviceResponse = new();
            Status? dbStatus = await _context.Status.Where(r => r.Uuid == uuid).FirstOrDefaultAsync();
            if(dbStatus is null){
                serviceResponse.Message = "Status not found";
            }else{
                try{
                    _context.Status.Remove(dbStatus);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = dbStatus;
                }catch(Exception ex){
                    serviceResponse.Message = ex.Message;
                    serviceResponse.Success = false;
                }
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Status>>> GetAllStatus()
        {
            ServiceResponse<List<Status>> serviceResponse = new();
            List<Status> dbStatus = await _context.Status.ToListAsync();
            serviceResponse.Data = dbStatus;
            return serviceResponse;
        }

        public async Task<ServiceResponse<Status>> GetStatusById(Guid uuid)
        {
            ServiceResponse<Status> serviceResponse = new();
            Status? dbStatus = await _context.Status.Where(r => r.Uuid == uuid).FirstOrDefaultAsync();
            if(dbStatus is null){
                serviceResponse.Message = "Status not found";
            }else{
                serviceResponse.Data = dbStatus;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<Status>> UpdateStatus(Guid uuid, StatusDtos updatedStatus)
        {
            ServiceResponse<Status> serviceResponse = new();
            Status? dbStatus = await _context.Status.Where(r => r.Uuid == uuid).FirstOrDefaultAsync();
            if(dbStatus is null){
                serviceResponse.Message = "Status not found";
            }else{
                if(updatedStatus.Name is not null) dbStatus.Name = updatedStatus.Name;
                try{
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = dbStatus;
                }catch(Exception ex){
                    serviceResponse.Message = ex.Message;
                    serviceResponse.Success = false;
                }
            }
            return serviceResponse;
        }
    }
}