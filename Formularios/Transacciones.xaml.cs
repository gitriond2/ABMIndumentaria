using IndumentariaIntimaWPF.Data;
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
using System.Data.Entity.Validation;

namespace IndumentariaIntimaWPF.Formularios
{
    /// <summary>
    /// Lógica de interacción para Transacciones.xaml
    /// </summary>
    public partial class Transacciones : Window
    {

        private int registroSel = 0;
        //private int n = 0;
        private ApplicationDbContext _context;

        public Transacciones()
        {
            InitializeComponent();
            _context = new ApplicationDbContext();
            LoadData();
        }

        private void LoadData()
        {
            var ventas = from v in _context.Ventas
                         join c in _context.Clientes on v.CLIENTE equals c.CLIENTE_ID
                         select new
                         {
                             //v.ID_VENTA,
                             v.FECHA,
                             ClienteNombre = c.NOMBRE,
                             v.IMPORTE,
                             v.TIPODEPAGO
                         };
            ClienteComboBox.ItemsSource = _context.Clientes.ToList();
            ProductosDataGridView.ItemsSource = _context.Productos.ToList();

        }


        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            var ventas = new Ventas();
            ventas.Show();
            this.Close();
        }
        private void BtnClientes_Click(object sender, RoutedEventArgs e)
        {
            var agregarC = new AgregarC();
            agregarC.Show();
        }

        private void BtnAgregarP_Click(object sender, RoutedEventArgs e)
        {
            var agregarP = new AgregarP();
            agregarP.Show();
        }



        private void BtnClean_Click(object sender, RoutedEventArgs e)
        {
            DataGridViewVentas.Items.Clear();  // Limpiar el DataGridView
        }

        private void BtnAgregarProd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string posProduc = ((Producto)ProductosDataGridView.SelectedItem).NOMBRE;
                var productoSeleccionado = _context.Productos.FirstOrDefault(p => p.NOMBRE == posProduc);

                if (productoSeleccionado == null)
                {
                    MessageBox.Show("No se encontró el Producto");
                }
                else
                {
                    var result = MessageBox.Show("¿Quiere agregar este producto?", "Vender", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        var inputBox = new InputBox("Cantidad que desea vender:");
                        if (inputBox.ShowDialog() == true)
                        {
                            int consultaCant = int.Parse(inputBox.ResponseText);
                            if (consultaCant <= 0)
                            {
                                MessageBox.Show("Ingrese un valor correspondiente numérico mayor que 0, e inténtelo nuevamente");
                            }
                            else
                            {
                                int addF = DataGridViewVentas.Items.Count;
                                int posFV = addF + _context.Ventas.Count() + 1;

                                var newItem = new
                                {
                                    IDVenta = posFV,
                                    IDProducto = productoSeleccionado.PRODUCTO_ID,
                                    Precio = productoSeleccionado.IMPORTE,
                                    Cantidad = consultaCant,
                                    Total = consultaCant * productoSeleccionado.IMPORTE
                                };

                                DataGridViewVentas.Items.Add(newItem);
                                DataGridViewVentas.Items.Refresh();

                                MessageBox.Show("Se ha guardado con éxito");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message);
            }
        }


        private void BtnConcretar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int filas = DataGridViewVentas.Items.Count;
                var clienteSeleccionado = (Cliente)ClienteComboBox.SelectedItem;
                int filaC = clienteSeleccionado.CLIENTE_ID;

                var result = MessageBox.Show("¿Quiere realizar esta venta?", "Vender", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    // Obtener el valor seleccionado del ComboBox
                    var tipoDePago = (ComboBoxItem)TipoDePagoComboBox.SelectedItem;
                    string tipoDePagoSeleccionado = tipoDePago.Content.ToString();

                    var venta = new Venta
                    {
                        CLIENTE = filaC,
                        FECHA = FechaCaptura.SelectedDate ?? DateTime.Now,
                        IMPORTE = 0, // Se calculará más adelante
                        TIPODEPAGO = tipoDePagoSeleccionado // Usar el valor seleccionado
                    };

                    _context.Ventas.Add(venta);
                    _context.SaveChanges(); // Guardar la venta para obtener su ID

                    int ventaId = venta.ID_VENTA; // Obtener el ID de la venta recién guardada
                    int importe = 0;

                    for (int i = 0; i < filas; i++)
                    {
                        dynamic item = DataGridViewVentas.Items[i];
                        var ventasItem = new VentasItem
                        {
                            IDVenta = ventaId,
                            IDProducto = item.IDProducto,
                            PrecioUnitario = item.Precio,
                            Cantidad = item.Cantidad,
                            PrecioTotal = item.Total
                        };
                        _context.VentasItems.Add(ventasItem);
                        importe += item.Total;
                    }

                    // Actualizar el importe total de la venta
                    venta.IMPORTE = importe;
                    _context.SaveChanges();

                    MessageBox.Show($"La venta ha sido exitosa, el importe es: {importe} Pesos");

                    // Limpiar DataGridView y TextBox
                    DataGridViewVentas.Items.Clear();
                    TBXBusqueda.Focus();
                    TBXBusqueda.Text = string.Empty;
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
                MessageBox.Show("Ocurrió un error: " + errorMessage);
            }
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int n = DataGridViewVentas.Items.Count;
                int j = _context.VentasItems.Count() + 1;

                if (registroSel != -1 && registroSel < n)
                {
                    DataGridViewVentas.Items.RemoveAt(registroSel);
                    for (int i = 0; i < n - 1; i++)
                    {
                        var item = DataGridViewVentas.Items[i];
                        // Assuming the structure of the item allows setting values this way
                        var dynamicItem = item as dynamic;
                        dynamicItem.ID = j;
                        j++;
                    }
                    DataGridViewVentas.Items.Refresh();
                    MessageBox.Show("El archivo fue eliminado con éxito");
                }
                else
                {
                    MessageBox.Show("Parámetro mal indicado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al eliminar el producto: " + ex.Message);
            }
        }
        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TBXBusqueda.Text))
            {
                MessageBox.Show("Debe ingresar un valor");
            }
            else
            {
                int filtro = int.Parse(TBXBusqueda.Text);
                var producto = _context.Productos.FirstOrDefault(p => p.NOMBRE.Contains(filtro.ToString()));

                if (producto == null)
                {
                    MessageBox.Show("El Registro no se encuentra en los campos establecidos");
                }
                else
                {
                    ProductosDataGridView.ItemsSource = new List<Producto> { producto };
                }
            }
        }

        //private string InputBox(string prompt, string title)
        //{
        //    Window inputBox = new Window
        //    {
        //        Width = 300,
        //        Height = 150,
        //        Title = title,
        //        WindowStartupLocation = WindowStartupLocation.CenterScreen
        //    };

        //    StackPanel panel = new StackPanel();
        //    panel.Children.Add(new TextBlock { Text = prompt, Margin = new Thickness(10) });

        //    TextBox textBox = new TextBox { Width = 200, Margin = new Thickness(10) };
        //    panel.Children.Add(textBox);

        //    Button confirmation = new Button
        //    {
        //        Content = "Ok",
        //        Width = 50,
        //        Height = 30,
        //        Margin = new Thickness(10)
        //    };
        //    confirmation.Click += (sender, e) => { inputBox.DialogResult = true; inputBox.Close(); };
        //    panel.Children.Add(confirmation);

        //    inputBox.Content = panel;
        //    inputBox.ShowDialog();
        //    return textBox.Text;
        //}







        //no tocar
    }
}
