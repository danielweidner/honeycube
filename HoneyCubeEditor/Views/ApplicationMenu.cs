#region Using Statements

using System;
using System.Windows.Forms;
using HoneyCube.Editor.Presenter;

#endregion

namespace HoneyCube.Editor.Views
{
    /// <summary>
    /// TODO
    /// </summary>
    public partial class ApplicationMenu : MenuStrip, IApplicationMenu
    {
        #region Properties

        /// <summary>
        /// TODO
        /// </summary>
        public IApplicationMenuPresenter Presenter 
        { 
            get; 
            set;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// TODO
        /// </summary>
        public ApplicationMenu()
        {
            InitializeComponent();
        }

        #endregion

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item != null)
                Presenter.MenuItemClicked(item);
        }
    }
}
