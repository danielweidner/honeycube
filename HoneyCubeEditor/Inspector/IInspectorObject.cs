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
    /// Interface that describes a generic wrapper for objects to display in
    /// the applications object inspector.
    /// </summary>
    public interface IInspectorObject : INotifyPropertyChanged
    {
        /// <summary>
        /// Gets or sets the object to display in the inspector.
        /// </summary>
        [Browsable(false)]
        object WrappedObject
        {
            get;
            set;
        }

        /// <summary>
        /// Get the type of the object to display in the inspector
        /// </summary>
        [Browsable(false)]
        Type WrappedObjectType
        {
            get;
        }
    }
}
