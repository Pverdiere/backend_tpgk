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

        [Required]
        [Column("complement")]
        public string? Complement {get; set;}

        [ForeignKey("Rue")]
        [Required]
        public Guid RueId {get; set;}
        public required Rue Rue {get; set;}

        [ForeignKey("Ville")]
        [Required]
        public Guid VilleId {get; set;}
        public required Ville Ville {get; set;}

        [ForeignKey("Pays")]
        [Required]
        public Guid PaysId {get; set;}
        public required Pays Pays {get; set;}

        public ICollection<Utilisateur>? Utilisateurs {get; set;}
    }
}