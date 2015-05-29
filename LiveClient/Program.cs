using Microsoft.Shell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace LiveClient
{
    /// <summary>
    /// 启动类
    /// </summary>
    public class Program
    {

        private const int MAXTRIES = 10;

        static Program()
        {
            //调用打包的dll
            AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
                {
                    var resourceName = Assembly.GetExecutingAssembly().GetName().Name + ".DllAsResources." + new AssemblyName(args.Name).Name + ".dll";
                    using(var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
                    {
                        if(stream!=null)
                        {
                            var assemblyData = new Byte[stream.Length];
                            stream.Read(assemblyData, 0, assemblyData.Length);
                            return Assembly.Load(assemblyData);
                        }
                    }
                    return null;                    
                };
        }

        [STAThread]
        public static void Main()
        {
            StartUp();
        }

        /// <summary>
        /// 单任务启动
        /// </summary>
        private static void StartUp()
        {
            var isFirstInstance = false;

            for (var i = 1; i < MAXTRIES; i++)
            {
                try
                {
                    isFirstInstance = SingleInstance<App>.InitializeAsFirstInstance("18982329-1442-4867-bc3d-37b0d67fa938");
                    break;
                }
                catch(RemotingException)
                {
                    break;
                }
                catch(Exception)
                {
                    if(i==MAXTRIES)
                    {
                        return;
                    }
                }
            }

            if(isFirstInstance)
            {
                var Application = new App();
                Application.InitializeComponent();
                Application.Run();

                // Allow single instance code to perform cleanup operations
                SingleInstance<App>.Cleanup();
            }
        }
    }
}
