using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace backend_tpgk.Models
{
    [Index(nameof(Name), IsUnique = true)]
    [Table("rues")]
    public class Rue
    {
        [Key]
        [Column("id")]
        public Guid Uuid {get; set;}

        [Required]
        [Column("name")]
        public required string Name {get; set;}

        public required ICollection<Ville> Villes {get; set;}

        public ICollection<Adresse>? Adresses {get; set;}
    }
}