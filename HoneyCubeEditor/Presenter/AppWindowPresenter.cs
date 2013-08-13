#region Using Statements

using System.Windows.Forms;
using HoneyCube.Editor.Events;
using HoneyCube.Editor.Views;
using HoneyCube.Editor.Input;
using HoneyCube.Editor.Commands;

#endregion

namespace HoneyCube.Editor.Presenter
{
    /// <summary>
    /// The AppWindowPresenter is controlling the main window of the application.
    /// Most of the time it will simply delegate the commands to interested 
    /// submodules.
    /// </summary>
    public class AppWindowPresenter : IAppWindowPresenter
    {
        #region Fields

        private IAppHub _hub;
        private IAppWindow _view;
        private ICommandMap _commands;

        #endregion

        #region Properties

        /// <summary>
        /// The view holding most of the editors controls.
        /// </summary>
        public IAppWindow View
        {
            get { return _view; }
        }

        /// <summary>
        /// The application hub bundles core functionality for better decoupling.
        /// </summary>
        public IAppHub Hub
        {
            get { return _hub; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Public constructor. Creates a new ApplicationWindowPresenter which
        /// controls the overall behavior of the associated ApplicationWindowView.
        /// </summary>
        /// <param name="hub">A reference to the application hub.</param>
        /// <param name="commands">A command map that associates string identifiers or key shortcuts to specific commands.</param>
        /// <param name="view">The view to maintain.</param>
        public AppWindowPresenter(IAppHub hub, ICommandMap commands, IAppWindow view)
        {
            _hub = hub;
            _commands = commands;

            _view = view;
            _view.Presenter = this;
        }

        #endregion

        #region IAppWindowPresenter Members

        /// <summary>
        /// Handles mouse interaction detected by the application window.
        /// </summary>
        /// <param name="button">The button pressed by the user.</param>
        /// <param name="state">Indicates whether the button is pressed or released by the user.</param>
        /// <param name="timesClicked">Number of times clicked.</param>
        /// <param name="x">The x position of the mouse cursor.</param>
        /// <param name="y">The y position of the mouse cursor.</param>
        /// <param name="modifiers">The modifiers pressed (alt, control, shift).</param>
        public void HandleMouseInput(MouseButtons button, MouseButtonState state, int timesClicked, int x, int y, Keys modifiers)
        {
            // TODO: Handle Mouse Input
        }

        /// <summary>
        /// Handles keyboard input detected by the application window.
        /// </summary>
        /// <param name="keys">The key pressed by the user.</param>
        /// <param name="modifiers">The modifiers pressed (alt, control, shift).</param>
        public void HandleKeyboardInput(Keys key, Keys modifiers)
        {
            _commands.TryToExecute(modifiers | key);
        }

        /// <summary>
        /// Is called every time the user prompts to close the application 
        /// window.
        /// </summary>
        public void CloseRequested()
        {
            var args = new AppClosingEvent();

            // Give application components the chance to cancel the closing event
            _hub.Raise(args);

            // Close the application if not canceled
            if (!args.Canceled)
            {
                Application.Exit();
            }
        }

        #endregion
    }
}
