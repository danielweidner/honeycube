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
    /// TODO
    /// </summary>
    public interface ISceneViewPresenter : IPresenter<ISceneView>
    {
        /// <summary>
        /// TODO
        /// </summary>
        ICamera Camera
        {
            get;
        }
    }
}
