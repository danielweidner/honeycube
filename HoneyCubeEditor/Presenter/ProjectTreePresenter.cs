#region Using Statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HoneyCube.Editor.Views;
using HoneyCube.Editor.Events;
using HoneyCube.Editor.Events.Scene;
using HoneyCube.Editor.Inspector;
using System.ComponentModel;
using HoneyCube.Editor.Services;
using HoneyCube.Editor.Events.Project;

#endregion

namespace HoneyCube.Editor.Presenter
{
    /// <summary>
    /// Controls the behavior of the ProjectTree view.
    /// </summary>
    public class ProjectTreePresenter : IProjectTreePresenter, IEventHandler<ProjectCreatedEvent>, IEventHandler<ProjectClosedEvent>, IEventHandler<SceneCreatedEvent>, IEventHandler<SceneRemovedEvent>, IEventHandler<SceneNameChangedEvent>
    {
        #region Fields

        private IEventPublisher _eventSystem;

        private IProjectManager _project;
        private IProjectTree _view;

        #endregion

        #region Properties

        /// <summary>
        /// Get the associated view. The project tree view displays all project
        /// entities in a hierarchical list.
        /// </summary>
        public IProjectTree View
        {
            get { return _view; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Public constructor. Creates a new default presenter that controls
        /// the overal behavior of a project tree view.
        /// </summary>
        /// <param name="view">Associated view.</param>
        /// <param name="eventSystem">Application event system.</param>
        public ProjectTreePresenter(IProjectTree view, IEventPublisher eventSystem)
        {
            _view = view;
            _view.Presenter = this;
            _eventSystem = eventSystem;
        }

        #endregion

        #region Event Handler

        /// <summary>
        /// Is raised when a new project is created by the user.
        /// </summary>
        /// <param name="args">Some event arguments.</param>
        public void HandleApplicationEvent(ProjectCreatedEvent args)
        {
            _project = args.Project;

            if (_project != null)
            {
                _view.UpdateRoot(_project);
                _view.UpdateHierarchy(_project.Scenes);
                _view.Enable();
            }
        }

        /// <summary>
        /// Is raised when the current project is closed by the user.
        /// </summary>
        /// <param name="args">Some event arguments.</param>
        public void HandleApplicationEvent(ProjectClosedEvent args)
        {
            _project = null;
            _view.Reset();
        }

        /// <summary>
        /// Is raised when a new scene is added to the current project.
        /// </summary>
        /// <param name="args">Some event arguments.</param>
        public void HandleApplicationEvent(SceneCreatedEvent args)
        {
            if (_project != null)
                _view.UpdateHierarchy(_project.Scenes);
        }

        /// <summary>
        /// Is raised when a scene changes its name.
        /// </summary>
        /// <param name="args">Some event arguments.</param>
        public void HandleApplicationEvent(SceneNameChangedEvent args)
        {
            if (_project != null)
                _view.UpdateNode(args.Scene);
        }

        /// <summary>
        /// Is raised when a new scene is removed from the current project.
        /// </summary>
        /// <param name="args">Some event arguments.</param>
        public void HandleApplicationEvent(SceneRemovedEvent args)
        {
            if (_project != null)
                _view.UpdateHierarchy(_project.Scenes);
        }

        /// <summary>
        /// Instructs the presenter to handle a node selection.
        /// </summary>
        /// <param name="scene">Scene selected.</param>
        public void HandleSceneSelection(IScene scene)
        {
            if (scene != null)
                _eventSystem.Publish(new SceneSelectedEvent(scene));
        }

        #endregion
    }
}
