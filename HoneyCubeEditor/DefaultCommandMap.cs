#region Using Statements

using System;
using System.Windows.Forms;
using HoneyCube.Editor.Commands;
using HoneyCube.Editor.Presenter;
using HoneyCube.Editor.Services;
using HoneyCube.Editor.Views;
using System.Diagnostics;
using StructureMap;

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
        /// <param name="container">Container implementing the service locator pattern.</param>
        public DefaultCommandMap(IContainer container)
        {
            // TODO: Not very clean, as it hides dependencies, don't know how 
            // to include dialogs using constructor injection though. Maybe a
            // DialogService? Or creating actual commands with proper 
            // dependencies?
            IAppWindow window = container.GetInstance<IAppWindow>();
            IAppLogPresenter log = container.GetInstance<IAppLogPresenter>();
            IProjectManager project = container.GetInstance<IProjectManager>();

            #region Menu: File

            IInputDialog createProjectDialog = container.GetInstance<IInputDialog>("CreateProjectDialog");

            // MenuFileNewProject
            If(Keys.Control | Keys.N).Or("ToolbarNewProject")
                .ThenExecute(new ActionCommand(() => {
                    DialogResult result = createProjectDialog.ShowDialog();
                    
                    string projectName = createProjectDialog.UserInput;
                    if (result == DialogResult.OK && projectName != string.Empty)
                        project.CreateProject(projectName);
                }));

            // MenuFileCloseProject
            If("MenuFileCloseProject")
                .ThenExecute(new ActionCommand(() => {
                    if (project.Loaded)
                        project.CloseProject();
                }));

            // MenuFileExit
            If(Keys.Control | Keys.Q)
                .ThenExecute(new ActionCommand(() => {
                    window.Presenter.CloseRequested();
                }));

            #endregion

            #region Menu: Project

            // MenuProjectAddScene
            If("MenuProjectAddScene")
                .ThenExecute(new ActionCommand(() => {
                    if (project.Loaded)
                        project.CreateScene();
                }));

            #endregion

            #region Menu: View

            If("ToolbarLog").Or(Keys.Control | Keys.L)
                .ThenExecute(new ActionCommand(log.ShowClicked));

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
