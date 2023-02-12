using Abstractions.Entities;
using Microsoft.EntityFrameworkCore;
using Sql.Seeding;

namespace Sql
{
    public class TaxesDbContext : DbContext
    {
        public TaxesDbContext(DbContextOptions<TaxesDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Municipality> Municipalities { get; set; }
        public virtual DbSet<Taxe> Taxes { get; set; }
        public virtual DbSet<TaxeOrder> TaxeOrders { get; set; }
        public virtual DbSet<TaxeType> TaxeTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
    }
}
