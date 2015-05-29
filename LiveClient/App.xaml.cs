using LiveClient.Utility;
using Microsoft.Shell;
using SimpleMusicPlayer.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace LiveClient
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application,ISingleInstanceApp
    {
        

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            

            
           
            {
                OnInit();
                Login login = new Login();
                login.Show();
                //MainWindow mainWindow = new MainWindow();
                //mainWindow.Show();
            }
        }


        /// <summary>
        /// 系统初始化
        /// </summary>
        private void OnInit()
        {
            //TODO:
            PubModel.__StartupPath = System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            this.DispatcherUnhandledException += App_DispatcherUnhandledException;
        }

        /// <summary>
        /// 系统异常处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            //TODO:写log文件
            MessageBox.Show(e.Exception.Message);
            e.Handled = true;
        }

        /// <summary>
        /// 系统退出前调用
        /// </summary>
        /// <param name="e"></param>
        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
        }


        /// <summary>
        /// 已经有实例运行时候，新打开的操作
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public bool SignalExternalCommandLineArgs(IList<string> args)
        {
            if(this.MainWindow.WindowState == WindowState.Minimized)
            {
                WindowExtensions.Unminimize(this.MainWindow);       //最小化变成最大化
                
            }
            else
            {
                WindowExtensions.ShowAndActivate(this.MainWindow);  //后台时候激活窗口
            }
            return true;
        }
    }
}
