#region Using Statements

using System.Windows.Forms;

#endregion

namespace HoneyCube.Editor.Input
{
    /// <summary>
    /// A simple interface that provides hooks for MouseEvent registration.
    /// </summary>
    public interface IMouseEventPublisher
    {
        /// <summary>
        /// Is raised everytime a mouse is pressed within the boundaries of the 
        /// application window.
        /// </summary>
        event MouseEventHandler MouseDown;

        /// <summary>
        /// Is raised everytime a mouse is released within the boundaries of the 
        /// application window.
        /// </summary>
        event MouseEventHandler MouseUp;
    }
}
