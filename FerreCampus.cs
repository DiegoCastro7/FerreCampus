using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using ConsoleTables;
using FerreCampus.Entities;

namespace FerreCampus
{
    public class Fereteria
    {
        //Inyeccion de Productos
        List<Producto> _productos = new List<Producto>(){
            new(){Id = 1, Name = "Martillo", Stock = 5, StockMin = 2, StockMax = 10, PrecioUnit = 12000},
            new(){Id = 2, Name = "Alicate", Stock = 4, StockMin = 5, StockMax = 10, PrecioUnit = 10000},
            new(){Id = 3, Name = "Sierra", Stock = 6, StockMin = 7, StockMax = 10, PrecioUnit = 300000},
            new(){Id = 4, Name = "Pinza", Stock = 8, StockMin = 8, StockMax = 10, PrecioUnit = 40000},
            new(){Id = 5, Name = "Taladro", Stock = 0, StockMin = 2, StockMax = 10, PrecioUnit = 1800000}
        };
        //Inyeccion de Clientes
        List<Cliente> _clientes = new List<Cliente>(){
            new(){Id = 1007, Name = "Diego", Age = 23, Email = "fercho11"},
            new(){Id = 245, Name = "Jennifer", Age = 24, Email = "jenniferap"},
            new(){Id = 789, Name = "Alexa", Age = 30, Email = "alezany"},
        };
        //Inyeccion de Facturas
        List<Factura> _facturas = new(){
            new(){NroFact = 123, Fecha = new DateTime(2023,11,03), IdCliente = 1, Total = 50000},
            new(){NroFact = 234, Fecha = new DateTime(2023,01,13), IdCliente = 2, Total = 100000},
            new(){NroFact = 345, Fecha = new DateTime(2016,12,13), IdCliente = 2, Total = 10000},
            new(){NroFact = 456, Fecha = new DateTime(2023,01,22), IdCliente = 3, Total = 30000},
            new(){NroFact = 567, Fecha = new DateTime(2022,10,13), IdCliente = 4, Total = 5000},
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
            var colombianCulture = new CultureInfo("es-CO");
            Console.Clear();
            Console.WriteLine("Inventario:");
            Console.WriteLine();
            Console.WriteLine("1. Listar todos los productos del Inventario");
            Console.WriteLine("2. Buscar un producto en especifico");
            Console.WriteLine("3. Listar productos a punto de agotarse");
            Console.WriteLine("4. Listar productos que deben comprarse");
            Console.WriteLine("5. Valor del Inventario");
            Console.WriteLine();
            Console.WriteLine("Seleccione una opcion: ");
            string selecInv = Console.ReadLine();
            switch(selecInv){
                case "1":
                    Console.Clear();
                    Console.WriteLine("Inventario:");
                    Console.WriteLine();
                    var table = new ConsoleTable("Nombre","Id","Stock","Precio");
                    _productos.ForEach(z => table.AddRow(z.Name,z.Id,z.Stock,z.PrecioUnit.ToString("C", colombianCulture)));
                    table.Write();
                    Console.WriteLine();
                    Console.WriteLine("Presione enter para continuar");
                    Console.ReadLine();
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("Ingrese el ID del producto: ");
                    try
                    {
                        int idProducto = int.Parse(Console.ReadLine());
                        Console.Clear();
                        Console.WriteLine("Inventario:");
                        Console.WriteLine();
                        Producto producto = _productos.Find(p => p.Id == idProducto);
                        if(producto == null){
                            Console.WriteLine("Producto no encontrado");
                            Console.WriteLine();
                            Console.WriteLine("Presione enter para continuar");
                            Console.ReadLine();
                            return;
                        }
                        Console.Write("Producto: " + producto.Name);
                        Console.WriteLine(" -- Cantidad: " + producto.Stock);
                        Console.WriteLine();
                        Console.WriteLine("Presione enter para continuar");
                        Console.ReadLine();
                    }
                    catch (FormatException)
                    {
                        Console.Clear();
                        Console.WriteLine("Opcion Incorrecta");
                        Console.WriteLine();
                        Console.WriteLine("Presione enter para continuar");
                        Console.ReadLine();
                    }
                    
                    break;
                case "3":
                    Console.Clear();
                    var Agotandose = (from j in _productos where (j.Stock < j.StockMin && j.Stock>0) select j).ToList();
                    Console.WriteLine($"Productos proximos a agotarse:");
                    Console.WriteLine();
                    var table3 = new ConsoleTable("Nombre","Stock","StockMin");
                    Agotandose.ForEach(z => table3.AddRow(z.Name,z.Stock,z.StockMin));
                    table3.Write();
                    Console.WriteLine();
                    Console.WriteLine("Presione enter para continuar");
                    Console.ReadLine();
                    break;
                case "4":
                    Console.Clear();
                    var Comprar = (from p in _productos where p.Stock < p.StockMin select p).ToList();
                    Console.WriteLine($"Productos que deben comprarse:");
                    Console.WriteLine();
                    var table4 = new ConsoleTable("Nombre","Comprar","Stock","StockMax");
                    Comprar.ForEach(P => table4.AddRow(P.Name,P.StockMax - P.Stock,P.Stock,P.StockMax));
                    table4.Write();
                    Console.WriteLine();
                    Console.WriteLine("Presione enter para continuar");
                    Console.ReadLine();
                    break;
                case "5":
                    Console.Clear();
                    float VtotalInv = 0;
                    foreach (var product in _productos)
                    {
                        VtotalInv+=(product.Stock*product.PrecioUnit);
                    }
                    Console.WriteLine($"Valor Total del Inventario: {VtotalInv.ToString("C", colombianCulture)}");
                    Console.WriteLine();
                    var table5 = new ConsoleTable("Nombre","Precio Unit","Stock","Valor Total en Inventario");
                    _productos.ForEach(P => table5.AddRow(P.Name,P.PrecioUnit.ToString("C", colombianCulture),P.Stock,(P.PrecioUnit*P.Stock).ToString("C", colombianCulture)));
                    table5.Write();
                    Console.WriteLine();
                    Console.WriteLine("Presione enter para continuar");
                    Console.ReadLine();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Opcion no valida");
                    Console.WriteLine();
                    Console.WriteLine("Presione enter para continuar");
                    Console.ReadLine();
                    return;
            }
        }
        //Facturas
        public void Factura(){
            var colombianCulture = new CultureInfo("es-CO");
            Console.Clear();
            Console.WriteLine("Facturas:");
            Console.WriteLine();
            Console.WriteLine("1. Listar Facturas por mes y año");
            Console.WriteLine("2. Listar Productos de una factura");
            Console.WriteLine();
            Console.WriteLine("Seleccione una opcion: ");
            string selecFac = Console.ReadLine();
            switch(selecFac){
                case "1":
                    Console.Clear();
                    Console.WriteLine("Facturas:");
                    try
                    {
                        Console.WriteLine("Digite el año que desea Listar");
                        int año = int.Parse(Console.ReadLine());
                        Console.WriteLine("Digite el numero del mes que desea Listar");
                        int mes = int.Parse(Console.ReadLine());
                        if ((mes > 0 && mes < 13)&&(año>0)){
                            Console.Clear();
                            Console.WriteLine("Facturas:");
                            Console.WriteLine();
                            var Facturas = (from d in _facturas where d.Fecha.Month == mes && d.Fecha.Year == año select d).ToList();
                            var table = new ConsoleTable("Nro Factura","Total","Dia","Mes","Año");
                            Facturas.ForEach(P => table.AddRow(P.NroFact,P.Total.ToString("C", colombianCulture),P.Fecha.Day,P.Fecha.Month,P.Fecha.Year));
                            table.Write();
                            Console.WriteLine();
                            Console.WriteLine("Presione enter para continuar");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Opcion Incorrecta");
                            Console.WriteLine();
                            Console.WriteLine("Presione enter para continuar");
                            Console.ReadLine();
                            return;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.Clear();
                        Console.WriteLine("Opcion no valida");
                        Console.WriteLine();
                        Console.WriteLine("Presione enter para continuar");
                        Console.ReadLine();
                        return;
                    }
                    
                    
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("Ingrese el numero de la factura: ");
                    try
                    {
                        int factura = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                        Factura facturita = _facturas.Find(c => c.NroFact == factura);
                        if(facturita == null){
                            Console.WriteLine("Factura no encontrada");
                            Console.WriteLine();
                            Console.WriteLine("Presione enter para continuar");
                            Console.ReadLine();
                            return;
                        }
                        else{
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
                            Console.WriteLine($"Productos de la factura #{factura}");
                            Console.WriteLine();
                            var table2 = new ConsoleTable("IdProducto","Cantidad","Nombre","Precio Unit","Total");
                            list.ForEach(z => table2.AddRow(z.IdProducto,z.Cantidad,z.Nombre,z.PrecioUnit.ToString("C", colombianCulture),z.Total.ToString("C", colombianCulture)));
                            table2.Write();
                            Console.WriteLine();
                            Console.WriteLine("Presione enter para continuar");
                            Console.ReadLine();
                            }
                    }
                    catch (FormatException)
                    {
                        Console.Clear();
                        Console.WriteLine("Opcion Incorrecta");
                        Console.WriteLine();
                        Console.WriteLine("Presione enter para continuar");
                        Console.ReadLine();
                    }
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Opcion no valida");
                    Console.WriteLine();
                    Console.WriteLine("Presione enter para continuar");
                    Console.ReadLine();
                    return;
            }
        }
    }
}