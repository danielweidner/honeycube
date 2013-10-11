#region Using Statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

#endregion

namespace HoneyCube.Editor.Inspector
{
    /// <summary>
    /// TODO
    /// </summary>
    public class SceneWrapper : InspectorObject<IScene>
    {
        #region Properties

        /// <summary>
        ///  A human readable name for the current scene (not necessarily unique).
        /// </summary>
        [Category("General")]
        [Description("A human readable name for the current scene.")]
        public string Name
        {
            get { return WrappedObject.Name; }
            set { WrappedObject.Name = value; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="scene"></param>
        public SceneWrapper(IScene scene)
        {
            WrappedObject = scene;
        }

        #endregion
    }
}
