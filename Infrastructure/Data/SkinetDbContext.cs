using Core.DomainModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class SkinetDbContext : DbContext
    {
        public SkinetDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
    }
}
