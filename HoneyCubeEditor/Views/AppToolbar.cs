#region Using Statements

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HoneyCube.Editor.Presenter;
using HoneyCube.Editor.Events;

#endregion

namespace HoneyCube.Editor.Views
{
    /// <summary>
    /// The application toolbar holds quick access buttons for core features.
    /// </summary>
    public partial class AppToolbar : UserControl, IAppToolbar, ILocalizable, IEventHandler<AppLogActiveEvent>, IEventHandler<AppLogClosingEvent>
    {
        #region Properties

        /// <summary>
        /// The associated presenter controlling the overall behavior of the
        /// toolbar.
        /// </summary>
        public IAppToolbarPresenter Presenter
        {
            get;
            set;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Public constructor. Creates a new application toolbar.
        /// </summary>
        public AppToolbar(IEventPublisher publisher)
        {
            InitializeComponent();
            publisher.RegisterHandlers(this);
        }

        #endregion

        #region ILocalizable

        /// <summary>
        /// Localizes all elements attached to the current component.
        /// </summary>
        public void LocalizeComponent()
        {
            L10n.AssignIcon(ToolbarNewProject, "NewProject");
            L10n.AssignIcon(ToolbarOpenProject, "OpenProject");
            L10n.AssignIcon(ToolbarSave, "Save");
            L10n.AssignIcon(ToolbarUndo, "Undo");
            L10n.AssignIcon(ToolbarRedo, "Redo");
            L10n.AssignIcon(ToolbarCopy, "Copy");
            L10n.AssignIcon(ToolbarPaste, "Paste");
            L10n.AssignIcon(ToolbarCut, "Cut");
            L10n.AssignIcon(ToolbarLog, "Log");
        }

        #endregion

        #region Event Handler

        /// <summary>
        /// Is called every time the application log is activated.
        /// </summary>
        /// <param name="e">Some optional event arguments.</param>
        public void HandleApplicationEvent(AppLogActiveEvent e)
        {
            ToolbarLog.Checked = true;
        }

        /// <summary>
        /// Is called every time the application log is closed.
        /// </summary>
        /// <param name="e">Some optional event arguments.</param>
        public void HandleApplicationEvent(AppLogClosingEvent e)
        {
            ToolbarLog.Checked = false;
        }
        /// <summary>
        /// Is called every time a button of the toolbar is clicked.
        /// </summary>
        /// <param name="sender">A reference to the application toolbar clicked.</param>
        /// <param name="e"></param>
        private void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem item = e.ClickedItem as ToolStripItem;
            if (item != null)
                OnItemClicked(item);
        }

        /// <summary>
        /// Is called everytime a valid toolstrip item is clicked. Can be overwritten.
        /// </summary>
        /// <param name="item">The item that has been clicked.</param>
        protected virtual void OnItemClicked(ToolStripItem item)
        {
            if (Presenter != null)
                Presenter.HandleItemClicked(item);
        }
        #endregion
    }
}
