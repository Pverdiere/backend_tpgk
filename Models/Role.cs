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
    [Index(nameof(Name), IsUnique = true)]
    [Table("roles")]
    public class Role
    {
        [Key]
        [Column("id")]
        public Guid Uuid {get; set;} = Guid.NewGuid();

        [Required]
        [Column("name")]
        public required string Name {get; set;}

        [JsonIgnore]
        public List<Utilisateur>? Utilisateurs {get; set;}
    }
}