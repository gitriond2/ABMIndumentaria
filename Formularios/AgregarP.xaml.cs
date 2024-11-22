using IndumentariaIntimaWPF.Data;
using IndumentariaIntimaWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace IndumentariaIntimaWPF.Formularios
{
    /// <summary>
    /// Lógica de interacción para AgregarP.xaml
    /// </summary>
    public partial class AgregarP : Window
    {
        private ApplicationDbContext _context;

        public AgregarP()
        {
            InitializeComponent();
            _context = new ApplicationDbContext();
            MostrarProximoID();
            // No es necesario cargar los productos aquí ya que se hace en la clase Productos
        }


        private void MostrarProximoID()
        {
            // Obtener el último `PRODUCTO_ID` y sumar uno
            var ultimoProductoID = _context.Productos.Max(p => (int?)p.PRODUCTO_ID) ?? 0;
            ProductoIDLabel.Content = (ultimoProductoID + 1).ToString();
        }

        private void LoadData()
        {
            // Puedes cargar datos aquí si es necesario
            // var productos = _context.Productos.ToList();
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var producto = new Producto
                {
                    NOMBRE = NombreTextBox.Text,
                    IMPORTE = decimal.Parse(ImporteTextBox.Text),
                    MARCA = MarcaTextBox.Text,
                    Descripcion = DescripcionTextBox.Text // Asegúrate de agregar el campo de descripción si existe
                };

                _context.Productos.Add(producto);
                _context.SaveChanges();

                NombreTextBox.Text = string.Empty;
                ImporteTextBox.Text = string.Empty;
                MarcaTextBox.Text = string.Empty;
                DescripcionTextBox.Text = string.Empty; // Limpiar descripción también si existe

                MessageBox.Show("El producto se guardó con éxito.");

                // Preguntar si desea agregar otro producto o cerrar la ventana
                var result = MessageBox.Show("¿Desea agregar otro producto?", "Agregar Otro", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    MostrarProximoID();
                    var productosWindow = Application.Current.Windows.OfType<Productos>().FirstOrDefault();
                    if (productosWindow != null)
                    {
                        productosWindow.LoadProductsDataGrid(); // Invoca el método de Productos.xaml.cs
                    }
                    NombreTextBox.Focus();
                }
                else
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                var errorMessage = ex.Message;
                var innerException = ex.InnerException;
                while (innerException != null)
                {
                    errorMessage += "\nInner Exception: " + innerException.Message;
                    innerException = innerException.InnerException;
                }
                MessageBox.Show("Ocurrió un error al guardar el producto: " + errorMessage);
            }
        }

        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void NombreTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            Validaciones.SoloLetras(sender, e);
        }

        private void MarcaTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            Validaciones.SoloLetras(sender, e);
        }

        private void ImporteTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            Validaciones.SoloNumeros(sender, e);
        }
    }
}
