#region Using Statements

using HoneyCube.Editor.Events;
using HoneyCube.Editor.Views;

#endregion

namespace HoneyCube.Editor.Presenter
{
    /// <summary>
    /// The AppWindowPresenter is controlling the main window of the application.
    /// Most of the time it will simply delegate the commands to interested 
    /// submodules.
    /// </summary>
    public class AppWindowPresenter : IAppWindowPresenter
    {
        #region Fields

        private IAppHub _hub;
        private IAppWindow _view;

        #endregion

        #region Properties

        /// <summary>
        /// The view holding most of the editors controls.
        /// </summary>
        public IAppWindow View
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
        /// Public constructor. Creates a new ApplicationWindowPresenter which
        /// controls the overall behavior of the associated ApplicationWindowView.
        /// </summary>
        /// <param name="hub">A reference to the application hub.</param>
        /// <param name="view">The view to maintain.</param>
        public AppWindowPresenter(IAppHub hub, IAppWindow view)
        {
            _hub = hub;
            _view = view;
            _view.Presenter = this;
        }

        #endregion

        #region IAppWindowPresenter Members

        /// <summary>
        /// Is called every time the user prompts to close the application 
        /// window.
        /// </summary>
        public void CloseRequested()
        {
            _hub.Raise(new AppClosingEvent());
        }

        #endregion
    }
}
