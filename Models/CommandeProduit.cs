using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace backend_tpgk.Models
{
    [Table("commandeProduit")]
    public class CommandeProduit
    {
        [Key]
        [Column("id")]
        public Guid Uuid {get; set;} = Guid.NewGuid();

        [Column("commandeId")]
        public required Commande Commande {get; set;}

        [Column("produitId")]
        public required Produit Produit {get; set;}

        [Required]
        [Column("prix")]
        public required float Prix {get; set;}

        [Required]
        [Column("quantity")]
        public required int Quantity {get; set;}

        [Column("promotion")]
        public float? Promotion {get; set;}
    }
}