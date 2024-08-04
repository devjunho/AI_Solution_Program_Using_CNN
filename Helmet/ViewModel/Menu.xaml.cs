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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Helmet.ViewModel
{
    public partial class Menu : Page
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Checking_btn_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("/ViewModel/Result.xaml", UriKind.Relative);
            NavigationService.Navigate(uri);
        }

        private void Result_btn_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("/ViewModel/History.xaml", UriKind.Relative);
            NavigationService.Navigate(uri);
        }
    }
}
