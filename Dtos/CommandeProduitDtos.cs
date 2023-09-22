using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace backend_tpgk.Dtos
{
    public class CommandeProduitDtos
    {
        public Commande? Commande {get; set;}
        public Produit? Produit {get; set;}
        public float? Prix {get; set;}
        public int? Quantity {get; set;}
        public float? Promotion {get; set;}
    }
}