using System.Windows.Input;

namespace IndumentariaIntimaWPF
{
    public static class Validaciones
    {
        public static void SoloNumeros(object sender, KeyEventArgs e)
        {
            if (!(e.Key >= Key.D0 && e.Key <= Key.D9 ||
                  e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9 ||
                  e.Key == Key.Back || e.Key == Key.Space))
            {
                e.Handled = true;
            }
        }

        public static void SoloLetras(object sender, KeyEventArgs e)
        {
            if (!(e.Key >= Key.A && e.Key <= Key.Z ||
                  e.Key >= Key.A && e.Key <= Key.Z ||
                  e.Key == Key.Back || e.Key == Key.Space))
            {
                e.Handled = true;
            }
        }
    }
}
