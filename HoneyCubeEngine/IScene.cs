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
