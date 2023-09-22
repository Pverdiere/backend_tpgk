using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace backend_tpgk.Dtos
{
    public class AdresseDtos
    {
        public string? Number {get; set;}
        public string? Complement {get; set;}
        public Rue? Rue {get; set;}
        public Ville? Ville {get; set;}
        public Pays? Pays {get; set;}
    }
}