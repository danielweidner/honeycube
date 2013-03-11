#region Using Statements

using HoneyCube.Editor.Events;
using HoneyCube.Editor.Views;

#endregion

namespace HoneyCube.Editor.Presenter
{
    /// <summary>
    /// The EditorPresenter is controlling the main window of the application.
    /// Most of the time it will delegate the commands to its subviews.
    /// </summary>
    public class ApplicationWindowPresenter : IApplicationPresenter
    {
        #region Fields

        private IApplicationController _app;
        private IApplication _view;

        #endregion

        #region Properties

        /// <summary>
        /// The view holding most of the editors controls.
        /// </summary>
        public IApplication View
        {
            get { return _view; }
            set 
            { 
                _view = value;
                _view.Presenter = this;
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Public constructor. Creates a presenter for the editor view.
        /// </summary>
        public ApplicationWindowPresenter(IApplicationController app, IApplication view)
        {
            _app = app;
            _view = view;
            _view.Presenter = this;
        }

        #endregion

        #region IApplicationPresenter Members

        /// <summary>
        /// Is called every time the user prompts to close the application 
        /// window.
        /// </summary>
        public void CloseRequested()
        {
            _app.Raise(new ApplicationClosingEvent());
        }

        #endregion
    }
}
