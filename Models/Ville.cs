using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace backend_tpgk.Models
{
    [Table("villes")]
    public class Ville
    {
        [Key]
        [Column("id")]
        public Guid Uuid {get; set;} = Guid.NewGuid();

        [Required]
        [Column("name")]
        public required string Name {get; set;}

        [Required]
        [Column("codePostal")]
        public required string CodePostal {get; set;}

        [Column("paysId")]
        public required Pays Pays {get; set;}

        public required ICollection<Rue> Rues {get; set;}

        public ICollection<Utilisateur>? Utilisateurs {get; set;}
    }
}