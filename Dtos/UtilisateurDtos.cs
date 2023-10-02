using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace backend_tpgk.Dtos
{
    public class UtilisateurDtos
    {
        public string? Name {get; set;}
        public string? Lastname {get; set;}
        public string? Email {get; set;}
        public string? Password {get; set;}
        public DateTime? Birthday {get; set;}
        public DateTime UpdatedAt {get; set;} = DateTime.Now;
        public bool? Enabled {get; set;}
        public Guid? RoleUuid {get; set;}
        public Adresse? Adresse {get; set;}
    }
}