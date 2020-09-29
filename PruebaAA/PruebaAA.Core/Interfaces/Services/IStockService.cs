using PruebaAA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PruebaAA.Core.Interfaces.Services
{
    public interface IStockService
    {
        public Task<IEnumerable<StockEntity>> GetStockListCSV();
    }
}
