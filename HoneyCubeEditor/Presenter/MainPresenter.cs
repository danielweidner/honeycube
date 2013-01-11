#region Using Statements

using HoneyCube.Editor.Events;
using HoneyCube.Editor.Views;

#endregion

namespace HoneyCube.Editor.Presenter
{
    /// <summary>
    /// The MainPresenter is controlling the main window of the application.
    /// Most of the time it will delegate the commands to its subviews.
    /// </summary>
    public class MainPresenter : IPresenter<MainView, object>
    {
        #region Fields

        private IApplicationController _appController;

        private MainView _view;
        private object _model;

        #endregion

        #region Properties

        /// <summary>
        /// The view of the main window of the application.
        /// </summary>
        public MainView View
        {
            get { return _view; }
        }

        /// <summary>
        /// Some user settings that allow to customize the application.
        /// </summary>
        public object Model
        {
            get { return _model; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Public constructor. Creates a presenter for the main view.
        /// </summary>
        public MainPresenter(IApplicationController appController, MainView view, object model)
        {
            _appController = appController;

            _view = view;
            _view.Presenter = this;
            _model = model;
        }

        #endregion

        /// <summary>
        /// Is called every time the user prompts to close the application 
        /// window.
        /// </summary>
        public void CloseRequested()
        {
            _appController.Raise(new ApplicationClosingEvent());
        }
    }
}
