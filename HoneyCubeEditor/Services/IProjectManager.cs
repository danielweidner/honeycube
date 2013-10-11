#region Using Statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#endregion

namespace HoneyCube.Editor.Services
{
    /// <summary>
    /// A generic interface for a project manager maintaining all loaded and
    /// created scene instances of the user.
    /// </summary>
    public interface IProjectManager
    {
        /// <summary>
        /// The scene currently loaded and modified by the user.
        /// </summary>
        IScene CurrentScene
        {
            get;
        }

        /// <summary>
        /// Creates a new scene using the default values and uses it as the 
        /// current scene the user is working on.
        /// </summary>
        void CreateNewScene();

        /// <summary>
        /// Closes the currently loaded scene and releases all its resources.
        /// </summary>
        void CloseCurrentScene();
    }
}
