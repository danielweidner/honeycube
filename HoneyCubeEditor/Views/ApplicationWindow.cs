#region Using Statements

using System;
using System.Windows.Forms;
using HoneyCube.Editor.Presenter;

#endregion

namespace HoneyCube.Editor.Views
{
    /// <summary>
    /// Represents the main view within the application. Holds most of the
    /// control elements.
    /// </summary>
    public partial class ApplicationWindow : Form, IApplication
    {
        #region Properties

        /// <summary>
        /// The presenter controlling the behavior of the editor.
        /// </summary>
        public IApplicationPresenter Presenter 
        { 
            get;
            set; 
        }

        /// <summary>
        /// TODO
        /// </summary>
        public bool IsSidebarVisible
        {
            get { return !WorkspaceSplitContainer.Panel2Collapsed; }
        }

        /// <summary>
        /// TODO
        /// </summary>
        public bool IsProjectTreeVisible
        {
            get { return false; }
        }

        /// <summary>
        /// TODO
        /// </summary>
        public bool IsInspectorVisible
        {
            get { return false; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Public constructor. Creates a new form element holding the general 
        /// controls of the application.
        /// </summary>
        public ApplicationWindow(MenuStrip menu)
        {
            InitializeComponent();

            MainMenuStrip = menu;
            ToolbarContainer.TopToolStripPanel.Controls.Add(menu);
        }

        #endregion

        #region IEditorView Members

        /// <summary>
        /// TODO
        /// </summary>
        public void ShowSidebar()
        {
            WorkspaceSplitContainer.Panel2Collapsed = false;
            //GetMenuItem("ShowHideSidebarMenuItem").Text = "Hide Sidebar";
        }

        /// <summary>
        /// TODO
        /// </summary>
        public void HideSidebar()
        {
            WorkspaceSplitContainer.Panel2Collapsed = true;
            //GetMenuItem("ShowHideSidebarMenuItem").Text = "Show Sidebar";
        }

        /// <summary>
        /// TODO
        /// </summary>
        public void ShowProjectTree()
        {
            SidebarSplitContainer.Panel1Collapsed = false;
            //GetMenuItem("ShowHideProjectMenuItem").Checked = true;
        }

        /// <summary>
        /// TODO
        /// </summary>
        public void HideProjectTree()
        {
            SidebarSplitContainer.Panel1Collapsed = true;
            //GetMenuItem("ShowHideProjectMenuItem").Checked = false;
        }

        /// <summary>
        /// TODO
        /// </summary>
        public void ShowInspector()
        {
            SidebarSplitContainer.Panel2Collapsed = false;
            //GetMenuItem("ShowHideInspectorMenuItem").Checked = true;
        }

        /// <summary>
        /// TODO
        /// </summary>
        public void HideInspector()
        {
            SidebarSplitContainer.Panel2Collapsed = true;
            //GetMenuItem("ShowHideInspectorMenuItem").Checked = false;
        }

        #endregion

        #region EventHandler

        #region Menu Item Clicked

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowHideSidebarMenuItem_Click(object sender, EventArgs e)
        {
            Presenter.ShowHideSidebarClicked();
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowHideProjectMenuItem_Click(object sender, EventArgs e)
        {
            Presenter.ShowHideProjectClicked();
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowHideInspectorMenuItem_Click(object sender, EventArgs e)
        {
            Presenter.ShowHideInspectorClicked();
        }

        /// <summary>
        /// Is raised when the exit menu item is clicked by the user.
        /// </summary>
        /// <param name="sender">The exit menu item.</param>
        /// <param name="e">Empty event argument.</param>
        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        /// <summary>
        /// Is raised every time a close of the form is requested.
        /// </summary>
        /// <param name="sender">The form that is going to be closed.</param>
        /// <param name="e">Some event arguments (e.g. the closing reason).</param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Presenter.CloseRequested();
        }

        #endregion
    }
}