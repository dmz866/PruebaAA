using System;

namespace PruebaAA.Core.Entities
{
    public class StockEntity
    {
        public int PointOfSale { get; set; }
        public string Product { get; set; }
        public DateTime Date { get; set; }
        public int Stock { get; set; }
    }
}
