#region Using Statements

using System.Windows.Forms;
using HoneyCube.Editor.Views;
using HoneyCube.Editor.Commands;
using HoneyCube.Editor.Events;
using HoneyCube.Editor.Events.Project;

#endregion

namespace HoneyCube.Editor.Presenter
{
    /// <summary>
    /// The AppMenuPresenter is an implementation of the IAppMenuPresenter 
    /// interface. It will retrieve click events from the menu view and run
    /// associated commands from the default command map.
    /// </summary>
    public class AppMenuPresenter : IAppMenuPresenter, IEventHandler<ProjectCreatedEvent>, IEventHandler<ProjectClosedEvent>
    {
        #region Fields

        /// <summary>
        /// A collection of menu item names that are only available if a 
        /// project is created.
        /// </summary>
        private static string[] _projectRelatedMenuItems = new string[] { 
            "MenuProject", 
            "MenuFileCloseProject" 
        };

        private ICommandMap _map;
        private IAppMenu _view;

        #endregion

        #region Properties

        /// <summary>
        /// Returns the associated menu view.
        /// </summary>
        public IAppMenu View
        {
            get { return _view; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Public constructor. A MenuCommandExecuter reacts to click events of 
        /// a menu view and runs associated commands.
        /// </summary>
        /// <param name="map">A command map that associates string identifiers or key shortcuts to specific commands.</param>
        /// <param name="view">The menu controlled by the current presenter.</param>
        public AppMenuPresenter(ICommandMap map, IAppMenu view)
        {
            _map = map;
            _view = view;
            _view.Presenter = this;
        }

        #endregion

        #region IApplicationMenuPresenter

        /// <summary>
        /// Should be called everytime a menu item on the associated view 
        /// is clicked.
        /// </summary>
        /// <param name="item">The menu item clicked.</param>
        public void HandleMenuItemClicked(ToolStripMenuItem item)
        {
            if (item.ShortcutKeys != Keys.None)
                _map.TryToExecute(item.ShortcutKeys);
            else
                _map.TryToExecute(item.Name);
        }

        #endregion

        #region Event Handler

        /// <summary>
        /// Is raised when a new project is created by the user.
        /// </summary>
        /// <param name="args">Some event arguments.</param>
        public void HandleApplicationEvent(ProjectCreatedEvent args)
        {
            foreach(string item in _projectRelatedMenuItems)
                _view.EnableItem(item);
        }

        /// <summary>
        /// Is raised when the current project is closed by the user.
        /// </summary>
        /// <param name="args">Some event arguments.</param>
        public void HandleApplicationEvent(ProjectClosedEvent args)
        {
            foreach (string item in _projectRelatedMenuItems)
                _view.EnableItem(item);
        }

        #endregion
    }
}
