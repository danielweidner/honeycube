#region Using Statements

using System;
using System.Windows.Forms;
using HoneyCube.Editor.Commands;
using HoneyCube.Editor.Events;
using HoneyCube.Editor.Presenter;
using HoneyCube.Editor.Views;

#endregion

namespace HoneyCube.Editor
{
    /// <summary>
    /// PROJECT NOTES: ----------------------------------------------------
    /// 
    /// Last steps: 
    /// - Implemented generic interfaces for model-view-presenter.
    /// - Implemented a command system.
    /// - Implemented an event system for application wide use.
    /// 
    /// Next steps:
    /// - Create the actual control elements of the application
    /// - Integrate the actual business models / the engine classes
    /// 
    /// Think about:
    /// - Necessary user controls / views
    ///   
    /// -------------------------------------------------------------------
    /// </summary>
    static class Program
    {
        /// <summary>
        /// Main Entry Point of the Application
        /// 
        /// NOTE: The application setup might be rewritten later on using a 
        /// dependency injection container like StructureMap.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Setup the application styles
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Setup the application controller, the central communication
            // point of the application.
            EventPublisher eventPublisher = new EventPublisher();
            CommandHistory commandHistory = new CommandHistory();
            ApplicationController appController = new ApplicationController(eventPublisher, commandHistory);

            // Setup all application models, views and presenters
            ApplicationMenu applicationMenu = new ApplicationMenu();
            ApplicationWindow applicationWindow = new ApplicationWindow(applicationMenu);
            ApplicationMenuPresenter mainMenuPresenter = new ApplicationMenuPresenter(applicationMenu);
            ApplicationWindowPresenter editorPresenter = new ApplicationWindowPresenter(appController, applicationWindow);

            // Run the application
            Application.Run(applicationWindow);
        }
    }
}
