#region Using Statements

using System.Windows.Forms;
using HoneyCube.Editor.Views;
using HoneyCube.Editor.Commands;

#endregion

namespace HoneyCube.Editor.Presenter
{
    /// <summary>
    /// The MenuCommandExecuter is an implementation of the IAppMenuPresenter 
    /// interface. It will retrieve click events from the menu view and run
    /// associated commands.
    /// </summary>
    public class MenuCommandExecuter : IAppMenuPresenter
    {
        #region Fields

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
        public MenuCommandExecuter(ICommandMap map, IAppMenu view)
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
    }
}
