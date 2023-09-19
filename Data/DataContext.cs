using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_tpgk.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}