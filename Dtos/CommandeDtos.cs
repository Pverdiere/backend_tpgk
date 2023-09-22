using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace backend_tpgk.Dtos
{
    public class CommandeDtos
    {
        public DateTime UpdatedAt {get; set;} = DateTime.Now;
        public Status? Status {get; set;}
        public List<CommandeProduit>? AddCommandeProduit {get; set;}
        public List<CommandeProduit>? RemoveCommandeProduit {get; set;}
    }
}