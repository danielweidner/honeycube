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
    /// Raised once a new project is created.
    /// </summary>
    public class ProjectCreatedEvent : ProjectEvent
    {
        #region Constructor

        /// <summary>
        /// Public constructor. Creates a new project created event.
        /// </summary>
        /// <param name="project">Project created by the user.</param>
        public ProjectCreatedEvent(IProjectManager project) 
            : base(project)
        {
            // Empty
        }

        #endregion
    }
}
