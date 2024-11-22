using System;
using System.Data.Entity;
using IndumentariaIntimaWPF.Models;
using System.Linq;

namespace IndumentariaIntimaWPF.Data
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            // Verificar si hay datos en la tabla Clientes
            if (!context.Clientes.Any())
            {
                Console.WriteLine("La tabla Clientes está vacía.");
                // Aquí puedes optar por agregar datos de prueba si es necesario
            }
            else
            {
                var clientes = context.Clientes.ToList();
                Console.WriteLine("Clientes existentes:");
                foreach (var cliente in clientes)
                {
                    Console.WriteLine($"ID: {cliente.CLIENTE_ID}, Nombre: {cliente.NOMBRE}, Apellido: {cliente.APELLIDO}");
                }
            }

            // Verificar si hay datos en la tabla Productos
            if (!context.Productos.Any())
            {
                Console.WriteLine("La tabla Productos está vacía.");
                // Aquí puedes optar por agregar datos de prueba si es necesario
            }
            else
            {
                var productos = context.Productos.ToList();
                Console.WriteLine("Productos existentes:");
                foreach (var producto in productos)
                {
                    Console.WriteLine($"ID: {producto.PRODUCTO_ID}, Nombre: {producto.NOMBRE}, Marca: {producto.MARCA}, Importe: {producto.IMPORTE}");
                }
            }

            // Verificar si hay datos en la tabla Ventas
            if (!context.Ventas.Any())
            {
                Console.WriteLine("La tabla Ventas está vacía.");
                // Aquí puedes optar por agregar datos de prueba si es necesario
            }
            else
            {
                var ventas = context.Ventas.Include(v => v.VentasItems).ToList();
                Console.WriteLine("Ventas existentes:");
                foreach (var venta in ventas)
                {
                    foreach (var item in venta.VentasItems)
                    {
                        Console.WriteLine($"ID: {venta.ID_VENTA}, Fecha: {venta.FECHA}, Cliente: {venta.CLIENTE}, Producto: {item.IDProducto}, Cantidad: {item.Cantidad}, Importe: {item.PrecioTotal}, Tipo de Pago: {venta.TIPODEPAGO}");
                    }
                }
            }
        }
    }
}




