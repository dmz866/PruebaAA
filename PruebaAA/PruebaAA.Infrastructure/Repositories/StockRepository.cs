using Microsoft.EntityFrameworkCore;
using PruebaAA.Core.Entities;
using PruebaAA.Core.Interfaces.Repositories;
using PruebaAA.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaAA.Infrastructure.Repositories
{
    public class StockRepository : IStockRepository
    {
        private PruebaAAContext _context;
        public StockRepository()
        {
            _context = new PruebaAAContext();
        }
        public async Task DeleteBulk()
        {
            var stocks = await GetList();

            if(stocks.Count() > 0)
            {
                _context.Stocks.RemoveRange(stocks);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<StockEntity>> GetList()
        {
            var stocks = await _context.Stocks.ToListAsync();
            return stocks;
        }

        public async Task InsertBulk(IEnumerable<StockEntity> stocks)
        {
            int recordCount = 50000; // Realice varias pruebas y 50000 me parecio una buena opcion para la insercion de records
            int skipCount = 0;
            int batchCount = 0;

            //var stopwatch = new Stopwatch();
            
            while (skipCount <= stocks.Count())
            {
                //stopwatch.Start();

                // Insertamos por grupos para mejorar el rendimiento y no crashear la app
                var stockList = stocks.Skip(skipCount)
                                .Take(recordCount)
                                .Select(s => 
                                new StockEntity { 
                                    Id = s.Id, 
                                    Product = s.Product, 
                                    Date = s.Date, 
                                    PointOfSale = s.PointOfSale, 
                                    Stock = s.Stock 
                                });

                await _context.Stocks.AddRangeAsync(stockList);
                await _context.SaveChangesAsync();
                skipCount += recordCount;
                
                //stopwatch.Stop();
                //Console.WriteLine("Tiempo de ejecucion: " + stopwatch.Elapsed.TotalSeconds);
                //stopwatch.Restart();
                batchCount++;
                                
                // Dispose el context para limpiar las miles de entidades atadas a el
                if (batchCount >= 10)
                {
                    _context.Dispose();
                    _context = new PruebaAAContext();
                    batchCount = 0;
                }
            }            
        }
    }
}
