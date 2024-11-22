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
    /// Lógica de interacción para InputBox.xaml
    /// </summary>
    public partial class InputBox : Window
    {
        public string ResponseText { get; private set; }

        public InputBox(string question)
        {
            InitializeComponent();
            lblQuestion.Content = question;
        }

        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            ResponseText = txtAnswer.Text;
            DialogResult = true;
        }
    }
}
