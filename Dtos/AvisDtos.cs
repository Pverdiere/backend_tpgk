using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace backend_tpgk.Dtos
{
    public class AvisDtos
    {
        public string? Content {get; set;}
        public bool? Validation {get; set;}
        public Utilisateur? Utilisateur {get; set;}
        public Produit? Produit {get; set;}
    }
}