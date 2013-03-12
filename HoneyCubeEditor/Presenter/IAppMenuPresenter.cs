#region Using Statements

using System.Windows.Forms;
using HoneyCube.Editor.Views;

#endregion

namespace HoneyCube.Editor.Presenter
{
    /// <summary>
    /// Unifies all kinds of menu presenters and allows them to handle events 
    /// of the menu view.
    /// </summary>
    public interface IAppMenuPresenter : IPresenter<IAppMenu>
    {
        /// <summary>
        /// Should be called everytime a menu item on the associated view 
        /// is clicked.
        /// </summary>
        /// <param name="item">The menu item clicked.</param>
        void HandleMenuItemClicked(ToolStripMenuItem item);
    }
}
