#region Using Statements

using System;
using System.Windows.Forms;
using HoneyCube.Editor.Presenter;

#endregion

namespace HoneyCube.Editor.Views
{
    /// <summary>
    /// Represents the application menu which provides all available application
    /// commands seperated into various dropdown menus.
    /// </summary>
    public partial class AppMenu : MenuStrip, IAppMenu, ILocalizable
    {
        #region Properties

        /// <summary>
        /// Holds a reference to the associated presenter which controlls the 
        /// overall behavior of the menu.
        /// </summary>
        public IAppMenuPresenter Presenter
        {
            get;
            set;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Public constructor. Creates a new application menu instance.
        /// </summary>
        public AppMenu()
        {
            InitializeComponent();
        }

        #endregion

        #region ILocalizable Members

        /// <summary>
        /// Localizes all elements attached to the current component.
        /// </summary>
        public void LocalizeComponent()
        {
            // Empty
        }

        #endregion

        /// <summary>
        /// Returns the first menu item found with the given name.
        /// </summary>
        /// <param name="name">The name of the item to find.</param>
        /// <returns>The first item found with the given name.</returns>
        private ToolStripItem GetItem(string name)
        {
            ToolStripItem[] items = Items.Find(name, true);
            return items.Length > 0 ? items[0] : null;
        }

        /// <summary>
        /// Enables the specified menu item. Only enabled elements can 
        /// react to user events.
        /// </summary>
        /// <param name="name">The name of the item to enable.</param>
        public void EnableItem(string name)
        {
            ToolStripItem item = GetItem(name);
            if (item != null)
                item.Enabled = true;
        }

        /// <summary>
        /// Disables the specified menu item. Blocks the menu item from
        /// user interaction.
        /// </summary>
        /// <param name="name">The name of the item to disable.</param>
        public void DisableItem(string name)
        {
            ToolStripItem item = GetItem(name);
            if (item != null)
                item.Enabled = false;
        }

        /// <summary>
        /// Updates the text displayed for the given menu item.
        /// </summary>
        /// <param name="name">The name of the item to change the label of.</param>
        /// <param name="text">The text to display for the menu item.</param>
        public void UpdateItemLabel(string name, string text)
        {
            ToolStripItem item = GetItem(name);
            if (item != null)
                item.Text = text;
        }

        /// <summary>
        /// Changes the shortcut which triggers the click event of the given menu item.
        /// </summary>
        /// <param name="name">The name of the item to change the shortcut for.</param>
        /// <param name="shortcut">The shortcut to assign to the menu item</param>
        public void UpdateItemShortcut(string name, Keys shortcut)
        {
            ToolStripMenuItem item = GetItem(name) as ToolStripMenuItem;
            if (item != null)
                item.ShortcutKeys = shortcut;
        }

        #region Event Handler

        /// <summary>
        /// Is called every time a menu item is clicked.
        /// </summary>
        /// <param name="sender">The menu item clicked.</param>
        /// <param name="e">Some click event arguments.</param>
        private void MenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item != null)
                OnMenuItemClicked(item);
        }

        /// <summary>
        /// Is called everytime a valid menu item is clicked. Can be overwritten.
        /// </summary>
        /// <param name="item">The item that has been clicked.</param>
        protected virtual void OnMenuItemClicked(ToolStripMenuItem item)
        {
            if (Presenter != null)
                Presenter.HandleMenuItemClicked(item);
        }

        #endregion
    }
}
