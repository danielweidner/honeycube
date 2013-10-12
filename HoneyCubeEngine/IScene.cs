#region Using Statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#endregion

namespace HoneyCube
{
    /// <summary>
    /// Describes a scene within the game. A scene represents the root node 
    /// within the entity hierarchy.
    /// </summary>
    public interface IScene
    {
        /// <summary>
        /// A human readable name for the current scene (not necessarily unique).
        /// </summary>
        string Name
        {
            get;
            set;
        }
    }
}
