using LiveClient.ViewModels;
using LiveClient.Views;
using MahApps.Metro;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
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
using System.Windows.Threading;

namespace LiveClient
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : MetroWindow
    {

        MainViewModel mainViewModel = new MainViewModel();

        public MainWindow()
        {
            InitializeComponent();
            this.Closing += MainWindow_Closing;
            this.DataContext = mainViewModel;
            this.btnVolume.Click += btnVolume_Click;
            this.btnStart.Click += btnStart_Click;
            this.btnAddGame.Click += btnAddGame_Click;
            this.btnAddScreen.Click += btnAddScreen_Click;
            _timer.Tick += _timer_Tick;
            _timer.Interval = new TimeSpan(40);
            this.MouseMove += MainWindow_MouseMove;
        }

        

        void MainWindow_MouseMove(object sender, MouseEventArgs e)
        {
            System.Windows.Point p = PointToScreen(e.GetPosition(this));
            tbMouseInfo.Text = string.Format("{0},{1}",p.X,p.Y);
            
        }


        #region "Button Click Events"
        #region "播放部分"
        /// <summary>
        /// 播放时候的timer
        /// </summary>
        DispatcherTimer _timer = new DispatcherTimer();

        /// <summary>
        /// timer中绘制屏幕截图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void _timer_Tick(object sender, EventArgs e)
        {            
            DrawBitmap();

        }

        /// <summary>
        /// 显示的屏幕截图bitmap源
        /// </summary>
        private WriteableBitmap _bitmap = null;

        /// <summary>
        /// 截取屏幕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnAddScreen_Click(object sender, RoutedEventArgs e)
        {
            //测试左上角400*300的播放
            bdImg.Visibility = System.Windows.Visibility.Visible;
            //初始化bitmap
            //暂时为400*300
            this._bitmap = new WriteableBitmap(400, 300, 96, 96, PixelFormats.Rgb24, null);
            imgMain.Source = _bitmap;
            imgMain.RenderTransform = SizeScale(0.5, 0.5);
            _timer.Start();
        }
        /// <summary>
        /// 截取当前屏幕绘制到bitmap，显示到image中
        /// </summary>
        private void DrawBitmap()
        {
            /*
             * 使用writeablebitmap的双缓冲机制绘制当前屏幕对应位置截图到缓冲中
             * */
            this._bitmap.Lock();
            //截图到缓冲区
            using (Bitmap backBufferBitmap = new Bitmap(400, 300, this._bitmap.BackBufferStride,
                System.Drawing.Imaging.PixelFormat.Format24bppRgb, this._bitmap.BackBuffer))
            {
                using (Graphics g = Graphics.FromImage(backBufferBitmap))
                {                    
                    g.CopyFromScreen(new System.Drawing.Point(0, 0), new System.Drawing.Point(0, 0), new System.Drawing.Size(400, 300));
                    g.Flush();                    
                }
            }
            //推送到显示区域
            this._bitmap.AddDirtyRect(new Int32Rect(0, 0, 400, 300));
            this._bitmap.Unlock();
            
        }

        /// <summary>
        /// 显示区域大大小转换
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private ScaleTransform SizeScale(double x, double y)
        {
            ScaleTransform scale = new ScaleTransform();
            scale.CenterX = 0;
            scale.CenterY = 0;
            scale.ScaleX = x;
            scale.ScaleY = y;
            return scale;
        }
     
        /// <summary>
        /// 删除当前截取的屏幕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdImgMenu_Click(object sender, RoutedEventArgs e)
        {
            _timer.Stop();
            imgMain.Source = null;
            bdImg.Visibility = System.Windows.Visibility.Collapsed;
        }

        #endregion

        

        /// <summary>
        /// 添加游戏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnAddGame_Click(object sender, RoutedEventArgs e)
        {
            SelectProcess sp = new SelectProcess();
            sp.Owner = this;
            sp.ShowDialog();
        }

        /// <summary>
        /// 开始直播/结束直播
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnStart_Click(object sender, RoutedEventArgs e)
        {
            if (mainViewModel.State == Utility.PlayerState.Stop)
            {
                mainViewModel.State = Utility.PlayerState.Play;
                //TODO:开始直播
            }
            else if (mainViewModel.State == Utility.PlayerState.Play)
            {
                mainViewModel.State = Utility.PlayerState.Stop;
                //TODO:结束直播
            }
        }


        /// <summary>
        /// 音量/静音
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnVolume_Click(object sender, RoutedEventArgs e)
        {
            mainViewModel.IsMute = !mainViewModel.IsMute;
        }

        #endregion
        

        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            BackgroundWindow.ExitApp();
        }


        #region "菜单事件"
        /// <summary>
        /// 菜单事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menu = sender as MenuItem;
            if (menu != null)
            {
                string param = menu.CommandParameter.ToString();
                switch (param)
                {
                    case "exit":
                        {
                            BackgroundWindow.ExitApp();
                            break;
                        }
                    case "config":
                        {
                            break;
                        }
                    case "help":
                        {
                            System.Diagnostics.Process.Start("http://www.baidu.com");
                            break;
                        }
                    case "feedback":
                        {
                            System.Diagnostics.Process.Start("http://www.baidu.com");
                            break;
                        }
                    case "update":
                        {
                            System.Diagnostics.Process.Start("http://www.baidu.com");
                            break;
                        }
                }
            }
        }
        #endregion

        

    }
}
