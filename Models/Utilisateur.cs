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
        public Guid Uuid {get; set;}

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
        public required DateOnly Birthday {get; set;}

        [Required]
        [Column("createdAt")]
        public required DateTime CreatedAt {get; set;}

        [Column("updatedAt")]
        public DateTime? UpdatedAt {get; set;}

        [Required]
        [Column("enable")]
        public required bool Enable {get; set;}

        [ForeignKey("Role")]
        [Required]
        [Column("roleId")]
        public required Guid RoleId {get; set;}
        public required Role Role {get; set;}

        [ForeignKey("Adresse")]
        [Required]
        [Column("roleId")]
        public required Guid AdresseId {get; set;}
        public required Adresse Adresse {get; set;}

        public ICollection<Commande>? Commandes {get; set;}

        public ICollection<Avis>? Avis {get; set;}
    }
}