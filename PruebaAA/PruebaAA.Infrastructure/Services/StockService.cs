using PruebaAA.Core.Entities;
using PruebaAA.Core.Interfaces.Services;
using PruebaAA.Core.Utils;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using FileHelpers;
using System;

namespace PruebaAA.Infrastructure.Services
{
    public class StockService : IStockService
    {
        private readonly HttpClient _client;

        public StockService()
        {
            _client = new HttpClient();
            _client.Timeout = TimeSpan.FromDays(1); // el CSV pesa mas de 650MB, por lo tanto actualice el timeout para que la app obtenga el archivo 
        }
        public async Task<IEnumerable<StockEntity>> GetStockListCSV()
        {
            var response = await _client.GetAsync(Constants.STOCK_CSV_URI);
            var content = await response.Content.ReadAsStringAsync();
            var engine = new FileHelperEngine<StockEntity>();
            var stocks = engine.ReadString(content);
            
            return stocks;
        }
    }
}
