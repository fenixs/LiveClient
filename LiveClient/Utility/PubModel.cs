/*
 * PubModel.cs
 * 系统运行公共变量
 * 20150511went
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveClient.Utility
{
    class PubModel
    {
        #region "系统运行相关"
        /// <summary>
        /// 程序名
        /// "WTTasks"
        /// </summary>
        public const string __APPNAME = "LiveClient";

        /// <summary>
        /// 主窗口是否打开
        /// </summary>
        public static bool __IsMainWindow { get; set; }

        /// <summary>
        /// 程序主路径
        /// </summary>
        public static string __StartupPath { get; set; }

        /// <summary>
        /// config.xml文件路径
        /// </summary>
        public static string __Config { get; set; }

        /// <summary>
        /// 当前系统是32位还是64位
        /// </summary>
        //public static int __OSType { get; set; }
        #endregion
    }
}
