#region Using Statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HoneyCube.Editor.Views;

#endregion

namespace HoneyCube.Editor.Presenter
{
    /// <summary>
    /// TODO
    /// </summary>
    public class ObjectInspectorPresenter : IObjectInspectorPresenter
    {
        #region Fields

        private IObjectInspector _view;

        #endregion

        #region Properties

        /// <summary>
        /// TODO
        /// </summary>
        public IObjectInspector View
        {
            get { return _view; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="view"></param>
        public ObjectInspectorPresenter(IObjectInspector view)
        {
            _view = view;
        }

        #endregion
    }
}
