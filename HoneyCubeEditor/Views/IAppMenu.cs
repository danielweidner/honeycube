#region Using Statements

using System.Windows.Forms;
using HoneyCube.Editor.Presenter;

#endregion

namespace HoneyCube.Editor.Views
{
    /// <summary>
    /// Describes an interface for a menu consisting of a set of hierarchical
    /// menu items.
    /// </summary>
    public interface IAppMenu : IView<IAppMenuPresenter>
    {
        /// <summary>
        /// Enables the specified menu item. Only enabled elements can 
        /// react to user events.
        /// </summary>
        /// <param name="name">The name of the item to enable.</param>
        void EnableItem(string name);

        /// <summary>
        /// Disables the specified menu item. Blocks the menu item from
        /// user interaction.
        /// </summary>
        /// <param name="name">The name of the item to disable.</param>
        void DisableItem(string name);

        /// <summary>
        /// Updates the text displayed for the given menu item.
        /// </summary>
        /// <param name="name">The name of the item to change the label of.</param>
        /// <param name="text">The text to display for the menu item.</param>
        void UpdateItemLabel(string name, string text);

        /// <summary>
        /// Changes the shortcut which triggers the click event of the given menu item.
        /// </summary>
        /// <param name="name">The name of the item to change the shortcut for.</param>
        /// <param name="shortcut">The shortcut to assign to the menu item</param>
        void UpdateItemShortcut(string name, Keys shortcut);
    }
}
