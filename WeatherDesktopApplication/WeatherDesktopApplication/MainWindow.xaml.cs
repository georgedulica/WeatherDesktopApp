using System.Windows;
using System.Windows.Controls;

namespace WeatherDesktopApplication
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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var location = LocationTextBox.Text;
            if (string.IsNullOrEmpty(location))
            {
            }
        }
    }
}