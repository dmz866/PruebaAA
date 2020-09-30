
using Microsoft.EntityFrameworkCore;
using PruebaAA.Core.Entities;

namespace PruebaAA.Infrastructure.Data
{
    public class PruebaAAContext: DbContext
    {
        public PruebaAAContext()
        {
        }
        public PruebaAAContext(DbContextOptions<PruebaAAContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DAVID-MURILLO\SQLEXPRESS;Database=PruebaAA;Trusted_Connection=True;");
        }

        public virtual DbSet<StockEntity> Stocks { get; set; }
    }
}
