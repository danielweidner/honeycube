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
        public IObjectInspectorPresenter Presenter
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

        #region IPropertyView

        // Empty

        #endregion
    }
}
