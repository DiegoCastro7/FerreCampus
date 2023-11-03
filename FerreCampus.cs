using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FerreCampus.Entities;

namespace FerreCampus
{
    public class Fereteria
    {
        //Inyeccion de Productos
        List<Producto> _productos = new List<Producto>(){
            new(){Id = 1, Name = "Martillo", Stock = 5, StockMin = 2, StockMax = 10, PrecioUnit = 12000},
            new(){Id = 2, Name = "Alicate", Stock = 4, StockMin = 5, StockMax = 10, PrecioUnit = 12000},
            new(){Id = 3, Name = "Sierra", Stock = 6, StockMin = 7, StockMax = 10, PrecioUnit = 12000},
            new(){Id = 4, Name = "Pinza", Stock = 8, StockMin = 8, StockMax = 10, PrecioUnit = 12000},
            new(){Id = 5, Name = "Taladro", Stock = 0, StockMin = 2, StockMax = 10, PrecioUnit = 12000}
        };
        //Inyeccion de Clientes
        List<Cliente> _clientes = new List<Cliente>(){
            new(){Id = 1007, Name = "Diego", Age = 23, Email = "fercho11"},
            new(){Id = 245, Name = "Jennifer", Age = 24, Email = "jenniferap"},
            new(){Id = 789, Name = "Alexa", Age = 30, Email = "alezany"},
        };
        //Inyeccion de Facturas
        List<Factura> _facturas = new(){
            new(){
                NroFact = 123, 
                Fecha = new DateTime(2023,11,03), 
                IdCliente = 1, 
                Total = 50000
                },
            new(){NroFact = 234, Fecha = new DateTime(2023,01,13), IdCliente = 2, Total = 100000},
            new(){NroFact = 345, Fecha = new DateTime(2016,12,13), IdCliente = 2, Total = 10000},
            new(){NroFact = 456, Fecha = new DateTime(2023,01,22), IdCliente = 3, Total = 30000},
            new(){NroFact = 567, Fecha = new DateTime(2025,10,13), IdCliente = 4, Total = 5000},
            new(){NroFact = 567, Fecha = new DateTime(2023,01,30), IdCliente = 4, Total = 5000},
            new(){NroFact = 567, Fecha = new DateTime(2014,05,13), IdCliente = 4, Total = 5000},
            new(){NroFact = 567, Fecha = new DateTime(2023,01,03), IdCliente = 4, Total = 5000},
        };
        //Inyeccion de Detalle de Facturas
        List<DetalleFactura> _detalle = new(){
            new(){Id = 1, NroFact = 123, IdProducto = 1, Cantidad = 2},
            new(){Id = 2, NroFact = 123, IdProducto = 2, Cantidad = 3},
            new(){Id = 3, NroFact = 123, IdProducto = 3, Cantidad = 1},
            new(){Id = 4, NroFact = 123, IdProducto = 4, Cantidad = 4},
            new(){Id = 5, NroFact = 234, IdProducto = 1, Cantidad = 3}
        };
        //Compras
        public void Compra(){
            Console.WriteLine("Ingrese el ID del cliente: ");
            int IdCliente = int.Parse(Console.ReadLine());
            Cliente cliente = _clientes.Find(c => c.Id == IdCliente);
            if(cliente == null){
                Console.WriteLine("Cliente no encontrado");
                Console.ReadLine();
                return;
            }
            Console.WriteLine("Ingrese el ID del producto: ");
            int idProducto = int.Parse(Console.ReadLine());
            Producto producto = _productos.Find(p => p.Id == idProducto);
            if(producto == null){
                Console.WriteLine("Producto no encontrado");
                Console.ReadLine();
                return;
            }
            Console.WriteLine("Ingrese la cantidad: ");
            int cantidad = int.Parse(Console.ReadLine());
            if(cantidad > producto.Stock){
                Console.WriteLine("No hay suficiente stock");
                Console.ReadLine();
                return;
            }
/*             producto.Stock -= cantidad;
            Console.WriteLine("Compra realizada con exito");
            int consecutivo = Factura.NroFactura
            List<Factura> _facturas = new List<Factura>(){
            new(){NroFactura = , Fecha = , IdCliente = , TotalCantidad = } 
        };*/
        }
        //Inventario
        public void Inventario(){
            Console.WriteLine("Inventario:");
            Console.WriteLine("1. Listar todos los productos del Inventario");
            Console.WriteLine("2. Buscar un producto en especifico");
            Console.WriteLine("3. Listar productos a punto de agotarse");
            Console.WriteLine("4. Listar productos que deben comprarse");
            Console.WriteLine("5. Valor del Inventario");
            Console.WriteLine("Seleccione una opcion: ");
            int selecInv = int.Parse(Console.ReadLine());
            switch(selecInv){
                case 1:
                    _productos.ForEach(x => Console.WriteLine($"Nombre: {x.Name}, Id: {x.Id}, Stock: {x.Stock}, Precio: {x.PrecioUnit}"));
                    Console.WriteLine("Presione enter para continuar");
                    Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine("Ingrese el ID del producto: ");
                    int idProducto = int.Parse(Console.ReadLine());
                    Producto producto = _productos.Find(p => p.Id == idProducto);
                    if(producto == null){
                        Console.WriteLine("Producto no encontrado");
                        Console.WriteLine("Presione enter para continuar");
                        Console.ReadLine();
                        return;
                    }
                    Console.Write("Producto: " + producto.Name);
                    Console.WriteLine("-- Cantidad: " + producto.Stock);
                    Console.ReadLine();
                    break;
                case 3:
                    var Agotandose = (from j in _productos where (j.Stock < j.StockMin && j.Stock>0) select j).ToList();
                    Console.WriteLine($"Productos proximos a agotarse:");
                    Agotandose.ForEach(J => Console.WriteLine($"{J.Name}: Cantidad: {J.Stock}, StockMin: {J.StockMin}"));
                    Console.WriteLine("Presione enter para continuar");
                    Console.ReadLine();
                    break;
                case 4:
                    var Comprar = (from p in _productos where p.Stock < p.StockMin select p).ToList();
                    Console.WriteLine($"Productos que deben comprarse:");
                    Comprar.ForEach(P => Console.WriteLine($"{P.Name}, se deben comprar {P.StockMax - P.Stock} Und, actualmente solo hay {P.Stock}),"));
                    Console.WriteLine("Presione enter para continuar");
                    Console.ReadLine();
                    break;
                case 5:
                    float VtotalInv = 0;
                    foreach (var product in _productos)
                    {
                        VtotalInv+=(product.Stock*product.PrecioUnit);
                    }
                    Console.WriteLine($"Valor Total del Inventario: {VtotalInv}");
                    foreach (var product in _productos)
                    {
                        Console.WriteLine($"Producto: {product.Name} Valor Total en Inventario {product.PrecioUnit*product.Stock}");
                    }
                    Console.WriteLine("Presione enter para continuar");
                    Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Opcion no valida");
                    Console.WriteLine("Presione enter para continuar");
                    Console.ReadLine();
                    return;
            }
        }
        //Facturas
        public void Factura(){
            Console.WriteLine("Facturas:");
            Console.WriteLine("1. Listar Facturas Enero 2023");
            Console.WriteLine("2. Listar Productos de una factura");
            Console.WriteLine("Seleccione una opcion: ");
            int selecFac = int.Parse(Console.ReadLine());
            switch(selecFac){
                case 1:
                    var Facturas = (from d in _facturas where d.Fecha.Month == 01 && d.Fecha.Year == 2023 select d).ToList();
                    foreach (var item in Facturas)
                    {
                        Console.WriteLine($"{(Facturas.IndexOf(item)+1)}. Num Factura: {item.NroFact}, Total: {item.Total}, Date: {item.Fecha.Day}/{item.Fecha.Month}/{item.Fecha.Year}");
                    }
                    break;
                case 2:
                    Console.WriteLine("Put the number of the receipt: ");
                    int factura = Convert.ToInt32(Console.ReadLine());
                    var list = (from q in _detalle 
                                join w in _facturas 
                                on q.NroFact equals w.NroFact
                                join e in _productos on q.Id equals e.Id
                                where w.NroFact == factura
                                select new {
                                    IdProducto = q.Id,
                                    Cantidad = q.Cantidad,
                                    Fact = q.NroFact,
                                    Nombre = e.Name,
                                    PrecioUnit = e.PrecioUnit,
                                    Total = q.Cantidad * e.PrecioUnit
                                }).ToList();
                    Console.WriteLine($"Productos de la factura {factura}");
                    list.ForEach(z => Console.WriteLine($"{new{z.IdProducto, z.Cantidad, z.Nombre, z.PrecioUnit, z.Total}}"));
                    break;
                default:
                    Console.WriteLine("Opcion no valida");
                    Console.WriteLine("Presione enter para continuar");
                    Console.ReadLine();
                    return;
            }
        }
    }
}