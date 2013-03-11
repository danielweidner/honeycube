#region Using Statements

using HoneyCube.Editor.Views;

#endregion

namespace HoneyCube.Editor.Presenter
{
    /// <summary>
    /// The IEditorPresenter interface describes a presenter which controls 
    /// most of the UI elements and their corresponding actions/commands.
    /// </summary>
    public interface IApplicationPresenter : IPresenter<IApplication>
    {
        /// <summary>
        /// Tells the Presenter that a close command for the current view has
        /// been requested.
        /// </summary>
        void CloseRequested();
    }
}
