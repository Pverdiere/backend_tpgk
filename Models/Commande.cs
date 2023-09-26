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
    [Table("commande")]
    public class Commande
    {
        [Key]
        [Column("id")]
        public Guid Uuid {get; set;} = Guid.NewGuid();

        [Required]
        [Column("createdAt")]
        public DateTime CreatedAt {get; set;} = DateTime.Now;

        [Column("updatedAt")]
        public DateTime? UpdatedAt {get; set;}

        [Column("statusId")]
        public Guid StatusUuid {get; set;}
        public Status? Status {get; set;}

        [JsonIgnore]
        public List<Utilisateur>? Utilisateurs {get; set;}

        [JsonIgnore]
        public List<CommandeProduit>? CommandeProduits {get; set;}
    }
}