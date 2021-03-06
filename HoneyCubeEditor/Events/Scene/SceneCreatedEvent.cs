﻿#region Using Statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#endregion

namespace HoneyCube.Editor.Events.Scene
{
    /// <summary>
    /// Raised once a new scene is created.
    /// </summary>
    public class SceneCreatedEvent : SceneEvent
    {
        #region Constructor

        /// <summary>
        /// Public constructor. Creates a new scene created event.
        /// </summary>
        /// <param name="scene">Scene created by the user.</param>
        public SceneCreatedEvent(IScene scene) 
            : base(scene)
        {
            // Empty
        }

        #endregion
    }
}
