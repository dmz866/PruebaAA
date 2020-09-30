using FileHelpers;
using System;

namespace PruebaAA.Core.Entities
{
    [DelimitedRecord(";"), IgnoreFirst(1)]
    public class StockEntity
    {
        [FieldHidden]
        public long Id { get; set; }
        public int PointOfSale { get; set; }
        public string Product { get; set; }
        [FieldConverter(ConverterKind.Date, "yyyy-mm-dd")]
        public DateTime Date { get; set; }
        public int Stock { get; set; }
    }
}
