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
    /// Lógica de interacción para Ventas.xaml
    /// </summary>
    public partial class Ventas : Window
    {
        private ApplicationDbContext _context;

        public Ventas()
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
                             v.ID_VENTA,
                             v.FECHA,
                             ClienteNombre = c.NOMBRE,
                             v.IMPORTE,
                             v.TIPODEPAGO
                         };

            VentasDataGridView.ItemsSource = ventas.ToList();
        }

        private void BtnEliminarVentas_Click(object sender, RoutedEventArgs e)
        {
            var ventaSeleccionada = (Venta)VentasDataGridView.SelectedItem;

            if (ventaSeleccionada != null)
            {
                var result = MessageBox.Show("¿Desea eliminar el archivo seleccionado?", "Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    _context.Ventas.Remove(ventaSeleccionada);
                    _context.SaveChanges();
                    LoadData();
                    MessageBox.Show("El Archivo fue eliminado con éxito");
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una venta para eliminar");
            }
        }

        private void BusqPart_Click(object sender, RoutedEventArgs e)
        {
            var ventasDetalladas = new VentasDetalladas();
            ventasDetalladas.Show();
            this.Close();
        }

        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            var principal = new Principal();
            principal.Show();
            this.Close();
        }

        private void BtnVender_Click(object sender, RoutedEventArgs e)
        {
            var transacciones = new Transacciones();
            transacciones.Show();
            this.Close();
        }

        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TBXFiltro.Text))
            {
                MessageBox.Show("Debe ingresar un valor");
            }
            else
            {
                int filtro = int.Parse(TBXFiltro.Text);
                var venta = _context.Ventas.FirstOrDefault(v => v.ID_VENTA == filtro);

                if (venta == null)
                {
                    MessageBox.Show("El Registro no se encuentra en los campos establecidos");
                }
                else
                {
                    VentasDataGridView.ItemsSource = new List<Venta> { venta };
                }
            }
        }
        private void TBXFiltro_TextChanged(object sender, TextChangedEventArgs e)
        {
            //if (e.Key == Key.Enter)             // Para saber si se presionó Enter
            //{
            //    BtnBuscar.Focus();
            //}
        }
        private void TBXFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)             // Para saber si se presionó Enter
            {
                BtnBuscar.Focus();
            }
        }


        //no tocar
    }
}
