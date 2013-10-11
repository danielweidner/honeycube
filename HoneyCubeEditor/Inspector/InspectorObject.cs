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
    /// A generic object that wraps an object of a certain type to display it 
    /// properly in the applications object inspector. This way we do not have
    /// to modify the actual classes of the engine.
    /// </summary>
    public abstract class InspectorObject<T> : IInspectorObject
    {
        #region Fields

        private T _wrappedObject;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the object to display in the inspector.
        /// </summary>
        [Browsable(false)]
        public T WrappedObject
        {
            get { return _wrappedObject; }
            set
            {
                // Ensure the given value is supported by our wrapper implementation
                if (value != null && !WrappedObjectType.IsAssignableFrom(value.GetType()))
                    throw new ArgumentException("The given object type is not supported.");

                _wrappedObject = value;
                OnPropertyChanged("WrappedObject");
            }
        }

        /// <summary>
        /// Gets or sets the object to display in the inspector.
        /// </summary>
        [Browsable(false)]
        object IInspectorObject.WrappedObject
        {
            get { return WrappedObject; }
            set { WrappedObject = (T)value; }
        }

        /// <summary>
        /// Get the type of the object to display in the inspector
        /// </summary>
        [Browsable(false)]
        public Type WrappedObjectType
        {
            get { return typeof(T); }
        }

        #endregion

        #region Events

        /// <summary>
        /// Notifies event handlers about changes to object properties.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        /// <summary>
        /// Should be called whenever a property of the current object changes.
        /// </summary>
        /// <param name="name">Name of the property.</param>
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
