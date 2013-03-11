#region Using Statements

using System;
using System.Windows.Forms;
using HoneyCube.Editor.Presenter;
using HoneyCube.Editor.Services;
using System.ComponentModel;
using System.Reflection;

#endregion

namespace HoneyCube.Editor.Views
{
    /// <summary>
    /// Represents the main view within the application. Holds most of the
    /// control elements.
    /// </summary>
    public partial class ApplicationWindow : Form, IApplication, IControlService
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

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool IsControlVisible(string name)
        {
            Component control = GetControl<Component>(name);
            PropertyInfo property = control.GetType().GetProperty("Visible");
            if (property != null)
            {
                object propertyValue = property.GetValue(control, null);
                return propertyValue is bool ? (bool)propertyValue : false;
            }

            return false;
        }

        #region IControlService Members

        /// <summary>
        /// TODO
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
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
        /// TODO
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
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
        /// TODO
        /// </summary>
        /// <param name="name"></param>
        /// <param name="includeAliases"></param>
        /// <returns></returns>
        private Component SearchControls(string name)
        {
            Component[] controls = Controls.Find(name, true);
            return controls.Length > 0 ? controls[0] : null;
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private Component SearchMenuItems(string name)
        {
            ToolStripItem[] items = MainMenuStrip.Items.Find(name, true);
            return items.Length > 0 ? items[0] : null;
        }

        #endregion

        #region EventHandler

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