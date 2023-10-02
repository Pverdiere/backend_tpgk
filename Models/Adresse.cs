using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

namespace backend_tpgk.Models
{
    [Table("adresse")]
    public class Adresse
    {
        [Key]
        [Column("id")]
        public Guid Uuid {get; set;} = Guid.NewGuid();

        [Required]
        [Column("number")]
        public required string Number {get; set;}

        [Column("complement")]
        public string? Complement {get; set;}

        [Column("rueId")]
        public Guid RueUuid {get; set;}
        public required Rue Rue {get; set;}

        [Column("villeId")]
        public Guid VilleUuid {get; set;}
        public required Ville Ville {get; set;}

        [Column("paysId")]
        public Guid PaysId {get; set;}
        public required Pays Pays {get; set;}

        [JsonIgnore]
        public List<Utilisateur>? Utilisateurs {get; set;}
    }
}