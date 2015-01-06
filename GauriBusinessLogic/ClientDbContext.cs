using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GauriBusinessLogic
{
    public class ClientDbContextDb : DbContext
    {        
        public DbSet<Client> Clients { get; set; }
        public DbSet<Costs> Costs { get; set; }
    }
}
