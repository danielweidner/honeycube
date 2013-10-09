#region Using Statements

using System.Windows.Forms;
using HoneyCube.Editor.Views;
using HoneyCube.Editor.Commands;

#endregion

namespace HoneyCube.Editor.Presenter
{
    /// <summary>
    /// The ToolbarCommandExecuter is an implementation of the 
    /// IAppToolbarPresenter interface. It will retrieve click events from the
    /// menu view and run associated commands.
    /// </summary>
    public class ToolbarCommandExecuter : IAppToolbarPresenter
    {
        #region Fields

        private ICommandMap _map;
        private IAppToolbar _view;

        #endregion

        #region Properties

        /// <summary>
        /// Returns the associated toolbar view.
        /// </summary>
        public IAppToolbar View
        {
            get { return _view; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Public constructor. A ToolbarCommandExecuter reacts to click events
        /// of a menu view and runs associated commands.
        /// </summary>
        /// <param name="map">A command map that associates string identifiers or key shortcuts to specific commands.</param>
        /// <param name="view">The menu controlled by the current presenter.</param>
        public ToolbarCommandExecuter(ICommandMap map, IAppToolbar view)
        {
            _map = map;
            _view = view;
            _view.Presenter = this;
        }

        #endregion

        #region IAppToolbarPresenter

        /// <summary>
        /// Should be called everytime a toolbar item on the associated view is
        /// clicked.
        /// </summary>
        /// <param name="item">The toolstrip item clicked.</param>
        public void HandleItemClicked(ToolStripItem item)
        {
            _map.TryToExecute(item.Name);
        }

        #endregion
    }
}
