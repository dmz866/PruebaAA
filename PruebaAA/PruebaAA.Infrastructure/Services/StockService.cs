using PruebaAA.Core.Entities;
using PruebaAA.Core.Interfaces.Services;
using PruebaAA.Core.Utils;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using FileHelpers;

namespace PruebaAA.Infrastructure.Services
{
    public class StockService : IStockService
    {
        private readonly HttpClient _client;

        public StockService()
        {
            _client = new HttpClient();
        }
        public async Task<IEnumerable<StockEntity>> GetStockListCSV()
        {
            var response = await _client.GetAsync(Constants.STOCK_CSV_URI);
            var content = await response.Content.ReadAsStringAsync();
            var engine = new FileHelperEngine<StockEntity>();
            var stocks = engine.ReadFile(content);
            //var stocks = engine.ReadFile("C:\\Users\\David\\Documents\\Estudios\\Pruebas\\Analyticalways\\PruebaAA\\PruebaAA\\PruebaAA\\bin\\Debug\\netcoreapp3.1\\Stock2.CSV");
        
            return stocks;
        }
    }
}
