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
    /// Lógica de interacción para AgregarC.xaml
    /// </summary>
    public partial class AgregarC : Window
    {
        private ApplicationDbContext _context;
        public AgregarC()
        {
            InitializeComponent();
            _context = new ApplicationDbContext();
            MostrarProximoID();
        }
        private void MostrarProximoID()
        {
            // Obtener el último `CLIENTE_ID` y sumar uno
            var ultimoClienteID = _context.Clientes.Max(c => (int?)c.CLIENTE_ID) ?? 0;
            ClienteIDLabel.Content = (ultimoClienteID + 1).ToString();
        }
        private void BtnAgregarC_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var cliente = new Cliente
                {
                    NOMBRE = NombreTextBox.Text,
                    APELLIDO = ApellidoTextBox.Text,
                    DIRECCION = DireccionTextBox.Text,
                    LOCALIDAD = LocalidadTextBox.Text
                };

                _context.Clientes.Add(cliente);
                _context.SaveChanges();

                NombreTextBox.Text = string.Empty;
                ApellidoTextBox.Text = string.Empty;
                DireccionTextBox.Text = string.Empty;
                LocalidadTextBox.Text = string.Empty;

                MessageBox.Show("El Cliente se guardó con éxito.");

                // Preguntar si desea agregar otro cliente o cerrar la ventana
                var result = MessageBox.Show("¿Desea agregar otro cliente?", "Agregar Otro", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    MostrarProximoID();
                    var clientesWindow = Application.Current.Windows.OfType<Clientes>().FirstOrDefault();
                    if (clientesWindow != null)
                    {
                        clientesWindow.LoadClientesDataGrid();
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
                MessageBox.Show("Ocurrió un error al guardar el cliente: " + errorMessage);
            }
        }



        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void NombreTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            Validaciones.SoloLetras(sender, e);
        }

        private void ApellidoTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            Validaciones.SoloLetras(sender, e);
        }

        //no tocar
    }
}
