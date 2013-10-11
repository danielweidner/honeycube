#region Using Statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#endregion

namespace HoneyCube.Editor.Events.Scene
{
    /// <summary>
    /// Raised once the currently active scene is closed by the user.
    /// </summary>
    public class CurrentSceneClosedEvent
    {
        #region Field

        private IScene _scene;

        #endregion

        #region Properties

        /// <summary>
        /// The scene object that has been closed.
        /// </summary>
        public IScene Scene
        {
            get { return _scene; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Public constructor. Creates a scene closed event.
        /// </summary>
        /// <param name="scene">The scene that has been closed.</param>
        public CurrentSceneClosedEvent(IScene scene)
        {
            _scene = scene;
        }

        #endregion
    }
}
