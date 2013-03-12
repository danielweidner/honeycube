#region Using Statements

using HoneyCube.Editor.Views;

#endregion

namespace HoneyCube.Editor.Presenter
{
    /// <summary>
    /// The IAppWindowPresenter interface describes a presenter which controls
    /// the behavior of the main application window.
    /// </summary>
    public interface IAppWindowPresenter : IPresenter<IAppWindow>
    {
        /// <summary>
        /// Tells the Presenter that a close command for the current view has
        /// been requested.
        /// </summary>
        void CloseRequested();
    }
}
