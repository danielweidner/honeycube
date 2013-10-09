#region Using Statements

using System;
using System.Windows.Forms;
using HoneyCube.Editor.Commands;
using HoneyCube.Editor.Presenter;
using HoneyCube.Editor.Services;
using HoneyCube.Editor.Views;
using System.Diagnostics;

#endregion

namespace HoneyCube.Editor
{
    /// <summary>
    /// The DefaultCommandMap contains all methods to bind certain commands to 
    /// a set of identifiers or key combinations.
    /// </summary>
    public class DefaultCommandMap : CommandMap
    {
        /// <summary>
        /// Public constructor. Creates a default set of commands that can be
        /// triggered throughout the entire application.
        /// </summary>
        /// <param name="window">The application window maintaining most of the control elements.</param>
        /// <param name="appLog">The logging element.</param>
        public DefaultCommandMap(IAppWindow window, IAppLogPresenter appLog)
        {
            #region Menu: File

            // MenuFileExit
            If(Keys.Control | Keys.Q)
                .ThenExecute(new ActionCommand(() => {
                    window.Presenter.CloseRequested();
                }));

            #endregion

            #region Menu: View

            If("ToolbarLog").Or(Keys.Control | Keys.L)
                .ThenExecute(new ActionCommand(appLog.ShowClicked));

            If("MenuViewWelcomePage")
                .ThenExecute(new ActionCommand(window.ShowWelcomePage));

            If("MenuViewSidebarSidebar")
                .ThenExecute(new ActionCommand(window.ToggleSidebar));

            If("MenuViewSidebarProjectTree")
                .ThenExecute(new ActionCommand(window.ToggleProjectTree));

            If("MenuViewSidebarInspector")
                .ThenExecute(new ActionCommand(window.ToggleInspector));            

            #endregion

            #region Menu: Help

            If("MenuHelpGithub")
                .ThenExecute(new ActionCommand(() => {
                    Process.Start(L10n.LookUpLocalizedString("GithubUrl"));
                }));

            #endregion
        }
    }
}
