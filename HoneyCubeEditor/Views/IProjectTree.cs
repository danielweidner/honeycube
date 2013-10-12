#region Using Statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HoneyCube.Editor.Presenter;
using HoneyCube.Editor.Services;

#endregion

namespace HoneyCube.Editor.Views
{
    /// <summary>
    /// A gerneric interface for a project tree that displays all available
    /// game elements.
    /// </summary>
    public interface IProjectTree : IView<IProjectTreePresenter>
    {
        /// <summary>
        /// Updates the root node of the project tree.
        /// </summary>
        /// <param name="project">Project that has changed.</param>
        void UpdateRoot(IProjectManager project);

        /// <summary>
        /// Updates the node representing the given scene.
        /// </summary>
        /// <param name="scene">Scene node to change.</param>
        void UpdateNode(IScene scene);

        /// <summary>
        /// Updates the hierarchy of the project tree.
        /// </summary>
        /// <param name="scenes">A collection of scenes to display.</param>
        void UpdateHierarchy(IList<IScene> scenes);

        /// <summary>
        /// Resets the project tree to its initial state. Stops the 
        /// project tree from displaying the current project.
        /// </summary>
        void Reset();

        /// <summary>
        /// Enables the project tree to allow user interaction.
        /// </summary>
        void Enable();

        /// <summary>
        /// Disables the project tree and blocks user interaction.
        /// </summary>
        void Disable();
    }
}
