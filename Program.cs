using FerreCampus;

internal class Program
{
        private static void Main(string[] args)
    {
        bool flag = true;
        Fereteria ejecucion = new Fereteria();
        while (flag == true){
            Console.WriteLine("Ferreteria Unica - Bucaramanga - COL");
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Gestion de Inventario");
            Console.WriteLine("2. Gestion de Facturas");
            Console.WriteLine("3. Salir");
            Console.WriteLine("Seleccione una opcion: ");
            int selecInv = int.Parse(Console.ReadLine());
            switch(selecInv){
                case 1:
                    ejecucion.Inventario();
                    break;
                case 2:
                    ejecucion.Factura();
                    break;
                case 3:
                    flag = false;
                    break;
                default:
                    Console.WriteLine("Opcion no valida");
                    break;
            }
        }
    }
}
