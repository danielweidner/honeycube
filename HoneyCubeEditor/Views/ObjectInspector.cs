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
using HoneyCube.Editor.Inspector;

#endregion

namespace HoneyCube.Editor.Views
{
    /// <summary>
    /// TODO
    /// </summary>
    public partial class ObjectInspector : UserControl, IObjectInspector, ILocalizable
    {
        #region Properties

        /// <summary>
        ///  The presenter controlling the behavior of the object property view. 
        /// </summary>
        public IInspectorPresenter Presenter
        {
            get;
            set;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// TODO
        /// </summary>
        public ObjectInspector()
        {
            InitializeComponent();
        }

        #endregion

        #region ILocalizable

        /// <summary>
        /// Localizes all elements attached to the current component.
        /// </summary>
        public void LocalizeComponent()
        {
            // Empty
        }

        #endregion

        #region IObjectInspector

        /// <summary>
        /// Displays the specified object and all its public properties in the
        /// inspector.
        /// </summary>
        /// <param name="obj">The object to display.</param>
        public void Show(IInspectorObject obj)
        {
            Grid.SelectedObject = obj;
        }

        /// <summary>
        /// Resets the object inspector to its initial state. Stops the 
        /// inspector from displaying the currently selected object.
        /// </summary>
        public void Reset()
        {
            Grid.SelectedObject = null;
        }

        /// <summary>
        /// Enables the inspector to allow user interaction.
        /// </summary>
        public void Enable()
        {
            Grid.Enabled = true;
        }

        /// <summary>
        /// Disables the inspector and blocks user interaction.
        /// </summary>
        public void Disable()
        {
            Grid.Enabled = false;
        }

        #endregion
    }
}
