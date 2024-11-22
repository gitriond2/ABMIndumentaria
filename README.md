# ABMIndumentaria
markdown
# Proyecto IndumentariaIntimaWPF

Este es un proyecto de gestión de ventas para una tienda de indumentaria. Permite agregar, editar y eliminar productos, así como registrar ventas y gestionar clientes. El proyecto está desarrollado en C# utilizando WPF y Entity Framework para la interacción con la base de datos.

## Configuración Inicial

1. **Clonar el Repositorio:**

   ```sh
   git clone https://github.com/tu_usuario/IndumentariaIntimaWPF.git
   cd IndumentariaIntimaWPF
Configurar la Cadena de Conexión:

Asegúrate de configurar correctamente la cadena de conexión a tu base de datos en el archivo App.config:

xml
<connectionStrings>
  <add name="ApplicationDbContext" connectionString="Your_Connection_String_Here" providerName="System.Data.SqlClient" />
</connectionStrings>
Aplicar Migraciones:

Asegúrate de aplicar todas las migraciones para actualizar la base de datos:

sh
Update-Database
Funcionalidades
Agregar y Gestionar Productos
Agregar Producto:

Navega a AgregarP.xaml.cs y utiliza el botón Guardar para agregar un nuevo producto. El PRODUCTO_ID se generará automáticamente.

El método BtnGuardar_Click maneja la lógica de agregar un producto y actualizar la vista.

Gestionar Ventas
Registrar Venta:

En el formulario de Transacciones, selecciona un cliente y productos, y utiliza el botón Concretar para registrar una venta.

El método BtnConcretar_Click maneja la lógica de registrar una venta, incluyendo el cálculo del importe total y la actualización de la grilla de ventas.

Combobox para Tipo de Pago
Opciones de Tipo de Pago:

Agregamos un ComboBox en el formulario de Transacciones para seleccionar el tipo de pago (Efectivo, TarjetadeCredito, TransferenciaBancaria, TarjetadeDebito).

La selección se utiliza para registrar el tipo de pago al concretar una venta.

Manejo de Excepciones
Captura de Errores:

Se añadieron bloques try-catch para capturar y mostrar detalles de las excepciones internas, ayudando en la depuración y solución de problemas.

Actualización de Grillas
Actualizar VentasDataGridView:

Después de realizar una venta, se actualiza la vista de ventas utilizando la clase VentaService para obtener los datos actualizados.

Clases de Servicio
VentaService:

Se creó la clase VentaService para encapsular las consultas LINQ a la base de datos, mejorando la modularidad y reutilización del código.

csharp
public class VentaService
{
    private readonly ApplicationDbContext _context;

    public VentaService(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<Venta> ObtenerTodasLasVentas()
    {
        return _context.Ventas.ToList();
    }

    public Venta ObtenerVentaPorId(int idVenta)
    {
        return _context.Ventas.FirstOrDefault(v => v.ID_VENTA == idVenta);
    }

    public List<Venta> ObtenerVentasPorCliente(int clienteId)
    {
        return _context.Ventas.Where(v => v.CLIENTE == clienteId).ToList();
    }

    public List<VentasItem> ObtenerItemsDeVenta(int idVenta)
    {
        return _context.VentasItems.Where(vi => vi.IDVenta == idVenta).ToList();
    }

    public List<Venta> ObtenerVentasPorFecha(DateTime fechaInicio, DateTime fechaFin)
    {
        return _context.Ventas.Where(v => v.FECHA >= fechaInicio && v.FECHA <= fechaFin).ToList();
    }
}
Contribuciones
Si deseas contribuir a este proyecto, por favor sigue los siguientes pasos:

Fork el Repositorio

Crea una Rama (git checkout -b feature-nueva-funcionalidad)

Realiza tus Cambios y Confirma los Commits (git commit -am 'Agrega nueva funcionalidad')

Empuja a la Rama (git push origin feature-nueva-funcionalidad)

Abre un Pull Request

Licencia
Este proyecto está bajo la Licencia MIT.
