#region Using Statements

using System.ComponentModel;
using System.Windows.Forms;
using HoneyCube.Editor.Input;
using HoneyCube.Editor.Presenter;
using HoneyCube.Editor.Services;

#endregion

namespace HoneyCube.Editor.Views
{
    /// <summary>
    /// Represents the main view within the application. Holds most of the
    /// control elements.
    /// </summary>
    public partial class AppWindow : Form, IAppWindow, IControlService, ILocalizable
    {
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
        /// Get/set the primary menu container of the application window.
        /// </summary>
        public new MenuStrip MainMenuStrip
        {
            get { return base.MainMenuStrip; }
            set
            {
                if (MainMenuStrip != value)
                {
                    // Cache the collection
                    Control.ControlCollection elements = ToolbarContainer.TopToolStripPanel.Controls;

                    // Remove the previous main menu
                    elements.Remove(MainMenuStrip);

                    // Change the main menu to the new one specified
                    base.MainMenuStrip = value;

                    // Add the new main menu back to the top panel
                    ToolbarContainer.TopToolStripPanel.Controls.Add(value);
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
            ToolStripItem[] items = MainMenuStrip.Items.Find(name, true);
            return items.Length > 0 ? items[0] : null;
        }

        #endregion

        #region EventHandler

        /// <summary>
        /// Is raised every time a key is released.
        /// </summary>
        /// <param name="sender">The form that has registered the keypress event.</param>
        /// <param name="e">Some event arguments holding informations about the keys pressed.</param>
        private void AppWindow_KeyUp(object sender, KeyEventArgs e)
        {
            // Filter the keyup event of the Alt, Control and Shift keys, as 
            // we are only interested in combinations with those keys
            if (Presenter != null
                    && e.KeyData != Keys.Menu
                    && e.KeyData != Keys.ControlKey
                    && e.KeyData != Keys.ShiftKey)
            {
                Presenter.HandleKeyboardInput(e.KeyCode, e.Modifiers);
            }
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
        /// Is raised every time a close of the form is requested.
        /// </summary>
        /// <param name="sender">The form that is going to be closed.</param>
        /// <param name="e">Some event arguments (e.g. the closing reason).</param>
        private void AppWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Presenter != null)
                Presenter.CloseRequested();
        }

        #endregion        
    }
}