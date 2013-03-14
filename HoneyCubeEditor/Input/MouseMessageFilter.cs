#region Using Statements

using System.Windows.Forms;



#endregion

namespace HoneyCube.Editor.Input
{
    /// <summary>
    /// Allows the application to register for the message stream of the 
    /// current application. Queries for mouse events only and provides 
    /// hooks for easy event registration.
    /// 
    /// Unfortunatly input events in Windows Forms (contrary to WPF) do 
    /// not bubble up the hierarchy to parent controls, thus we have to 
    /// query those mouse events on our own.
    /// </summary>
    public class MouseMessageFilter : IMouseEventPublisher, IMessageFilter
    {
        /// <summary>
        /// Enumerates available mouse events. Allows to translate the 
        /// abstract message codes of the message stream to a more 
        /// readable format.
        /// 
        /// <see cref="http://www.bobpowell.net/enums.aspx"/> for a full list 
        /// of available values and their meaning.
        /// </summary>
        enum MouseFilterEvents : int
        {
            Move            = 0x0200, // 512

            LButtonDown     = 0x0201, // 513
            LButtonUp       = 0x0202, // 514
            LButtonDbClick  = 0x0203, // 515

            RButtonDown     = 0x0204, // 516
            RButtonUp       = 0x0205, // 517
            RButtonDbClick  = 0x0206, // 518

            MButtonDown     = 0x0207, // 519
            MButtonUp       = 0x0208, // 520
            MButtonDbClick  = 0x0209, // 521

            MouseWheel      = 0x020A, // 522

            Enter           = 0x02A1, // 673
            Leave           = 0x02A2  // 674
        }

        #region Events

        /// <summary>
        /// Is raised everytime a mouse is pressed within the boundaries of the 
        /// application window.
        /// </summary>
        public event MouseEventHandler MouseDown;

        /// <summary>
        /// Is raised everytime a mouse is released within the boundaries of the 
        /// application window.
        /// </summary>
        public event MouseEventHandler MouseUp;

        #endregion

        #region Constructor

        /// <summary>
        /// Public constructor. Creates a new message filter and listens especially 
        /// for mouse events.
        /// </summary>
        public MouseMessageFilter()
        {
            // Empty
        }

        #endregion

        #region IMessageFilter Members

        /// <summary>
        /// Filters messages before they are actually send to the application.
        /// </summary>
        /// <param name="m">The message send to the application.</param>
        /// <returns>Return false to allow the application to handle the message. Return true to hide the message from the application.</returns>
        public bool PreFilterMessage(ref Message m)
        {
            switch ((MouseFilterEvents)m.Msg)
            {
                case MouseFilterEvents.LButtonDown:
                    OnMouseDown(new MouseEventArgs(
                        MouseButtons.Left,                      // Button
                        1,                                      // Number of Clicks
                        Cursor.Position.X, Cursor.Position.Y,   // Position
                        0                                       // Scroll Ticks
                    ));
                    break;

                case MouseFilterEvents.LButtonUp:
                    OnMouseUp(new MouseEventArgs(
                        MouseButtons.Left,                      // Button
                        1,                                      // Number of Clicks
                        Cursor.Position.X, Cursor.Position.Y,   // Position
                        0                                       // Scroll Ticks
                    ));
                    break;
            }
            
            return false;
        }

        #endregion

        #region Event Handler

        /// <summary>
        /// Is called everytime a mouse down message is received.
        /// </summary>
        /// <param name="e">Some event arguments to pass to subscribers.</param>
        protected virtual void OnMouseDown(MouseEventArgs e)
        {
            if (MouseDown != null)
                MouseDown(this, e);
        }

        /// <summary>
        /// Is called everytime a mouse up message is received.
        /// </summary>
        /// <param name="e">Some event arguments to pass to subscribers.</param>
        protected virtual void OnMouseUp(MouseEventArgs e)
        {
            if (MouseUp != null)
                MouseUp(this, e);
        }

        #endregion
    }
}
