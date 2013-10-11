#region Using Statements

using HoneyCube.Editor.Events;
using HoneyCube.Editor.Events.Scene;
using HoneyCube.Editor.Inspector;
using HoneyCube.Editor.Views;

#endregion

namespace HoneyCube.Editor.Presenter
{
    /// <summary>
    /// TODO
    /// </summary>
    public class InspectorPresenter : IInspectorPresenter, IEventHandler<CurrentSceneChangedEvent>, IEventHandler<CurrentSceneClosedEvent>
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
        public InspectorPresenter(IObjectInspector view)
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
                _view.Show(new SceneWrapper(args.CurrentScene));
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
