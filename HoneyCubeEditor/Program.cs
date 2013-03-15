#region Using Statements

using System;
using System.Windows.Forms;
using HoneyCube.Editor.Input;
using StructureMap;

#endregion

namespace HoneyCube.Editor
{
    /// <summary>
    /// PROJECT NOTES: ----------------------------------------------------
    /// 
    /// Last steps:
    /// - Implemented an Application Log
    /// - The CommandMap now can handle the Shortcut enumeration as argument
    /// - Delegated keyboard input to the CommandMap
    /// 
    /// Next steps:
    /// - Write Documentation for AppLog and its Presenter
    /// - Refactor the AppLogPresenter
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
