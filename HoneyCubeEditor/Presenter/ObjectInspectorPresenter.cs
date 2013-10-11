#region Using Statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HoneyCube.Editor.Views;
using HoneyCube.Editor.Events;
using HoneyCube.Editor.Events.Scene;

#endregion

namespace HoneyCube.Editor.Presenter
{
    /// <summary>
    /// TODO
    /// </summary>
    public class ObjectInspectorPresenter : IObjectInspectorPresenter, IEventHandler<CurrentSceneChangedEvent>, IEventHandler<CurrentSceneClosedEvent>
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
            _view.Presenter = this;
        }

        #endregion

        #region Event Handler

        /// <summary>
        /// Is raised every time a new scene is activated.
        /// </summary>
        /// <param name="args">Some event arguments.</param>
        public void HandleApplicationEvent(CurrentSceneChangedEvent args)
        {
            if (args.CurrentScene != null)
            {
                _view.Show(args.CurrentScene);
                _view.Enable();
            }
            else
            {
                _view.Reset();
                _view.Disable();
            }
        }

        /// <summary>
        /// Is raised once the user closes the currently enabled scene.
        /// </summary>
        /// <param name="args">Some event arguments</param>
        public void HandleApplicationEvent(CurrentSceneClosedEvent args)
        {
            if (args.Scene != null)
            {
                _view.Reset();
                _view.Disable();
            }
        }

        #endregion
    }
}
