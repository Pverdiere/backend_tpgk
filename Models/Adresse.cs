using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace backend_tpgk.Models
{
    [Table("adresse")]
    public class Adresse
    {
        [Key]
        [Column("id")]
        public Guid Uuid {get; set;}

        [Required]
        [Column("number")]
        public required string Number {get; set;}

        [Column("complement")]
        public string? Complement {get; set;}

        [Column("rueId")]
        public required Rue Rue {get; set;}

        [Column("villeId")]
        public required Ville Ville {get; set;}

        [Column("paysId")]
        public required Pays Pays {get; set;}

        public ICollection<Utilisateur>? Utilisateurs {get; set;}
    }
}