/*
 * 文件名:NotifyIconHelper.cs
 * 功能描述:托盘应用
 * 20150511Went
 * 
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace LiveClient.Utility
{
    /// <summary>
    /// 托盘应用
    /// </summary>
    public class NotifyIconHelper
    {
        /*
         * 托盘的菜单和事件
         * 
         * */

        #region "单例模式"

        private static NotifyIconHelper _Instance = null;
        private static object _lock = new object();

        private NotifyIconHelper()
        {
            SetupNotifyIconHelper();
        }

        ~NotifyIconHelper()
        {
            Dispose();
        }

        private void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public static NotifyIconHelper Instance
        {
            get
            {
                if(_Instance==null)
                {
                    lock(_lock)
                    {
                        _Instance = new NotifyIconHelper();
                    }
                }
                return _Instance;
            }
        }

        #endregion

        public static NotifyIcon _NotifyIcon = new NotifyIcon();

        /// <summary>
        /// 设置托盘的内容
        /// </summary>
        private void SetupNotifyIconHelper()
        {
            _NotifyIcon.Icon = LiveClient.Properties.Resources.LiveClient_Icon;     //设置图标
            _NotifyIcon.Text = "程序";
            //添加右键菜单
            _NotifyIcon.ContextMenuStrip = new ContextMenuStrip();

            ToolStripMenuItem closeMonitor = new ToolStripMenuItem("关闭显示器");
            closeMonitor.Click += closeMonitor_Click;

            ToolStripMenuItem helpInfo = new ToolStripMenuItem("使用教程");
            helpInfo.Click += helpInfo_Click;

            ToolStripMenuItem config = new ToolStripMenuItem("系统设置");
            config.Click += config_Click;

            ToolStripMenuItem exit = new ToolStripMenuItem("退出系统");
            exit.Click += exit_Click;

            _NotifyIcon.ContextMenuStrip.Items.Add(closeMonitor);
            _NotifyIcon.ContextMenuStrip.Items.Add(helpInfo);
            _NotifyIcon.ContextMenuStrip.Items.Add(config);
            _NotifyIcon.ContextMenuStrip.Items.Add(exit);

            

            _NotifyIcon.Visible = true;
        }

        void exit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要退出程序吗?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                BackgroundWindow.ExitApp();
                NotifyIconHelper.Instance.Hide();
            }
        }

        void config_Click(object sender, EventArgs e)
        {
            
        }

        void helpInfo_Click(object sender, EventArgs e)
        {
            
        }

        void closeMonitor_Click(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// 隐藏托盘图标
        /// </summary>
        public void Hide()
        {
            _NotifyIcon.Visible = false;
        }

        /// <summary>
        /// 启动托盘图标时候，显示的文字
        /// </summary>
        /// <param name="title"></param>
        /// <param name="text"></param>
        public void ShowBalloonTip(string title,string text)
        {
            if(string.IsNullOrEmpty(text))
            {
                return;
            }
            try
            {
                _NotifyIcon.BalloonTipText = text;
                _NotifyIcon.BalloonTipTitle = title;
                _NotifyIcon.BalloonTipIcon = ToolTipIcon.None;
                _NotifyIcon.ShowBalloonTip(1000);
            }
            catch
            {

            }
        }
    }
}
