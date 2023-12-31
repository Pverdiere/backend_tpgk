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
    [Index(nameof(Code), IsUnique = true)]
    [Table("produit")]
    public class Produit
    {
        [Key]
        [Column("id")]
        public Guid Uuid {get; set;} = Guid.NewGuid();

        [Required]
        [Column("code")]
        public required string Code {get; set;}

        [Required]
        [Column("name")]
        public required string Name {get; set;}

        [Required]
        [Column("prix")]
        public required float Prix {get; set;}

        [Column("promotion")]
        public float? Promotion {get; set;}

        [Required]
        [Column("createdAt")]
        public DateTime CreatedAt {get; set;} = DateTime.Now;

        [Column("updatedAt")]
        public DateTime? UpdatedAt {get; set;}

        [Required]
        [Column("enable")]
        public required bool Enable {get; set;} = true;

        [Required]
        [Column("hauteur")]
        public required float Hauteur {get; set;}

        [Required]
        [Column("largeur")]
        public required float Largeur {get; set;}

        [Required]
        [Column("longueur")]
        public required float Longueur {get; set;}

        [Required]
        [Column("poids")]
        public required float Poids {get; set;}

        [Required]
        [Column("capacite")]
        public required float Capacite {get; set;}

        [Required]
        [Column("description")]
        public required string Description {get; set;}

        [Required]
        [Column("couleur")]
        public required string Couleur {get; set;}

        [Required]
        [Column("urlImg")]
        public required string UrlImg {get; set;}

        [Required]
        [Column("fabricantId")]
        public Guid FabricantUuid {get; set;}
        public Fabricant? Fabricant {get; set;}

        [JsonIgnore]
        public List<Avis>? Utilisateurs {get; set;}
        [JsonIgnore]
        public List<CommandeProduit>? CommandeProduit {get; set;}
    }
}