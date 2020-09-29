using System;
using System.Threading.Tasks;
using PruebaAA.Infrastructure.Repositories;
using PruebaAA.Infrastructure.Services;

namespace PruebaAA
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            StockService stockService = new StockService();
            var stocks = await stockService.GetStockListCSV();

            StockRepository stockRepository = new StockRepository();
            await stockRepository.DeleteBulk();
            await stockRepository.InsertBulk(stocks);
        }
    }
}
