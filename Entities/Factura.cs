using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FerreCampus.Entities
{
    public class Factura
    {
        public int NroFact { get; set; }
        public DateTime Fecha { get; set; }
        public int IdCliente { get; set; }
        public decimal Total { get; set; }
    }
}