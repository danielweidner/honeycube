#region Using Statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HoneyCube.Editor.Inspector;

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
        /// Indicates whether the project is loaded successfully.
        /// </summary>
        bool Loaded
        {
            get;
        }

        /// <summary>
        /// Indicates whether the project has unsaved changes.
        /// </summary>
        bool Dirty
        {
            get;
        }

        /// <summary>
        /// A human readable name for the current project.
        /// </summary>
        string Name
        {
            get;
        }

        /// <summary>
        /// A collection of scenes currently edited by the user.
        /// </summary>
        IList<IScene> Scenes
        {
            get;
        }

        /// <summary>
        /// Creates a new project with the given name.
        /// </summary>
        /// <param name="name">Name of the project.</param>
        void CreateProject(string name);

        /// <summary>
        /// Loads a project from a file on disc.
        /// </summary>
        /// <param name="path">Path of the project file.</param>
        /// <returns>True if saved successfully.</returns>
        bool LoadProject(string path);

        /// <summary>
        /// Saves the current project to a file.
        /// </summary>
        /// <param name="path">File path.</param>
        /// <returns>True if saved successfully.</returns>
        bool SaveProject(string path);

        /// <summary>
        /// Closes the current project.
        /// </summary>
        void CloseProject();

        /// <summary>
        /// Creates a new scene object that can be edited by the user.
        /// </summary>
        /// <returns>Created scene object.</returns>
        IScene CreateScene();

        /// <summary>
        /// Removes a given scene from the current project.
        /// </summary>
        /// <param name="scene">Scene to remove.</param>
        /// <returns>True if the scene was successfully removed.</returns>
        bool RemoveScene(IScene scene);

        /// <summary>
        /// Loads a saved scene from a file on disc.
        /// </summary>
        /// <param name="path">Path to the saved scene file.</param>
        /// <returns>Loaded scene object.</returns>
        IScene LoadScene(string path);
    }
}
