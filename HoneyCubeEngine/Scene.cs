#region Using Statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#endregion

namespace HoneyCube
{
    /// <summary>
    /// TODO
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
        public Scene()
        {
            _created++;

            Name = "Scene" + string.Format("{0:00}", _created);
        }

        /// <summary>
        /// Public constructor. Creates a new game scene.
        /// </summary>
        /// <param name="name">A human readable name for the scene.</param>
        public Scene(string name)
        {
            _created++;

            Name = name;
        }

        #endregion
    }
}
