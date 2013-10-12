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
    public class SceneNameChangedEvent : SceneEvent
    {
        #region Constructor

        /// <summary>
        /// Public constructor. Creates a new scene name changed event.
        /// </summary>
        /// <param name="scene">Scene that has changed its name.</param>
        public SceneNameChangedEvent(IScene scene)
            : base(scene)
        {
            // Empty
        }

        #endregion
    }
}
