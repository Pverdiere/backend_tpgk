using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace backend_tpgk.Models
{
    [Index(nameof(Email), IsUnique = true)]
    [Table("Utilisateurs")]
    public class Utilisateur
    {
        [Key]
        [Column("id")]
        public Guid Uuid {get; set;} = Guid.NewGuid();

        [Required]
        [Column("name")]
        public required string Name {get; set;}

        [Required]
        [Column("lastname")]
        public required string Lastname {get; set;}

        [Required]
        [Column("email")]
        public required string Email {get; set;}

        [Required]
        [Column("password")]
        public required string Password {get; set;}

        [Required]
        [Column("birthday")]
        public required DateTime Birthday {get; set;}

        [Required]
        [Column("createdAt")]
        public required DateTime CreatedAt {get; set;}

        [Column("updatedAt")]
        public DateTime? UpdatedAt {get; set;}

        [Required]
        [Column("enable")]
        public required bool Enable {get; set;}

        [Required]
        [Column("roleId")]
        public required Role Role {get; set;}

        [Column("adresseId")]
        public Adresse? Adresse {get; set;}

        public List<Commande>? Commandes {get; set;}

        public List<Avis>? Avis {get; set;}
    }
}