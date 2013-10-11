#region Using Statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HoneyCube.Editor.Events;
using HoneyCube.Editor.Events.Scene;

#endregion

namespace HoneyCube.Editor.Services
{
    /// <summary>
    /// The project manager maintains all loaded and created scene instances of
    /// the user.
    /// </summary>
    public class ProjectManager : IProjectManager
    {
        #region Field

        private IEventPublisher _events;
        private IScene _current;

        #endregion

        #region Properties

        /// <summary>
        /// The scene currently loaded and modified by the user.
        /// </summary>
        public IScene CurrentScene
        {
            get { return _current; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Public constructor. Creates a project manager maintaining scene 
        /// objects.
        /// </summary>
        /// <param name="events">Application wide event system.</param>
        public ProjectManager(IEventPublisher events)
        {
            _events = events;
            _current = null;
        }

        #endregion

        #region IProjectManager

        /// <summary>
        /// Creates a new scene using the default values and uses it as the 
        /// current scene the user is working on.
        /// </summary>
        public void CreateNewScene()
        {
            IScene scene = new Scene();
            IScene old = _current;

            _events.Publish(new SceneCreatedEvent());
            _current = scene;
            _events.Publish(new CurrentSceneChangedEvent(scene, old));
        }

        /// <summary>
        /// Closes the currently loaded scene and releases all its resources.
        /// </summary>
        public void CloseCurrentScene()
        {
            _events.Publish(new CurrentSceneClosedEvent(_current));
            _current = null;
        }

        #endregion
    }
}
