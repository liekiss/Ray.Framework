using Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFRepositories
{
    public class EFDbContext : DbContext
    {
        public EFDbContext()
            : base("DefaultConnection")
        {
            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Students> Students { get; set; }

    }
}
