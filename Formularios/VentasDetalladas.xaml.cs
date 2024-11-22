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
    /// Lógica de interacción para VentasDetalladas.xaml
    /// </summary>
    public partial class VentasDetalladas : Window
    {
        private ApplicationDbContext _context;

        public VentasDetalladas()
        {
            InitializeComponent();
            _context = new ApplicationDbContext();
            LoadData();
        }

        private void LoadData()
        {
            VentasitemsDataGridView.ItemsSource = _context.VentasItems.ToList();
        }


        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            var ventas = new Ventas();
            ventas.Show();
            this.Close();
        }
        private void TBXFiltro_TextChanged(object sender, TextChangedEventArgs e)
        {
            int filtro = int.TryParse(TBXFiltro.Text, out var result) ? result : 0;
            var vista = _context.VentasItems.Where(vi => vi.IDVenta.ToString().Contains(filtro.ToString())).ToList();
            VentasitemsDataGridView.ItemsSource = vista;
        }




        //no tocar
    }
}
