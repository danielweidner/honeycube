#region Using Statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HoneyCube.Editor.Views;
using System.Windows.Forms;

#endregion

namespace HoneyCube.Editor.Presenter
{
    /// <summary>
    /// Handles events of the application toolbar.
    /// </summary>
    public interface IAppToolbarPresenter : IPresenter<IAppToolbar>
    {
        /// <summary>
        /// Should be called everytime a toolstrip item on the associated view
        /// is clicked.
        /// </summary>
        /// <param name="item">The toolstrip item clicked.</param>
        void HandleItemClicked(ToolStripItem item);
    }
}
