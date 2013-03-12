#region Using Statements

using System.Windows.Forms;
using HoneyCube.Editor.Views;

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

        private IAppHub _hub;
        private IAppMenu _view;

        #endregion

        #region Properties

        /// <summary>
        /// Holds the associated menu view.
        /// </summary>
        public IAppMenu View
        {
            get { return _view; }
        }

        /// <summary>
        /// The application hub bundles core functionality for better decoupling.
        /// </summary>
        public IAppHub Hub
        {
            get { return _hub; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Public constructor. A MenuCommandExecuter reacts to click events of 
        /// a menu view and runs associated commands.
        /// </summary>
        /// <param name="hub">The application hub bundling core functionality.</param>
        /// <param name="view">The menu controlled by the current presenter.</param>
        public MenuCommandExecuter(IAppHub hub, IAppMenu view)
        {
            _hub = hub;
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
            // Expects every MenuItem to define which kind of command to 
            // execute via the tag property.
            string command = item.Tag as string;
            if (command != null)
                _hub.Execute(command);
        }

        #endregion
    }
}
