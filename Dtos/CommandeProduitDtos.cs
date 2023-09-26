using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace backend_tpgk.Dtos
{
    public class CommandeProduitDtos
    {
        public Guid? CommandeUuid {get; set;}
        public Guid? ProduitUuid {get; set;}
        public float? Prix {get; set;}
        public int? Quantity {get; set;}
        public float? Promotion {get; set;}
    }
}