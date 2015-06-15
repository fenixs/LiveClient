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
        public CaptureScreenWindow()
        {
            InitializeComponent();
            this.Width = System.Windows.SystemParameters.PrimaryScreenWidth;
            this.Height = System.Windows.SystemParameters.PrimaryScreenHeight;
            this.KeyDown += CaptureScreenWindow_KeyDown;
        }

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
