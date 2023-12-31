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
        public Guid Uuid {get; set;} = Guid.NewGuid();

        [Required]
        [Column("content")]
        public required string Content {get; set;}

        [Required]
        [Column("createdAt")]
        public DateTime CreatedAt {get; set;} = DateTime.Now;

        [Column("validation")]
        public bool? Validation {get; set;}

        [Column("utilisateurId")]
        public Guid UtilisateurUuid {get; set;}
        public Utilisateur? Utilisateur {get; set;}

        [Column("ProduitId")]
        public Guid ProduitUuid {get; set;}
        public Produit? Produit {get; set;}
    }
}