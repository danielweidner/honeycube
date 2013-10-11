#region Using Statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#endregion

namespace HoneyCube.Editor.Events.Scene
{
    /// <summary>
    /// Raised once the currently active scene changed.
    /// </summary>
    public class CurrentSceneChangedEvent
    {
        #region Fields

        private IScene _current;
        private IScene _previous;

        #endregion

        #region Properties

        /// <summary>
        /// A reference to the currently active scene.
        /// </summary>
        public IScene CurrentScene
        {
            get { return _current; }
        }

        /// <summary>
        /// A reference to the scene that was previously active.
        /// </summary>
        public IScene PreviousScene
        {
            get { return _previous; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Public constructor. Creates a new scene changed event.
        /// </summary>
        /// <param name="current">The scene currently active.</param>
        public CurrentSceneChangedEvent(IScene current)
            : this(current, null)
        {
            // Empty
        }

        /// <summary>
        /// Public constructor. Creates a new scene changed event.
        /// </summary>
        /// <param name="current">The scene currently active.</param>
        /// <param name="previous">The scene active before the changed happened.</param>
        public CurrentSceneChangedEvent(IScene current, IScene previous)
        {
            _current = current;
            _previous = previous;
        }

        #endregion
    }
}
