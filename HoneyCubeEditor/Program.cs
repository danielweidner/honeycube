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
    /// - Improved the CommandMap and introduced a new interface similar to 
    ///   StructureMaps registry (to avoid hacky XML Configuration)
    /// - Added documentation for all command classes
    /// - Introduced StructureMap as Dependency Injection framework
    /// 
    /// Next steps:
    /// - Implement DefaultCommandMap
    /// - Handle Key Combinations and delegate them to the CommandMap
    /// - Add functionality to the hub to run commands via identifier
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
