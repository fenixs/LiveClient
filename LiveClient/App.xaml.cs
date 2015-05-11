using LiveClient.Utility;
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
    public partial class App : Application
    {
        /// <summary>
        /// 单实例运行
        /// </summary>
        Mutex _mutex;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            bool startUpFlag = false;

            _mutex = new Mutex(true, PubModel.__APPNAME, out startUpFlag);
            if(!startUpFlag)
            {
                if(!PubModel.__IsMainWindow)
                {
                    PubModel.__IsMainWindow = true;
                    //TODO:激活已经运行实例
                }
                MessageBox.Show("程序已经运行");
                Environment.Exit(0);
            }
            else
            {
                OnInit();
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
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

    }
}
