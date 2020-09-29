using Microsoft.EntityFrameworkCore;
using PruebaAA.Core.Entities;
using PruebaAA.Core.Interfaces.Repositories;
using PruebaAA.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaAA.Infrastructure.Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly PruebaAAContext _context;
        public StockRepository()
        {
            _context = new PruebaAAContext();
        }
        public async Task DeleteBulk()
        {
            var stocks = await GetList();
            _context.Stocks.RemoveRange(stocks);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<StockEntity>> GetList()
        {
            var stocks = await _context.Stocks.ToListAsync();
            return stocks;
        }

        public async Task InsertBulk(IEnumerable<StockEntity> stocks)
        {
            foreach(StockEntity stock in stocks)
            {
                _context.Stocks.Add(stock);
            }

            await _context.SaveChangesAsync();
        }
    }
}
