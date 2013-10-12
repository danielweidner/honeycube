#region Using Statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#endregion

namespace HoneyCube
{
    /// <summary>
    /// A scene represents the root node within the game entity hierarchy. All
    /// entities added to a scene can be retrieve from the scene node.
    /// </summary>
    public class Scene : IScene
    {
        #region Fields

        private static int _created = 0;

        #endregion

        #region Properties

        /// <summary>
        /// A human readable name for the current scene (not necessarily unique).
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Public constructor. Creates a new game scene.
        /// </summary>
        public Scene() : this(string.Empty)
        {
            // Empty
        }

        /// <summary>
        /// Public constructor. Creates a new game scene.
        /// </summary>
        /// <param name="name">A human readable name for the scene.</param>
        public Scene(string name)
        {
            _created++;

            Name = name;

            // Autogenerate a name if none is given
            if (name == string.Empty)
                Name = "Scene" + string.Format("{0:00}", _created);
        }

        #endregion
    }
}
