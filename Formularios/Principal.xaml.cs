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
    /// Lógica de interacción para Principal.xaml
    /// </summary>
    public partial class Principal : Window
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void BtnArticulos_Click(object sender, RoutedEventArgs e)
        {
            var productos = new Productos();
            productos.Show();
            this.Hide();
        }

        private void BtnVender_Click(object sender, RoutedEventArgs e)
        {
            var ventas = new Ventas();
            ventas.Show();
            this.Hide();
        }

        private void BtnClientes_Click(object sender, RoutedEventArgs e)
        {
            var clientes = new Clientes();
            clientes.Show();
            this.Hide();
        }

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
