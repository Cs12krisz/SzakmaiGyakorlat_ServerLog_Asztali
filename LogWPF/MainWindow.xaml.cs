using LogManager;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LogWPF
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Program.Beolvas();
            dtgLogs.ItemsSource = Program.logok;
            cbxSzintek.ItemsSource = Program.logok.DistinctBy(l => l.Szint).Select(l => l.Szint);
            cbxSzintek.SelectedIndex = 0;
            dtgLogs.SelectedIndex = 0;
        }


        private void btnKovetkezoSzint_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnElozoSzint_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}