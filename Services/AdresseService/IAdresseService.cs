using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_tpgk.Dtos;

namespace backend_tpgk.Services.AdresseService
{
    public interface IAdresseService
    {
        Task<ServiceResponse<List<Adresse>>> GetAllAdresses();
        Task<ServiceResponse<Adresse>> GetAdresseById(Guid uuid);
        Task<ServiceResponse<Adresse>> AddAdresse(Adresse newAdresse);
        Task<ServiceResponse<Adresse>> DeleteAdresse(Guid uuid);
        Task<ServiceResponse<Adresse>> UpdateAdresse(Guid uuid, AdresseDtos updatedAdresse);
    }
}