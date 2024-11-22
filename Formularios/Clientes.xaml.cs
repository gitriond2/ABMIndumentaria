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
using IndumentariaIntimaWPF.Data;
using IndumentariaIntimaWPF.Models;

namespace IndumentariaIntimaWPF.Formularios
{
    /// <summary>
    /// Lógica de interacción para Clientes.xaml
    /// </summary>
    public partial class Clientes : Window
    {
        private ApplicationDbContext _context;

        public Clientes()
        {
            InitializeComponent();
            _context = new ApplicationDbContext();
            LoadData();
            LoadClientesDataGrid();
        }
        public void LoadClientesDataGrid()
        {
            var clientes = _context.Clientes.ToList();
            ClientesDataGridView.ItemsSource = clientes;
        }
        private void LoadData()
        {
            ClientesDataGridView.ItemsSource = _context.Clientes.ToList();
        }


        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
            var agregarC = new AgregarC();
            agregarC.Show();
        }



        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (ClientesDataGridView.SelectedItem != null)
            {
                var cliente = (Cliente)ClientesDataGridView.SelectedItem;
                var tieneVentas = _context.Ventas.Any(v => v.CLIENTE == cliente.CLIENTE_ID);

                if (!tieneVentas)
                {
                    _context.Clientes.Remove(cliente);
                    _context.SaveChanges();
                    LoadData();
                    MessageBox.Show("El Archivo fue eliminado con éxito");
                }
                else
                {
                    MessageBox.Show("Este cliente no es posible eliminarlo porque pertenece a un registro, elimine los registros relacionados para poder eliminarlo");
                }
            }
            else
            {
                MessageBox.Show("Por favor seleccione un cliente para eliminar");
            }
        }

        private void BtnBuscarClientes_Click(object sender, RoutedEventArgs e)
        {
            var filtro = TbxBusquedaClientes.Text;
            var cliente = _context.Clientes.FirstOrDefault(c => c.NOMBRE.Contains(filtro) || c.APELLIDO.Contains(filtro));

            if (cliente == null)
            {
                MessageBox.Show("El Registro no se encuentra en los campos establecidos o no agregó un valor numérico");
            }
            else
            {
                ClientesDataGridView.SelectedItem = cliente;
                ClientesDataGridView.ScrollIntoView(cliente);
            }
        }

        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            var principal = new Principal();
            principal.Show();
            this.Close();
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
        private void ClientesDataGridView_CellContentClick(object sender, DataGridCellInfo e)
        {
            //if (e.RowIndex >= 0)
            //{
            //    var fila = e.RowIndex;
            //    var cliente = (Cliente)ClientesDataGridView.Items[fila];
            //    var transaccion = new Transaccion();
            //    transaccion.TBXBusqueda.Text = cliente.CLIENTE_ID.ToString();
            //    transaccion.TbxCantidad.Focus();
            //    transaccion.Show();
            //    this.Close();
            //}
        }

















        //no tocar
    }
}
