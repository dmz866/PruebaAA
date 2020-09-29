using PruebaAA.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaAA.Core.Interfaces.Repositories
{
    public interface IStockRepository
    {
        public Task InsertBulk(IEnumerable<StockEntity> stock);
        public Task DeleteBulk();
        public Task<IEnumerable<StockEntity>> GetList();
    }
}
