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
        public List<AddOrRemove>? AddProduit {get; set;}
        public List<AddOrRemove>? RemoveProduit {get; set;}
    }

    public class AddOrRemove
    {
        public required Guid Uuid {get; set;}
        public required int Quantity {get; set;}
    }
}