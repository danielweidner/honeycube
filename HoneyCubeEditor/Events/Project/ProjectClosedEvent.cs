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
    /// Raised once a new project is closed.
    /// </summary>
    public class ProjectClosedEvent : ProjectEvent
    {
        #region Constructor

        /// <summary>
        /// Public constructor. Creates a new project closed event.
        /// </summary>
        /// <param name="project">Project closed by the user.</param>
        public ProjectClosedEvent(IProjectManager project) 
            : base(project)
        {
            // Empty
        }

        #endregion
    }
}
