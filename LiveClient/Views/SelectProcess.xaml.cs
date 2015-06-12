using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// SelectProcess.xaml 的交互逻辑
    /// </summary>
    public partial class SelectProcess : MetroWindow
    {
        public SelectProcess()
        {
            InitializeComponent();
            this.btnCancel.Click += btnCancel_Click;
            this.btnOK.Click +=btnOK_Click;
            this.Loaded += SelectProcess_Loaded;
            
        }

        /// <summary>
        /// 页面Loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void SelectProcess_Loaded(object sender, RoutedEventArgs e)
        {
            //Load Process
            Process[] processes;
            processes = Process.GetProcesses();
            this.cbGames.DisplayMemberPath = "ProcessName";
            this.cbGames.ItemsSource = processes;
        }

        void btnOK_Click(object sender, RoutedEventArgs e)
        {
 	        
        }

        void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        
    }
}
