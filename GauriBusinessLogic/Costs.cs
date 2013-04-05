using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GauriBusinessLogic
{
    class Costs
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public float Amount { get; set; }
        public string Description { get; set; }

        public class CostsDbContext : DbContext
        {
            public DbSet<Costs> Costses { get; set; }
        }
    }
}
