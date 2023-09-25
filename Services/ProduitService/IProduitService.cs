using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_tpgk.Dtos;

namespace backend_tpgk.Services.ProduitService
{
    public interface IProduitService
    {
        Task<ServiceResponse<List<Produit>>> GetAllProduits();
        Task<ServiceResponse<Produit>> GetProduitById(Guid uuid);
        Task<ServiceResponse<Produit>> AddProduit(ProduitDtos newProduit);
        Task<ServiceResponse<Produit>> DeleteProduit(Guid UuidDeletedProduit);
        Task<ServiceResponse<Produit>> UpdateProduit(Guid uuid, ProduitDtos ProduitUpdated);
    }
}