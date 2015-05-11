/*
 * 后台运行界面
 * */
using LiveClient.Utility;
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

namespace LiveClient
{
    /// <summary>
    /// BackgroundWindow.xaml 的交互逻辑
    /// </summary>
    public partial class BackgroundWindow : Window
    {
        public BackgroundWindow()
        {
            InitializeComponent();
            this.Loaded += BackgroundWindow_Loaded;
        }

        /// <summary>
        /// 启动时候隐藏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void BackgroundWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.Hide();
            var ni = NotifyIconHelper.Instance;
            NotifyIconHelper.Instance.ShowBalloonTip("提示", "程序开始运行");            
        }

        public static void ExitApp()
        {
            App.Current.Dispatcher.Invoke(new Action(
                delegate
                {
                    NotifyIconHelper.Instance.Hide();
                    App.Current.Shutdown();
                }
                ),null);
        }
    }
}
