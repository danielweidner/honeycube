#region Using Statements

using System.Windows.Forms;
using HoneyCube.Editor.Presenter;

#endregion

namespace HoneyCube.Editor.Views
{
    /// <summary>
    /// Provides an interface for the main view of the application representing
    /// the editor with most of its controls.
    /// </summary>
    public interface IApplication : IView<IApplicationPresenter>
    {
        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        bool IsControlVisible(string name);
    }
}
