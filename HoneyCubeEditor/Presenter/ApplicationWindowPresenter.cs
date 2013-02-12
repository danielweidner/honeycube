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

        private IApplicationController _appController;
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
        public ApplicationWindowPresenter(IApplicationController appController, IApplication view)
        {
            _appController = appController;
            _view = view;
            _view.Presenter = this;
        }

        #endregion

        #region IEditorPresenter Members

        /// <summary>
        /// Is called everytime the corresponding UI element to show/hide the
        /// sidebar is clicked.
        /// </summary>
        public void ShowHideSidebarClicked()
        {
            // Hide the sidebar if it is currently visible
            if (View.IsSidebarVisible)
            {
                View.HideSidebar();
            }
            // Show the sidebar if at least one of its subpanels are visible
            else if (View.IsProjectTreeVisible || View.IsInspectorVisible)
            {
                View.ShowSidebar();
            }
            // Enable all subpanels first if the user wants to show the 
            // sidebar but actually has disabled all subpanels
            else
            {
                View.ShowProjectTree();
                View.ShowInspector();
                View.ShowSidebar();
            }
        }

        /// <summary>
        /// Is called everytime the corresponding UI element to show/hide the
        /// project tree view is clicked.
        /// </summary>
        public void ShowHideProjectClicked()
        {
            // Toggle the project tree panel visibility
            if (View.IsProjectTreeVisible)
            {
                View.HideProjectTree();
            }
            else
            {
                View.ShowProjectTree();
            }

            // Hide the entire sidebar if both panels (inspector & project tree)
            // are currently disabled
            if (!View.IsProjectTreeVisible && !View.IsInspectorVisible)
            {
                View.HideSidebar();
            }
        }

        /// <summary>
        /// Is called everytime the corresponding UI element to show/hide the 
        /// inspector is clicked.
        /// </summary>
        public void ShowHideInspectorClicked()
        {
            // Toogle the inspector panel visibility
            if (View.IsInspectorVisible)
            {
                View.HideInspector();
            }
            else
            {
                View.ShowInspector();
            }

            // Hide the entire sidebar if both panels (inspector & project tree)
            // are currently disabled
            if (!View.IsProjectTreeVisible && !View.IsInspectorVisible)
            {
                View.HideSidebar();
            }
        }

        /// <summary>
        /// Is called every time the user prompts to close the application 
        /// window.
        /// </summary>
        public void CloseRequested()
        {
            _appController.Raise(new ApplicationClosingEvent());
        }

        #endregion
    }
}
