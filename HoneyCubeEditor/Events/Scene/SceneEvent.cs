#region Using Statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#endregion

namespace HoneyCube.Editor.Events.Scene
{
    /// <summary>
    /// A generic base class for all scene events.
    /// </summary>
    public class SceneEvent
    {
        #region Fields

        private IScene _scene;

        #endregion

        #region Properties

        /// <summary>
        /// Returns the scene that has triggered the event.
        /// </summary>
        public IScene Scene
        {
            get { return _scene; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Public constructor. Creates a new scene event.
        /// </summary>
        /// <param name="scene">Scene triggering the event.</param>
        public SceneEvent(IScene scene)
        {
            _scene = scene;
        }

        #endregion
    }
}
