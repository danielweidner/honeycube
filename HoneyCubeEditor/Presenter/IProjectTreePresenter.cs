#region Using Statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HoneyCube.Editor.Views;

#endregion

namespace HoneyCube.Editor.Presenter
{
    /// <summary>
    /// Controls the behavior of the ProjectTree view.
    /// </summary>
    public interface IProjectTreePresenter : IPresenter<IProjectTree>
    {
        /// <summary>
        /// Instructs the presenter to handle a node selection.
        /// </summary>
        /// <param name="scene">Scene selected.</param>
        void HandleSceneSelection(IScene scene);
    }
}
