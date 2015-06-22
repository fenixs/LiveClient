using LiveClient.Utility;
using MahApps.Metro.Controls;
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
using System.Windows.Shapes;

namespace LiveClient.Views
{
    /// <summary>
    /// CaptureScreenWindow.xaml 的交互逻辑
    /// </summary>
    public partial class CaptureScreenWindow : MetroWindow
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fullScreenBitmap">当前屏幕的截图</param>
        public CaptureScreenWindow(WriteableBitmap fullScreenBitmap)
        {
            InitializeComponent();
            //Mahapp.Metro的bug，必须在这里设置AllowTransparency才有效
            this.AllowsTransparency = true;
            this.Width = PubModel.__ScreenWidth;
            this.Height = PubModel.__ScreenHeight;
            canMain.Width = PubModel.__ScreenWidth;
            canMain.Height = PubModel.__ScreenHeight;
            this.KeyDown += CaptureScreenWindow_KeyDown;
            //this.Opacity = 0.2;

            this.imgFullScreen.Width = PubModel.__ScreenWidth;
            this.imgFullScreen.Height = PubModel.__ScreenHeight;
            this.imgFullScreen.Source = fullScreenBitmap;       //Add FullScrrenImage to the Image Control

            this.MouseLeftButtonDown += CaptureScreenWindow_MouseLeftButtonDown;
            this.MouseMove += CaptureScreenWindow_MouseMove;
            this.MouseLeftButtonUp += CaptureScreenWindow_MouseLeftButtonUp;

            
        }

        #region "拖拽截屏"
        /// <summary>
        /// 标识鼠标是否处于按住状态
        /// </summary>
        bool _mousePressed = false;
        /// <summary>
        /// 标识鼠标是否移动
        /// </summary>
        bool _mouseMoved = false;
        Canvas canvasImage;
        /// <summary>
        /// 鼠标按下的起始点
        /// </summary>
        Point _pOrgin;
        void CaptureScreenWindow_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (_mousePressed)
            {
                _mousePressed = false;
                if(_mouseMoved)
                {
                    _mouseMoved = false;
                    (sender as UIElement).ReleaseMouseCapture();
                    Point p = e.GetPosition(canMain);
                    double width = Math.Abs(p.X - _pOrgin.X);
                    double height = Math.Abs(p.Y - _pOrgin.Y);
                    canvasImage.SetValue(Canvas.WidthProperty, width);
                    canvasImage.SetValue(Canvas.HeightProperty, height);
                }
            }
        }
        /// <summary>
        /// 根据鼠标移动的方向描绘选择框，并且显示大小,保证不出控件范围
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void CaptureScreenWindow_MouseMove(object sender, MouseEventArgs e)
        {
            if (_mousePressed)
            {
                _mouseMoved = true;
                Point p = e.GetPosition(canMain);

                if (p.X < _pOrgin.X)
                {
                    
                    canvasImage.SetValue(Canvas.LeftProperty, p.X);
                    canvasImage.SetValue(Canvas.WidthProperty, _pOrgin.X - p.X);
                }
                else
                {
                    //if (p.X > LayoutRoot.ActualWidth)
                    //    p.X = LayoutRoot.ActualWidth;
                    canvasImage.SetValue(Canvas.WidthProperty, p.X - _pOrgin.X);
                }
                if (p.Y < _pOrgin.Y)
                {
                    
                    canvasImage.SetValue(Canvas.TopProperty, p.Y);
                    canvasImage.SetValue(Canvas.HeightProperty, _pOrgin.Y - p.Y);
                }
                else
                {
                    //if (p.Y > LayoutRoot.ActualHeight)
                    //    p.Y = LayoutRoot.ActualHeight;
                    canvasImage.SetValue(Canvas.HeightProperty, p.Y - _pOrgin.Y);
                }
            }
        }

        void CaptureScreenWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (canvasImage != null)
            {
                canMain.Children.Remove(canvasImage);
                canMain.Clip = null;
                canvasImage = null;
            }
            (sender as UIElement).CaptureMouse();
            _mousePressed = true;
            _pOrgin = e.GetPosition(canMain);
            canvasImage = new Canvas();
            canMain.Children.Add(canvasImage);
            canvasImage.SetValue(Canvas.TopProperty, _pOrgin.Y);
            canvasImage.SetValue(Canvas.BackgroundProperty, new SolidColorBrush(Color.FromArgb(127, 255, 255, 255)));
            canvasImage.SetValue(Canvas.LeftProperty, _pOrgin.X);

        }
        #endregion


        void CaptureScreenWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
                
            }
        }

        /// <summary>
        /// 初始化全屏大小的窗体
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public CaptureScreenWindow(int width, int height)
        {
            InitializeComponent();
            this.Width = width;
            this.Height = height;
        }
    }
}
