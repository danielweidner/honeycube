#region Using Statements

using System.Windows.Forms;
using HoneyCube.Editor.Presenter;
using System.ComponentModel;

#endregion

namespace HoneyCube.Editor.Views
{
    /// <summary>
    /// The IAppWindow interface describes methods which control the overall
    /// appearance of the main application window.
    /// </summary>
    public interface IAppWindow : IView<IAppWindowPresenter>
    {
        /// <summary>
        /// The menu attached to the main application window.
        /// </summary>
        MenuStrip MainMenuStrip
        {
            get;
            set;
        }

        /// <summary>
        /// Shows the application sidebar.
        /// </summary>
        void ShowSidebar();

        /// <summary>
        /// Hides the application sidebar.
        /// </summary>
        void HideSidebar();

        /// <summary>
        /// Toggles the visibility of the application sidebar.
        /// </summary>
        void ToggleSidebar();

        /// <summary>
        /// Shows the project tree displaying all scene nodes in a hierarchy.
        /// </summary>
        void ShowProjectTree();

        /// <summary>
        /// Hides the project tree displaying all scene nodes in a hierarchy.
        /// </summary>
        void HideProjectTree();

        /// <summary>
        /// Toggles the visibility of the project tree.
        /// </summary>
        void ToggleProjectTree();

        /// <summary>
        /// Shows the object inspector displaying all attributes of the 
        /// currently selected scene object.
        /// </summary>
        void ShowInspector();

        /// <summary>
        /// Hides the object inspector displaying all attributes of the 
        /// currently selected scene object.
        /// </summary>
        void HideInspector();

        /// <summary>
        /// Toggles the visibility of the object inspector.
        /// </summary>
        void ToggleInspector();
    }
}
