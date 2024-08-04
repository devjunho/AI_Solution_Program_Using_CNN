using System;
using System.Windows;
using System.Windows.Controls;
using Helmet;

namespace Helmet.ViewModel
{
    public partial class Result : Page
    {
        private Checking checkingWindow;

        public Result()
        {
            InitializeComponent();
            checkingWindow = new Checking();
            checkingWindow.Show();
        }

        private void Back_btn_Click(object sender, RoutedEventArgs e)
        {
            checkingWindow.Close();
            Uri uri = new Uri("/ViewModel/Menu.xaml", UriKind.Relative);
            NavigationService.Navigate(uri);
        }

        private void Capture_btn_Click(object sender, RoutedEventArgs e)
        {
            if (checkingWindow != null)
            {
                checkingWindow.Capture();
            }
            Result_img.Source = checkingWindow.writableBitmap;
        }
    }
}
