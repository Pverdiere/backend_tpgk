using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text.Json;
using System.Threading.Tasks;

namespace backend_tpgk.Dtos
{
    public class ProduitDtos
    {
        public string? Code {get; set;}
        public string? Name {get; set;}
        public float? Prix {get; set;}
        public float? Promotion {get; set;}
        public DateTime UpdatedAt {get; set;} = DateTime.Now;
        public bool? Enable {get; set;}
        public float? Hauteur {get; set;}
        public float? Largeur {get; set;}
        public float? Longueur {get; set;}
        public float? Poids {get; set;}
        public int? Capacite {get; set;}
        public string? Description {get; set;}
    }
}