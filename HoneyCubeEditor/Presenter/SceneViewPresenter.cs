#region Using Statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HoneyCube.Editor.Services;
using HoneyCube.Editor.Views;

#endregion

namespace HoneyCube.Editor.Presenter
{
    /// <summary>
    /// Controls the actual behavior of a SceneView.
    /// </summary>
    public class SceneViewPresenter : ISceneViewPresenter
    {
        #region Fields

        private ISceneView _view;

        #endregion

        #region Properties

        /// <summary>
        /// Returns the associated view.
        /// </summary>
        public ISceneView View
        {
            get { return _view; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Public constrcutor. Creats a new presenter for a scene view.
        /// </summary>
        /// <param name="view">Associated scene view.</param>
        public SceneViewPresenter(ISceneView view)
        {
            _view = view;
            _view.Presenter = this;
        }

        #endregion
    }
}
