#region Using Statements

using System;
using System.Windows.Forms;
using HoneyCube.Editor.Commands;
using HoneyCube.Editor.Events;
using HoneyCube.Editor.Presenter;
using HoneyCube.Editor.Services;
using HoneyCube.Editor.Views;
using StructureMap.Configuration.DSL;
using HoneyCube.Editor.Input;

#endregion

namespace HoneyCube.Editor
{
    /// <summary>
    /// The DefaultRegistry contains all methods and grammars to configurate the 
    /// StructureMap container.
    /// </summary>
    public class DefaultRegistry : Registry
    {
        /// <summary>
        /// Public constructor. Creates the default registry used to setup the
        /// IoC container.
        /// </summary>
        public DefaultRegistry()
        {
            #region Core Modules

            For<ApplicationContext>()
                .Singleton()
                .Use<AppContext>();

            For<IMouseEventPublisher>()
                .Singleton()
                .Use<MouseMessageFilter>();

            For<IAppHub>()
                .Singleton()
                .Use<AppHub>();

            For<ICommandMap>()
                .Singleton()
                .Use<DefaultCommandMap>();

            For<IEventPublisher>()
                .Singleton()
                .Use<EventPublisher>();

            For<ICommandHistory<IUndoableCommand>>()
                .Singleton()
                .Use(() => new CommandHistory());

            #endregion

            #region Services

            For<IProjectManager>()
                .Singleton()
                .Use<ProjectManager>();

            #endregion

            #region Presenter Implementations

            For<IAppWindowPresenter>()
                .Singleton()
                .Use<AppWindowPresenter>();

            For<IAppMenuPresenter>()
                .Singleton()
                .Use<AppMenuPresenter>();

            For<IAppToolbarPresenter>()
                .Singleton()
                .Use<AppToolbarPresenter>();

            For<IInspectorPresenter>()
                .Singleton()
                .Use<InspectorPresenter>();

            For<IProjectTreePresenter>()
                .Singleton()
                .Use<ProjectTreePresenter>();

            For<IAppLogPresenter>()
                .Singleton()
                .Use<AppLogPresenter>();

            For<ISceneViewPresenter>()
                .Use<SceneViewPresenter>();
            
            #endregion

            #region View Implementations

            For<IAppWindow>()
                .Singleton()
                .Use<AppWindow>();

            For<IAppMenu>()
                .Singleton()
                .Use<AppMenu>();

            For<IAppToolbar>()
                .Singleton()
                .Use<AppToolbar>();

            For<IObjectInspector>()
                .Singleton()
                .Use<ObjectInspector>();

            For<IProjectTree>()
                .Singleton()
                .Use<ProjectTree>();

            For<ISceneView>()
                .Use<SceneView>();

            For<IAppLogWindow>()
                .Singleton()
                .Use<AppLogWindow>();

            For<SaveFileDialog>()
                .Singleton();

            #endregion

            #region Dialogs

            For<IInputDialog>().Use<InputDialog>().Named("CreateProjectDialog")
                .Ctor<string>("title").Is("Create Project...")
                .Ctor<string>("heading").Is("Create Project")
                .Ctor<string>("description").Is("Please enter a name for the project.");

            #endregion

            #region Models

            SelectConstructor<Scene>(() => new Scene());

            For<IScene>()
                .Use<Scene>();

            #endregion
        }
    }
}
