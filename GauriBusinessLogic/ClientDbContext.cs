using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GauriBusinessLogic
{
    public class ClientDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Costs> Costs { get; set; }
    }
}
