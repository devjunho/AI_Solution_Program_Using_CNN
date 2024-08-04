using Helmet.Model;
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
    public partial class Login : Page
    {
        public static Data data = new Data();
        public static CONNECT con = new CONNECT();
        public Login()
        {
            InitializeComponent();
        }

        private void Login_btn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Id_tb.Text) || string.IsNullOrEmpty(Pw_pb.Password))
            {
                MessageBox.Show("아이디 또는 비밀번호를 입력해주세요.", "Error");
            }
            else
            {
                int result;
                string EneterID = Id_tb.Text;
                string EneterPW = Pw_pb.Password;
                result = con.LoginCheck(EneterID, EneterPW);
                //MessageBox.Show(result.ToString());
                //MessageBox.Show(data.NO, "Success");
                //MessageBox.Show(data.NAME, "Success");
                //MessageBox.Show(data.ID, "Success");
                //MessageBox.Show(data.PW, "Success");
                if (result == 10)
                {
                    Uri uri = new Uri("/ViewModel/Menu.xaml", UriKind.Relative);
                    NavigationService.Navigate(uri);
                }
            }
        }

        private void Join_btn_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("/ViewModel/Join.xaml", UriKind.Relative);
            NavigationService.Navigate(uri);
        }
    }
}
