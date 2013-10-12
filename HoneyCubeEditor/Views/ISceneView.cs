#region Using Statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HoneyCube.Editor.Presenter;

#endregion

namespace HoneyCube.Editor.Views
{
    /// <summary>
    /// Describes a user interface respresentation of a game scene.
    /// </summary>
    public interface ISceneView : IView<ISceneViewPresenter>
    {
        /// <summary>
        /// Returns the scene associated with the current view.
        /// </summary>
        IScene Scene
        {
            get;
        }

        /// <summary>
        /// Changes the label used to display the current scene view.
        /// </summary>
        /// <param name="text">Text to display.</param>
        void UpdateLabel(string text);

        /// <summary>
        /// Closes the current scene view.
        /// </summary>
        void Close();
    }
}
