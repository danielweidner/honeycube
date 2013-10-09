#region Using Statements

using System.Windows.Forms;
using HoneyCube.Editor.Input;
using HoneyCube.Editor.Views;

#endregion

namespace HoneyCube.Editor.Presenter
{
    /// <summary>
    /// The IAppWindowPresenter interface describes a presenter which controls
    /// the behavior of the main application window.
    /// </summary>
    public interface IAppWindowPresenter : IPresenter<IAppWindow>
    {
        /// <summary>
        /// Handles mouse interaction detected by the application window.
        /// </summary>
        /// <param name="button">The button pressed by the user.</param>
        /// <param name="state">Indicates whether the button is pressed or released by the user.</param>
        /// <param name="timesClicked">Number of times clicked.</param>
        /// <param name="x">The x position of the mouse cursor.</param>
        /// <param name="y">The y position of the mouse cursor.</param>
        /// <param name="modifiers">The modifiers pressed (alt, control, shift).</param>
        void HandleMouseInput(MouseButtons button, MouseButtonState state, int timesClicked, int x, int y, Keys modifiers);

        /// <summary>
        /// Handles keyboard input detected by the application window.
        /// </summary>
        /// <param name="keys">The key pressed by the user.</param>
        /// <param name="modifiers">The modifiers pressed (alt, control, shift).</param>
        void HandleKeyboardInput(Keys key, Keys modifiers);

        /// <summary>
        /// Is called every time a user clicks the tab of the welcome page.
        /// </summary>
        /// <param name="button">Indicates which mouse button was used by the user.</param>
        void WelcomePageClicked(MouseButtons button);

        /// <summary>
        /// Is called every time a user clicks the tab of the scene view.
        /// </summary>
        /// <param name="view">The scene view clicked.</param>
        /// <param name="button">Indicates which mouse button was used by the user.</param>
        void SceneViewClicked(ISceneView view, MouseButtons button);

        /// <summary>
        /// Tells the presenter that a close for the current view has been 
        /// requested.
        /// </summary>
        void CloseRequested();
    }
}
