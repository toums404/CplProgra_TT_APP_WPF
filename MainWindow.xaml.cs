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

namespace CplProgra_TT_APP_WPF
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

        private void BtnMenuMail_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Mail());
        }

        private void BtnMenuAccueil_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("La page d'accueil sera créée plus tard !");
        }

        private void BtnMenuTodo_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new TodoPage());
        }
    }
}