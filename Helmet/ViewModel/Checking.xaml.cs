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
using Helmet.ViewModel;

// OpenCV 사용을 위한 using
using OpenCvSharp;
using OpenCvSharp.WpfExtensions;

// Timer 사용을 위한 using
using System.Windows.Threading;

namespace Helmet
{
    public partial class Checking : System.Windows.Window
    {
        // 필요한 변수 선언
        VideoCapture cam;
        Mat frame;
        DispatcherTimer timer;
        bool is_initCam, is_initTimer;
        public WriteableBitmap writableBitmap;

        public Checking()
        {
            InitializeComponent();
        }

        private void windows_loaded(object sender, RoutedEventArgs e)
        {
            // 카메라, 타이머(0.01ms 간격) 초기화
            is_initCam = init_camera();
            is_initTimer = init_Timer(0.01);

            // 초기화 완료면 타이머 실행
            if (is_initTimer && is_initCam) timer.Start();
        }

        private bool init_Timer(double interval_ms)
        {
            try
            {
                timer = new DispatcherTimer();

                timer.Interval = TimeSpan.FromMilliseconds(interval_ms);
                timer.Tick += new EventHandler(timer_tick);

                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool init_camera()
        {
            try
            {
                cam = new VideoCapture(0);
                cam.FrameHeight = 300;
                cam.FrameWidth = 500;

                // 카메라 영상을 담을 Mat 변수 생성
                frame = new Mat();

                return true;
            }
            catch
            {
                return false;
            }
        }

        private void timer_tick(object sender, EventArgs e)
        {
            // 0번 장비로 생성된 VideoCapture 객체에서 frame을 읽어옴
            cam.Read(frame);
            // 읽어온 Mat 데이터를 Bitmap 데이터로 변경 후 컨트롤에 그려줌
            Cam_1.Source = OpenCvSharp.WpfExtensions.WriteableBitmapConverter.ToWriteableBitmap(frame);
        }

        public void Capture()
        {
            try
            {
                // 이미지 저장 및 경로 설정
                string save_name = DateTime.Now.ToString("yyyy-MM-dd-hh시mm분ss초");
                string file_path = $"C:\\Users\\jhlee\\OneDrive\\사진\\카메라 앨범\\{save_name}.jpg";

                // 이미지 저장
                Cv2.ImWrite(file_path, frame);
                MessageBox.Show("이미지가 저장되었습니다: " + file_path, "저장 완료");

                // 이미지 읽기
                Mat src = Cv2.ImRead(file_path);

                // Mat을 WriteableBitmap으로 변환
                writableBitmap = OpenCvSharp.WpfExtensions.WriteableBitmapConverter.ToWriteableBitmap(src);
            }
            catch (Exception ex)
            {
                MessageBox.Show("이미지 저장 중 오류가 발생했습니다: " + ex.Message, "오류", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}