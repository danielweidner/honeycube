#region Using Statements

using System.ComponentModel;
using System.Windows.Forms;
using HoneyCube.Editor.Input;
using HoneyCube.Editor.Presenter;
using HoneyCube.Editor.Services;
using System.Collections.Generic;
using StructureMap;
using System.Drawing;
using System;

#endregion

namespace HoneyCube.Editor.Views
{
    /// <summary>
    /// Represents the main view within the application. Holds most of the
    /// control elements.
    /// </summary>
    public partial class AppWindow : Form, IAppWindow, IControlService, ILocalizable
    {
        #region Fields

        private IAppMenu _menu;
        private IAppToolbar _toolbar;
        private IObjectInspector _inspector;
        private IProjectTree _tree;

        private bool _closing = false;

        private bool sidebarCollapsed = false;
        private bool projectTreeCollapsed = false;
        private bool inspectorCollapsed = false;

        #endregion

        #region Properties

        /// <summary>
        /// The presenter controlling the behavior of the application window.
        /// </summary>
        public IAppWindowPresenter Presenter
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates whether a closing process has been initiated.
        /// </summary>
        public bool IsClosing
        {
            get { return _closing; }
        }

        /// <summary>
        /// The main menu of the application window.
        /// </summary>
        public IAppMenu AppMenu
        {
            get { return _menu; }
            set 
            { 
                _menu = value;

                Control control = _menu as Control;
                if (control != null)
                {
                    control.Dock = DockStyle.Top;
                    LayoutPanel.Controls.Add(control, 0, 0);
                }
            }
        }

        /// <summary>
        /// The main toolbar of the application window providing shortcuts for
        /// essential application features.
        /// </summary>
        public IAppToolbar AppToolbar
        {
            get { return _toolbar; }
            set 
            { 
                _toolbar = value;

                Control control = _toolbar as Control;
                if (control != null)
                {
                    control.Dock = DockStyle.Top;
                    LayoutPanel.Controls.Add(control, 0, 1);
                }
            }
        }

        /// <summary>
        /// The inspector displays object properties that can be modified by 
        /// the user.
        /// </summary>
        public IObjectInspector Inspector
        {
            get { return _inspector; }
            set
            {
                _inspector = value;

                Control control = _inspector as Control;
                if (control != null)
                {
                    control.Dock = DockStyle.Fill;
                    SidebarPanel2Split.Panel2.Controls.Add(control);
                }
            }
        }

        /// <summary>
        /// The project tree displays created scene nodes in a hierarchy.
        /// </summary>
        public IProjectTree ProjectTree
        {
            get { return _tree; }
            set
            {
                _tree = value;

                Control control = _tree as Control;
                if (control != null)
                {
                    control.Dock = DockStyle.Fill;
                    SidebarPanel1Split.Panel2.Controls.Add(control);
                }
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Public constructor. Creates a new application window.
        /// </summary>
        /// <param name="publisher">
        ///     A helper class that allows to query for mouse events independent on 
        ///     the currently active control.
        /// </param>
        public AppWindow(IMouseEventPublisher publisher)
        {
            InitializeComponent();
            RegisterForMouseEvents(publisher);

            // Accounting for a strange designer bug
            WorkspaceSplitContainer.SplitterWidth = 1;
            SidebarSplitContainer.SplitterWidth = 1;
        }

        /// <summary>
        /// Registeres the current application window for mouse events.
        /// </summary>
        /// <param name="publisher">The helper class publishing mouse events.</param>
        private void RegisterForMouseEvents(IMouseEventPublisher publisher)
        {
            publisher.MouseDown += new MouseEventHandler(AppWindow_MouseDown);
            publisher.MouseUp += new MouseEventHandler(AppWindow_MouseUp);

            // If the event publisher comes as message filter, register it 
            // for the currently running application
            IMessageFilter mouseMessageFilter = publisher as IMessageFilter;
            if (mouseMessageFilter != null)
                Application.AddMessageFilter(mouseMessageFilter);
        }

        #endregion

        #region ILocalizable Members

        /// <summary>
        /// Localizes all elements attached to the current window component.
        /// </summary>
        public void LocalizeComponent()
        {
            L10n.AssignIcon(this, "HoneyCube");
            L10n.AssignIcon(WelcomePageLinkNewProject, "NewProject");
            L10n.AssignIcon(WelcomePageLinkOpenProject, "OpenProject");

            L10n.AssignImage(WelcomePageLogo, "Logo");
            L10n.AssignImage(WelcomePageNavigationSeperator, "Separator");
        }

        #endregion

        #region IControlService Members

        /// <summary>
        /// Searches all attached control elements and returns the first element
        /// with the given name.
        /// </summary>
        /// <typeparam name="T">The type of the control element to find.</typeparam>
        /// <param name="name">The name of the element to find.</param>
        /// <returns>The first attached element with the given name. Null if not found or wrong type.</returns>
        public T GetControl<T>(string name) where T : Component
        {
            Component control = SearchAliases(name);
            
            // In case the given component name was not defined amoung the 
            // aliases we start searching in the collection of control 
            // elements attached to the current view
            if (control == null)
                control = SearchControls(name);

            // If the component was still not found, we check whether the
            // searched element is a menu item.
            if (control == null)
                control = SearchMenuItems(name);
            
            return control as T;
        }

        /// <summary>
        /// Translates name aliases to actiual control instances.
        /// </summary>
        /// <param name="name">The name of control to retrieve.</param>
        /// <returns>The corresponding control element.</returns>
        private Component SearchAliases(string name)
        {
            switch (name)
            {
                case "Sidebar":
                    return WorkspaceSplitContainer.Panel2;
                case "ProjectTree":
                    return SidebarSplitContainer.Panel1;
                case "Inspector":
                    return SidebarSplitContainer.Panel2;
                default:
                    return null;
            }
        }

        /// <summary>
        /// Searches for the given control element in the Control collection of 
        /// the current application window.
        /// </summary>
        /// <param name="name">The name of the element to find.</param>
        /// <returns>A reference to the element. Null if not found.</returns>
        private Component SearchControls(string name)
        {
            Component[] controls = Controls.Find(name, true);
            return controls.Length > 0 ? controls[0] : null;
        }

        /// <summary>
        /// Searches for the given element in the collection of menu items.
        /// </summary>
        /// <param name="name">The name of the element to find.</param>
        /// <returns>A reference to the element. Null if not found.</returns>
        private Component SearchMenuItems(string name)
        {
            return _menu.FindItem(name);
        }

        #endregion

        #region IAppWindow

        /// <summary>
        /// Takes all panel flags into account and updates the corresponding 
        /// form elements.
        /// </summary>
        private void UpdateSidebarComponents()
        {
            WorkspaceSplitContainer.Panel2Collapsed = sidebarCollapsed;

            // Update label of the menu item
            ToolStripMenuItem sidebarItem = GetControl<ToolStripMenuItem>("MenuViewSidebarSidebar");
            sidebarItem.Text = L10n.LookUpLocalizedString("MenuViewSidebarSidebar" + (sidebarCollapsed ? "Collapsed" : "Visible"), L10nResourceType.Controls);

            if (!sidebarCollapsed && projectTreeCollapsed && inspectorCollapsed)
            {
                HideSidebar();
            }
            else
            {
                SidebarSplitContainer.Panel1Collapsed = projectTreeCollapsed;
                SidebarSplitContainer.Panel2Collapsed = inspectorCollapsed;

                // Update radio button
                ToolStripMenuItem projectTreeItem = GetControl<ToolStripMenuItem>("MenuViewSidebarProjectTree");
                projectTreeItem.Checked = !projectTreeCollapsed;
                ToolStripMenuItem inspectorItem = GetControl<ToolStripMenuItem>("MenuViewSidebarInspector");
                inspectorItem.Checked = !inspectorCollapsed;
            }
        }

        /// <summary>
        /// Shows the application sidebar.
        /// </summary>
        public void ShowSidebar()
        {
            sidebarCollapsed = false;
            UpdateSidebarComponents();
        }

        /// <summary>
        /// Hides the application sidebar.
        /// </summary>
        public void HideSidebar()
        {
            sidebarCollapsed = true;
            UpdateSidebarComponents();
        }

        /// <summary>
        /// Toggles the visibility of the application sidebar.
        /// </summary>
        public void ToggleSidebar()
        {
            sidebarCollapsed = !sidebarCollapsed;

            if (!sidebarCollapsed && projectTreeCollapsed && inspectorCollapsed)
            {
                projectTreeCollapsed = false;
                inspectorCollapsed = false;
            }

            UpdateSidebarComponents();
        }

        /// <summary>
        /// Shows the project tree displaying all scene nodes in a hierarchy.
        /// </summary>
        public void ShowProjectTree()
        {
            projectTreeCollapsed = false;
            UpdateSidebarComponents();
        }

        /// <summary>
        /// Hides the project tree displaying all scene nodes in a hierarchy.
        /// </summary>
        public void HideProjectTree()
        {
            projectTreeCollapsed = true;
            UpdateSidebarComponents();
        }

        /// <summary>
        /// Toggles the visibility of the project tree.
        /// </summary>
        public void ToggleProjectTree()
        {
            projectTreeCollapsed = !projectTreeCollapsed;
            UpdateSidebarComponents();
        }

        /// <summary>
        /// Shows the object inspector displaying all attributes of the 
        /// currently selected scene object.
        /// </summary>
        public void ShowInspector()
        {
            inspectorCollapsed = false;
            UpdateSidebarComponents();
        }

        /// <summary>
        /// Hides the object inspector displaying all attributes of the 
        /// currently selected scene object.
        /// </summary>
        public void HideInspector()
        {
            inspectorCollapsed = true;
            UpdateSidebarComponents();
        }

        /// <summary>
        /// Toggles the visibility of the object inspector.
        /// </summary>
        public void ToggleInspector()
        {
            inspectorCollapsed = !inspectorCollapsed;
            UpdateSidebarComponents();
        }

        /// <summary>
        /// Show the welcome page presenting the user useful information on
        /// startup.
        /// </summary>
        public void ShowWelcomePage()
        {
            if (!SceneViewer.TabPages.Contains(WelcomePage))
                SceneViewer.TabPages.Add(WelcomePage);
        }

        /// <summary>
        /// Hide the welcome page.
        /// </summary>
        public void HideWelcomePage()
        {
            SceneViewer.TabPages.Remove(WelcomePage);
        }

        #endregion

        #region EventHandler

        /// <summary>
        /// Is called every time a close of the form is requested.
        /// </summary>
        /// <param name="sender">The form that is going to be closed.</param>
        /// <param name="e">Some event arguments (e.g. the closing reason).</param>
        protected override void OnClosing(CancelEventArgs e)
        {
            if (Presenter != null)
            {
                // Cancel the default event we use our own closing procedure
                if (!_closing)
                {
                    e.Cancel = true;
                    _closing = true;
                    Presenter.CloseRequested();
                }             
            }

            base.OnClosing(e);
        }

        /// <summary>
        /// Is raised every time the left mouse button is down/pressed within 
        /// the application window.
        /// </summary>
        /// <param name="sender">The object that has detected the mouse event.</param>
        /// <param name="e">Some additional event arguments (holding mouse position etc.)</param>
        private void AppWindow_MouseDown(object sender, MouseEventArgs e)
        {
            if (Presenter != null)
            {
                Presenter.HandleMouseInput(
                    MouseButtons.Left,
                    MouseButtonState.Pressed,
                    e.Clicks,
                    e.X, e.Y,
                    ModifierKeys);
            }
        }

        /// <summary>
        /// Is raised every time the left mouse button is released within 
        /// the application window.
        /// </summary>
        /// <param name="sender">The object that has detected the mouse event.</param>
        /// <param name="e">Some additional event arguments (holding mouse position etc.)</param>
        private void AppWindow_MouseUp(object sender, MouseEventArgs e)
        {
            if (Presenter != null)
            {
                Presenter.HandleMouseInput(
                    MouseButtons.Left,
                    MouseButtonState.Released,
                    e.Clicks,
                    e.X, e.Y,
                    ModifierKeys);
            }
        }

        /// <summary>
        /// Is raised on every paint refresh of the welcome page. Allows us to
        /// draw a border only on the left of the panel.
        /// </summary>
        /// <param name="sender">The panel drawn to the surface of the application.</param>
        /// <param name="e">Some event arguments.</param>
        private void WelcomePageContent_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel != null)
            {
                // Draw only a left border for the control
                ControlPaint.DrawBorder(e.Graphics,
                    panel.ClientRectangle,
                    Color.LightGray, 1, ButtonBorderStyle.Solid,
                    Color.LightGray, 1, ButtonBorderStyle.None,
                    Color.LightGray, 1, ButtonBorderStyle.None,
                    Color.LightGray, 1, ButtonBorderStyle.None);
            }
        }

        /// <summary>
        /// Is raised every time the scene viewer is clicked. Checks which of
        /// the tabs has been clicked.
        /// </summary>
        /// <param name="sender">A reference to the scene viewer component.</param>
        /// <param name="e">Some event arguments.</param>
        private void SceneViewer_MouseClick(object sender, MouseEventArgs e)
        {
            if (Presenter != null)
            {
                for (int i = 0; i < SceneViewer.TabCount; i++)
                {
                    if (SceneViewer.GetTabRect(i).Contains(e.Location))
                    {
                        TabPage page = SceneViewer.TabPages[i];
                        if (page is ISceneView)
                            Presenter.SceneViewClicked(page as ISceneView, e.Button);
                        else if (page.Name.Equals("WelcomePage"))
                            Presenter.WelcomePageClicked(e.Button);
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Is raised when the close button on the project tree panel is clicked.
        /// </summary>
        /// <param name="sender">A reference to the close button.</param>
        /// <param name="e">Some event arguments.</param>
        private void HideProjectTreeButton_Click(object sender, EventArgs e)
        {
            this.HideProjectTree();
        }

        /// <summary>
        /// Is raised when the close button on the inspector panel is clicked.
        /// </summary>
        /// <param name="sender">A reference to the close button.</param>
        /// <param name="e">Some event arguments.</param>
        private void HideInspectorButton_Click(object sender, EventArgs e)
        {
            this.HideInspector();
        }

        #endregion
    }
}