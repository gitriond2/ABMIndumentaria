using IndumentariaIntimaWPF.Data;
using Microsoft.Identity.Client;
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
using IndumentariaIntimaWPF.Models;

namespace IndumentariaIntimaWPF.Formularios
{
    /// <summary>
    /// Lógica de interacción para Productos.xaml
    /// </summary>
    public partial class Productos : Window
    {
        private ApplicationDbContext _context;

        public Productos()
        {
            InitializeComponent();
            _context = new ApplicationDbContext();
            LoadData();
            LoadProductsDataGrid();
        }

        private void LoadData()
        {
            ProductosDataGridView.ItemsSource = _context.Productos.ToList();
        }
        public void LoadProductsDataGrid()
        {
            var productos = _context.Productos.ToList();
            ProductosDataGridView.ItemsSource = productos;
        }

        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
            var agregarP = new AgregarP();
            agregarP.Show();
        }

        private void BtnModificar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _context.SaveChanges();
                LoadData();
                MessageBox.Show("El Archivo fue modificado exitosamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al guardar los cambios: " + ex.Message);
            }
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var codigoConsulta = InputBox("Ingrese el código de búsqueda:", "Eliminar Producto");

                if (int.TryParse(codigoConsulta, out int productoID))
                {
                    var producto = _context.Productos.FirstOrDefault(p => p.PRODUCTO_ID == productoID);

                    if (producto == null)
                    {
                        MessageBox.Show("El Registro no se encuentra en los campos establecidos o debe ingresar un valor numérico.");
                    }
                    else
                    {
                        var ventasAsociadas = _context.VentasItems.Any(vi => vi.IDProducto == producto.PRODUCTO_ID);
                        if (!ventasAsociadas)
                        {
                            var confirmResult = MessageBox.Show("¿Desea eliminar el archivo seleccionado?", "Eliminar", MessageBoxButton.YesNo);
                            if (confirmResult == MessageBoxResult.Yes)
                            {
                                _context.Productos.Remove(producto);
                                _context.SaveChanges();

                                // Actualizar la grilla después de eliminar
                                var productosWindow = Application.Current.Windows.OfType<Productos>().FirstOrDefault();
                                if (productosWindow != null)
                                {
                                    productosWindow.LoadProductsDataGrid();
                                }

                                MessageBox.Show("El Archivo fue eliminado con éxito.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Este producto no es posible eliminarlo porque pertenece a un registro. Elimine los registros relacionados para poder eliminarlo.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Debe ingresar un valor numérico válido.");
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
                MessageBox.Show("Ocurrió un error al eliminar el producto: " + errorMessage);
            }
        }

        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            var principal = new Principal();
            principal.Show();
            this.Close();
        }
        private void TBXFiltroArticulo_KeyDown(object sender, KeyEventArgs e)
        {
            Validaciones.SoloLetras(sender, e);
        }
        private void TBXFiltroArticulo_TextChanged(object sender, TextChangedEventArgs e)
        {
            var filtro = TBXFiltroArticulo.Text;
            var productosFiltrados = _context.Productos.Where(p => p.NOMBRE.Contains(filtro)).ToList();
            ProductosDataGridView.ItemsSource = productosFiltrados;
        }
        private string InputBox(string prompt, string title)
        {
            Window inputBox = new Window
            {
                Width = 300,
                Height = 150,
                Title = title,
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };

            StackPanel panel = new StackPanel();
            panel.Children.Add(new TextBlock { Text = prompt, Margin = new Thickness(10) });

            TextBox textBox = new TextBox { Width = 200, Margin = new Thickness(10) };
            panel.Children.Add(textBox);

            Button confirmation = new Button
            {
                Content = "Ok",
                Width = 50,
                Height = 30,
                Margin = new Thickness(10)
            };
            confirmation.Click += (sender, e) => { inputBox.DialogResult = true; inputBox.Close(); };
            panel.Children.Add(confirmation);

            inputBox.Content = panel;
            inputBox.ShowDialog();
            return textBox.Text;
        }
    }
}
