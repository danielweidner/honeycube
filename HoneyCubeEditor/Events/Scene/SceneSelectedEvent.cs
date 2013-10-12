#region Using Statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#endregion

namespace HoneyCube.Editor.Events.Scene
{
    /// <summary>
    /// Raised when a scene is selected by the user.
    /// </summary>
    public class SceneSelectedEvent : SceneEvent
    {
        #region Constructor

        /// <summary>
        /// Public constructor. Creates a new scene selected event.
        /// </summary>
        /// <param name="scene">Scene selected by the user.</param>
        public SceneSelectedEvent(IScene scene) 
            : base(scene)
        {
            // Empty
        }

        #endregion
    }
}
