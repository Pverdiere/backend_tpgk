using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace backend_tpgk.Models
{
    [Table("commande")]
    public class Commande
    {
        [Key]
        [Column("id")]
        public Guid Uuid {get; set;} = Guid.NewGuid();

        [Required]
        [Column("createdAt")]
        public required DateTime CreatedAt {get; set;}

        [Column("updatedAt")]
        public DateTime? UpdatedAt {get; set;}

        [Column("statusId")]
        public required Status Status {get; set;}

        public ICollection<Utilisateur>? Utilisateurs {get; set;}

        public ICollection<CommandeProduit>? CommandeProduits {get; set;}
    }
}