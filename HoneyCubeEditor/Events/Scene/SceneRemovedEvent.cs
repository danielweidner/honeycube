#region Using Statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#endregion

namespace HoneyCube.Editor.Events.Scene
{
    /// <summary>
    /// Raised when a new scene is removed from the current project.
    /// </summary>
    public class SceneRemovedEvent : SceneEvent
    {
       #region Constructor

        /// <summary>
        /// Public constructor. Creates a new scene removed event.
        /// </summary>
        /// <param name="scene">Scene removed by the user.</param>
        public SceneRemovedEvent(IScene scene) 
            : base(scene)
        {
            // Empty
        }

        #endregion
    }
}
