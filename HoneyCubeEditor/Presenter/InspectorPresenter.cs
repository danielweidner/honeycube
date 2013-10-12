#region Using Statements

using HoneyCube.Editor.Events;
using HoneyCube.Editor.Events.Scene;
using HoneyCube.Editor.Inspector;
using HoneyCube.Editor.Views;
using HoneyCube.Editor.Services;
using System.Collections.Generic;
using System.ComponentModel;

#endregion

namespace HoneyCube.Editor.Presenter
{
    /// <summary>
    /// Controls the behavior of the ObjectInspector view.
    /// </summary>
    public class InspectorPresenter : IInspectorPresenter, IEventHandler<SceneSelectedEvent>, IEventHandler<SceneRemovedEvent>
    {
        #region Fields

        private IEventPublisher _eventSystem;
        private Dictionary<IScene, SceneContainer> _containers;

        private IObjectInspector _view;

        #endregion

        #region Properties

        /// <summary>
        /// Returns the associated view. 
        /// </summary>
        public IObjectInspector View
        {
            get { return _view; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Public constructor. Creates a presenter to control the behavior of
        /// the associated view.
        /// </summary>
        /// <param name="view">View to control.</param>
        /// <param name="eventSystem">Application event system.</param>
        public InspectorPresenter(IObjectInspector view, IEventPublisher eventSystem)
        {
            _view = view;
            _view.Presenter = this;
            _containers = new Dictionary<IScene, SceneContainer>();
            _eventSystem = eventSystem;
        }

        #endregion

        /// <summary>
        /// Tries to get a scene container for a scene with the given name.
        /// </summary>
        /// <param name="name">Name of the scene.</param>
        /// <returns>Container of the first scene matching the name.</returns>
        protected SceneContainer TryGetContainer(string name)
        {
            foreach (KeyValuePair<IScene, SceneContainer> pair in _containers)
                if (pair.Key.Name == name)
                    return pair.Value;

            return null;
        }

        /// <summary>
        /// Tries to get a scene container for the given scene.
        /// </summary>
        /// <param name="scene">The scene to retrieve the container for.</param>
        /// <returns>Scene container for the scene if available.</returns>
        protected SceneContainer TryGetContainer(IScene scene)
        {
            SceneContainer container = null;
            _containers.TryGetValue(scene, out container);
            return container;
        }

        #region EventHandler

        /// <summary>
        /// Is raised when a scene has been selected by the user.
        /// </summary>
        /// <param name="args">Some event arguments.</param>
        public void HandleApplicationEvent(SceneSelectedEvent args)
        {
            SceneContainer container = TryGetContainer(args.Scene);
            
            // Create and register a container if it does not exist
            if (container == null)
            {
                container = new SceneContainer(args.Scene);
                container.PropertyChanged += new PropertyChangedEventHandler(SceneContainer_PropertyChanged);
                _containers.Add(container.WrappedObject, container);
            }

            // Display the scene in the property grid.
            _view.Show(container);
            _view.Enable();
        }

        /// <summary>
        /// Is raised when a new scene is removed from the current project.
        /// </summary>
        /// <param name="args">Some event arguments.</param>
        public void HandleApplicationEvent(SceneRemovedEvent args)
        {
            SceneContainer container = TryGetContainer(args.Scene);

            // Ensure we do not hold a reference to the scene
            if (container != null)
            {
                _containers.Remove(container.WrappedObject);
                container.PropertyChanged -= SceneContainer_PropertyChanged;
                container.WrappedObject = null;
            }
        }

        /// <summary>
        /// Is raised when a property of a scene container changes.
        /// </summary>
        /// <param name="sender">Scene container that has changed.</param>
        /// <param name="args">Some event arguments.</param>
        private void SceneContainer_PropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            SceneContainer container = sender as SceneContainer;

            if (container != null && args.PropertyName == "Name")
                _eventSystem.Publish(new SceneNameChangedEvent(container.WrappedObject));
        }

        #endregion
    }
}
