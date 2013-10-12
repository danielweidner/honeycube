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
    /// A wrapper for scene objects. The wrapper allows to display a scene
    /// properly in the inspector without the need to modify the actual
    /// engine classes.
    /// </summary>
    public class SceneContainer : InspectorObject<IScene>
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
            set 
            {
                if (WrappedObject.Name != value)
                {
                    WrappedObject.Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Public constructor. Creates a wrapper for a scene to display
        /// the object properly in the ObjectInspector.
        /// </summary>
        /// <param name="scene">Scene to display in the ObjectInspector.</param>
        public SceneContainer(IScene scene)
        {
            WrappedObject = scene;
        }

        #endregion
    }
}
