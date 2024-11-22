using System.Windows;

namespace IndumentariaIntimaWPF
{
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

