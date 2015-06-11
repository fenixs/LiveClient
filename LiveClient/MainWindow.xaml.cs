using LiveClient.ViewModels;
using MahApps.Metro;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

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
                            break;
                        }
                    case "feedback":
                        {
                            break;
                        }
                    case "update":
                        {
                            break;
                        }
                }
            }
        }
        #endregion
        

    }
}
