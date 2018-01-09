using System.Windows;
using System.Windows.Media;

namespace CodedUITestApplication.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (int.TryParse(txtFirstAmount.Text, out var amount1) && int.TryParse(txtSecondAmount.Text, out var amount2))
            {
                lblResult.Foreground = Brushes.Black;
                lblResult.Content = (amount1 + amount2).ToString();
            }
            else
            {
                lblResult.Foreground = Brushes.Red;
                lblResult.Content = "Unable to add non numeric values";
            }

        }
    }
}
