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
            try
            {
                StockService stockService = new StockService();
                var stocks = await stockService.GetStockListCSV();

                StockRepository stockRepository = new StockRepository();
                await stockRepository.DeleteBulk();
                await stockRepository.InsertBulk(stocks);
                Console.WriteLine("Archivo importado exitosamente!!!!!!!!!!!!!!!!!!!!!!!!!!");
            }
            catch(Exception ex)
            {
                Console.WriteLine(String.Format("Error al cargar el archivo: {0}", ex.Message));
            }            
        }
    }
}
