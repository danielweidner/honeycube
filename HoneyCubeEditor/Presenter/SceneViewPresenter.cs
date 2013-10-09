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
    /// TODO
    /// </summary>
    public class SceneViewPresenter : ISceneViewPresenter
    {
        #region Fields

        private ISceneView _view;
        private ICameraService _cameras;

        #endregion

        #region Properties

        /// <summary>
        /// TODO
        /// </summary>
        public ICamera Camera
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// TODO
        /// </summary>
        public ISceneView View
        {
            get { return _view; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// TODO
        /// </summary>
        public SceneViewPresenter(ISceneView view, ICameraService cameras)
        {
            _view = view;
            _view.Presenter = this;
            _cameras = cameras;
        }

        #endregion
    }
}
