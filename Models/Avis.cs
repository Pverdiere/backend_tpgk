using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace backend_tpgk.Models
{
    [Table("avis")]
    public class Avis
    {
        [Key]
        [Column("id")]
        public Guid Uuid {get; set;}

        [Required]
        [Column("content")]
        public required string Content {get; set;}

        [Required]
        [Column("createdAt")]
        public required DateTime CreatedAt {get; set;}

        [Column("validation")]
        public bool? Validation {get; set;}

        [Required]
        [Column("utilisateurId")]
        public Guid UtilisateurId {get; set;}
        public required Utilisateur Utilisateur {get; set;}

        [Required]
        [Column("ProduitId")]
        public Guid ProduitId {get; set;}
        public required Produit Produit {get; set;}
    }
}