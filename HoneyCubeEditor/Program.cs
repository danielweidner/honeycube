#region Using Statements

using System;
using System.Windows.Forms;
using StructureMap;

#endregion

namespace HoneyCube.Editor
{
    /// <summary>
    /// PROJECT NOTES: ----------------------------------------------------
    /// 
    /// Last steps:
    /// - Introduced StructureMap as Dependency Injection framework
    /// - Improved documentation and class naming
    /// 
    /// Next steps:
    /// - Update command documentation
    ///   
    /// -------------------------------------------------------------------
    /// </summary>
    static class Program
    {
        /// <summary>
        /// Main Entry Point of the Application
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Setup the application styles
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Setup IoC Container
            Container ioc = new Container();
            BootStrapper bootStrapper = new BootStrapper(ioc);
            ApplicationContext context = bootStrapper.GetAppContext();
            
            // Run the application
            Application.Run(context);
        }
    }
}
