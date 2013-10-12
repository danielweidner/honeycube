#region Using Statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HoneyCube.Editor.Presenter;
using HoneyCube.Editor.Inspector;

#endregion

namespace HoneyCube.Editor.Views
{
    /// <summary>
    /// IObjectInspector describes a control that allows the user to modify 
    /// object properties.
    /// </summary>
    public interface IObjectInspector : IView<IInspectorPresenter>
    {
        /// <summary>
        /// Displays the specified object and all its public properties in the
        /// inspector.
        /// </summary>
        /// <param name="obj">The object to display.</param>
        void Show(IInspectorObject obj);

        /// <summary>
        /// Resets the object inspector to its initial state. Stops the 
        /// inspector from displaying the currently selected object.
        /// </summary>
        void Reset();

        /// <summary>
        /// Enables the inspector to allow user interaction.
        /// </summary>
        void Enable();

        /// <summary>
        /// Disables the inspector and blocks user interaction.
        /// </summary>
        void Disable();
    }
}
