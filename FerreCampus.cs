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
                    foreach (var product in _productos)
                    {
                        Console.Write("Producto: " + product.Name);
                        Console.WriteLine("-- Cantidad: " + product.Stock);
                    }
                    Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine("Ingrese el ID del producto: ");
                    int idProducto = int.Parse(Console.ReadLine());
                    Producto producto = _productos.Find(p => p.Id == idProducto);
                    if(producto == null){
                        Console.WriteLine("Producto no encontrado");
                        Console.ReadLine();
                        return;
                    }
                    Console.Write("Producto: " + producto.Name);
                    Console.WriteLine("-- Cantidad: " + producto.Stock);
                    Console.ReadLine();
                    break;
                case 3:
                    foreach (var product in _productos)
                    {
                        if((product.Stock < product.StockMin) && (product.Stock > 0)){
                            int comprar = product.StockMax - product.Stock;
                            Console.Write("Producto: " + product.Name);
                            Console.Write("-- Stock: " + product.Stock);
                            Console.WriteLine("-- StockMin: " + product.StockMin);
                        }
                    }
                    break;
                case 4:
                    foreach (var product in _productos)
                    {
                        if(product.Stock < product.StockMin){
                            int comprar = product.StockMax - product.Stock;
                            Console.Write("Producto: " + product.Name);
                            Console.Write("-- Cantidad a comprar: " + comprar);
                            Console.Write("-- Stock: " + product.Stock);
                            Console.Write("-- StockMin: " + product.StockMin);
                            Console.WriteLine("-- StockMax : " + product.StockMax);
                        }
                    }
                    break;
                case 5:
                    float VtotalInv = 0;
                    foreach (var product in _productos)
                    {
                        VtotalInv += product.PrecioUnit * product.Stock;
                    }
                    Console.WriteLine("Valor Total del Inventario: " + VtotalInv);
                    foreach (var product in _productos)
                    {
                        Console.Write("Producto: " + product.Name);
                        Console.Write("-- Stock: " + product.Stock);
                        Console.Write("-- ValorUnit: " + product.PrecioUnit);
                        Console.WriteLine("-- ValorTotal : " + product.PrecioUnit * product.Stock);
                    }
                    break;
                default:
                    Console.WriteLine("Opcion no valida");
                    Console.ReadLine();
                    return;
            }



            
        }
    }
}