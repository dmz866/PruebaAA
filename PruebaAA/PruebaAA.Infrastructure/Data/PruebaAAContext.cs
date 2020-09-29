
using Microsoft.EntityFrameworkCore;
using PruebaAA.Core.Entities;

namespace PruebaAA.Infrastructure.Data
{
    public class PruebaAAContext: DbContext
    {
        public PruebaAAContext()
        {
        }

        public virtual DbSet<StockEntity> Stocks { get; set; }
    }
}
