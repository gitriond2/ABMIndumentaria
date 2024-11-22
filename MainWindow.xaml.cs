using System.Linq;
using System.Windows;
using IndumentariaIntimaWPF.Data;

namespace IndumentariaIntimaWPF
{
    public partial class MainWindow : Window
    {
        private ApplicationDbContext _context;

        public MainWindow()
        {
            InitializeComponent();
            _context = new ApplicationDbContext();
        }

        private void CargarDatos_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new ApplicationDbContext())
            {
                var clientes = context.Clientes.ToList();
                DataGridClientes.ItemsSource = clientes;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new ApplicationDbContext())
            {
                var clientes = context.Clientes.ToList();
                DataGridClientes.ItemsSource = clientes;
            }
        }
    }
}

