using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FerreCampus.Entities
{
    public class DetalleFactura
    {
        public int Id { get; set; }
        public int NroFact { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public int Total { get; set; }
    }
}