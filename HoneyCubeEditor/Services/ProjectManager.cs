#region Using Statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HoneyCube.Editor.Events;
using HoneyCube.Editor.Events.Scene;
using HoneyCube.Editor.Inspector;
using StructureMap;
using HoneyCube.Editor.Events.Project;

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

        private IContainer _container;
        private IEventPublisher _eventSystem;

        private bool _loaded;
        private bool _dirty;

        private string _projectName;
        private IList<IScene> _scenes;

        #endregion

        #region Properties

        /// <summary>
        /// Indicates whether the project is loaded successfully.
        /// </summary>
        public bool Loaded
        {
            get { return _loaded; }
        }

        /// <summary>
        /// Indicates whether the current project has unsaved changes.
        /// </summary>
        public bool Dirty
        {
            get { return _dirty; }
        }

        /// <summary>
        /// Get a human readable name for the current project.
        /// </summary>
        public string Name
        {
            get { return _projectName; }
            set { _projectName = value; }
        }

        /// <summary>
        /// A collection of scenes currently modified by the user.
        /// </summary>
        public IList<IScene> Scenes
        {
            get { return _scenes; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Public constructor. Creates a project manager maintaining scene 
        /// objects.
        /// 
        /// TODO: Should use a custom scene factory, instead of the generic service locator.
        /// </summary>
        /// <param name="container">Container implementing the service locator pattern.</param>
        /// <param name="eventSystem">Application event system.</param>
        public ProjectManager(IContainer container, IEventPublisher eventSystem)
        {
            _container = container;
            _eventSystem = eventSystem;

            _projectName = string.Empty;
            _scenes = new List<IScene>();
            _loaded = false;
            _dirty = true;
        }

        #endregion

        #region IProjectManager

        /// <summary>
        /// Creates a new project with the given name.
        /// </summary>
        /// <param name="name">Name of the project.</param>
        public void CreateProject(string name)
        {
            // Close a loaded project before creating a new one.
            if (_loaded)
                CloseProject();

            // Assign the new project name.
            _projectName = name;
            _loaded = true;
            _eventSystem.Publish(new ProjectCreatedEvent(this));
        }

        /// <summary>
        /// Loads a project from a file on disc.
        /// </summary>
        /// <param name="path">Path of the project file.</param>
        /// <returns>True if saved successfully.</returns>
        public bool LoadProject(string path)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Saves the current project to a file.
        /// </summary>
        /// <param name="path">File path.</param>
        /// <returns>True if saved successfully.</returns>
        public bool SaveProject(string path)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Closes the current project.
        /// </summary>
        public void CloseProject()
        {
            // Remove all scenes from the current project
            for (int i = _scenes.Count - 1; i >= 0; i--)
                RemoveScene(_scenes[i]);                

            _eventSystem.Publish(new ProjectClosedEvent(this));

            // Reset the all attributes
            _projectName = string.Empty;
            _loaded = false;
        }

        /// <summary>
        /// Creates a new scene object that can be edited by the user.
        /// </summary>
        /// <returns>Created scene object.</returns>
        public IScene CreateScene()
        {
            IScene scene = _container.GetInstance<IScene>();
            _scenes.Add(scene);
            _eventSystem.Publish(new SceneCreatedEvent(scene));
            return scene;
        }

        /// <summary>
        /// Removes a given scene from the current project.
        /// </summary>
        /// <param name="scene">Scene to remove.</param>
        /// <returns>True if the scene was successfully removed.</returns>
        public bool RemoveScene(IScene scene)
        {
            if (_scenes.Remove(scene))
            {
                _eventSystem.Publish(new SceneRemovedEvent(scene));
                return true;
            }

            return false;
        }

        /// <summary>
        /// Loads a saved scene from a file on disc.
        /// </summary>
        /// <param name="path">Path to the saved scene file.</param>
        /// <returns>Loaded scene object.</returns>
        public IScene LoadScene(string path)
        {
            throw new NotImplementedException();
        }

        #endregion        
    }
}
