#region Using Statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HoneyCube.Editor.Services;

#endregion

namespace HoneyCube.Editor.Events.Project
{
    /// <summary>
    /// A generic base class for all project events.
    /// </summary>
    public class ProjectEvent
    {
        #region Fields

        private IProjectManager _project;

        #endregion

        #region Properties

        /// <summary>
        /// Returns the project that has caused the current event.
        /// </summary>
        public IProjectManager Project
        {
            get { return _project; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Public constructor. Creates a new project event.
        /// </summary>
        /// <param name="project">Project triggering the event.</param>
        public ProjectEvent(IProjectManager project)
        {
            _project = project;
        }

        #endregion
    }
}
