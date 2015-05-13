/*
 * Login.xaml
 * 登录界面
 * 20150512went
 * 
 * */
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

namespace LiveClient
{
    /// <summary>
    /// Login.xaml 的交互逻辑
    /// </summary>
    public partial class Login : MetroWindow
    {
        public Login()
        {
            InitializeComponent();
            this.btnLogin.Click += btnLogin_Click;
            this.btnAnchor.Click += btnAnchor_Click;
            this.Loaded += Login_Loaded;
            
        }

        void Login_Loaded(object sender, RoutedEventArgs e)
        {
           
        }

        void btnAnchor_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.baidu.com");
        }

        void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            //TODO:暂时直接跳转，具体登录逻辑出来后再修改
            DirectToMainWindow();
        }

        void DirectToMainWindow()
        {
            this.Hide();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            BackgroundWindow bgWindow = new BackgroundWindow();
            bgWindow.Show();
            
        }
    }
}
