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

    public partial class Join : Page
    {
        public Join()
        {
            InitializeComponent();
        }

        private void Back_btn_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("/ViewModel/Login.xaml", UriKind.Relative);
            NavigationService.Navigate(uri);
        }

        private void Join_btn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Name_tb.Text) || string.IsNullOrEmpty(Id_tb.Text) || string.IsNullOrEmpty(Pw_pb.Password))
            {
                MessageBox.Show("모든 정보에 입력해주세요.", "Error");
            }
            else
            {
                int result;
                string EnterName = Name_tb.Text;
                string EnterID = Id_tb.Text;
                string EnterPW = Pw_pb.Password;
                result = Login.con.JoinUser(EnterName, EnterID, EnterPW);
                MessageBox.Show(result.ToString());
                if (result == 10)
                {
                    Uri uri = new Uri("/ViewModel/Login.xaml", UriKind.Relative);
                    NavigationService.Navigate(uri);
                }
            }
        }
    }
}
