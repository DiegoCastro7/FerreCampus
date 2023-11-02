using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FerreCampus.Entities
{
    public class Producto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float PrecioUnit { get; set; }
        public int Stock { get; set; }
        public int StockMin { get; set; }
        public int StockMax { get; set; }
    }
}