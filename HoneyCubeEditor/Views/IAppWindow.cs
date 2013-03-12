#region Using Statements

using System.Windows.Forms;
using HoneyCube.Editor.Presenter;

#endregion

namespace HoneyCube.Editor.Views
{
    /// <summary>
    /// The IAppWindow interface describes methods which control the overall
    /// appearance of the main application window.
    /// </summary>
    public interface IAppWindow : IView<IAppWindowPresenter>
    {
        // Empty
    }
}
