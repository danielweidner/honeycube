#region Using Statements

using HoneyCube.Editor.Views;
using System.Windows.Forms;

#endregion

namespace HoneyCube.Editor.Presenter
{
    /// <summary>
    /// TODO
    /// </summary>
    public interface IApplicationMenuPresenter : IPresenter<IApplicationMenu>
    {
        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="item"></param>
        void MenuItemClicked(ToolStripMenuItem item);
    }
}
