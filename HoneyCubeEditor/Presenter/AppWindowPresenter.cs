#region Using Statements

using System.Windows.Forms;
using HoneyCube.Editor.Events;
using HoneyCube.Editor.Views;
using HoneyCube.Editor.Input;
using HoneyCube.Editor.Commands;
using HoneyCube.Editor.Events.Scene;
using HoneyCube.Editor.Services;
using HoneyCube.Editor.Inspector;
using System.ComponentModel;
using System.Collections.Generic;

#endregion

namespace HoneyCube.Editor.Presenter
{
    /// <summary>
    /// The AppWindowPresenter is controlling the main window of the application.
    /// Most of the time it will simply delegate the commands to interested 
    /// submodules.
    /// </summary>
    public class AppWindowPresenter : IAppWindowPresenter, IEventHandler<SceneCreatedEvent>, IEventHandler<SceneRemovedEvent>, IEventHandler<SceneNameChangedEvent>
    {
        #region Fields

        private Dictionary<IScene, ISceneView> _scenes;
        private IAppWindow _view;

        private IAppHub _hub;
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
        /// <param name="view">The view to maintain.</param>
        /// <param name="hub">A reference to the application hub.</param>
        /// <param name="commands">A command map that associates string identifiers or key shortcuts to specific commands.</param>
        public AppWindowPresenter(IAppWindow view, IAppHub hub, ICommandMap commands)
        {
            _view = view;
            _view.Presenter = this;
            _scenes = new Dictionary<IScene, ISceneView>();

            _hub = hub;
            _commands = commands;
        }

        #endregion

        /// <summary>
        /// Tries to retrieve a scene view for the given scene name.
        /// </summary>
        /// <param name="name">Name of the scene.</param>
        /// <returns>A reference to the associated scene view if available.</returns>
        protected ISceneView TryGetView(string name)
        {
            foreach (KeyValuePair<IScene, ISceneView> pair in _scenes)
                if (pair.Key.Name.Equals(name))
                    return pair.Value;

            return null;
        }

        /// <summary>
        /// Tries to retrieve a scene view for the given scene.
        /// </summary>
        /// <param name="scene">The scene to get a view for.</param>
        /// <returns>A reference to the associated scene view if available.</returns>
        protected ISceneView TryGetView(IScene scene)
        {
            ISceneView view = null;
            _scenes.TryGetValue(scene, out view);
            return view;
        }

        #region IAppWindowPresenter

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
        /// Is called every time a user clicks the tab of the welcome page.
        /// </summary>
        /// <param name="button">Indicates which mouse button was used by the user.</param>
        public void WelcomePageClicked(MouseButtons button)
        {
            if (button == MouseButtons.Middle)
                View.HideWelcomePage();
        }

        /// <summary>
        /// Is called every time a user clicks the tab of the scene view.
        /// </summary>
        /// <param name="sceneView">The scene view clicked.</param>
        /// <param name="button">Indicates which mouse button was used by the user.</param>
        public void SceneViewClicked(ISceneView sceneView, MouseButtons button)
        {
            if (button == MouseButtons.Middle)
                sceneView.Close();
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
                View.Close();
        }

        #endregion

        #region Event Handler

        /// <summary>
        /// Is raised when a new scene is added to the current project.
        /// </summary>
        /// <param name="args">Some event arguments.</param>
        public void HandleApplicationEvent(SceneCreatedEvent args)
        {
            IScene scene = args.Scene;
            ISceneView sceneView = TryGetView(args.Scene);

            // Create and register a view if it does not already exist
            if (sceneView == null)
            {
                sceneView = new SceneView(scene);
                _scenes.Add(scene, sceneView);
            }

            _view.ShowScene(sceneView);
        }

        /// <summary>
        /// Is raised when a scene changes its name.
        /// </summary>
        /// <param name="args">Some event arguments.</param>
        public void HandleApplicationEvent(SceneNameChangedEvent args)
        {
            ISceneView sceneView = TryGetView(args.Scene);

            if (sceneView != null)
                _view.UpdateScene(sceneView);
        }

        /// <summary>
        /// Is raised when a new scene is removed from the current project.
        /// </summary>
        /// <param name="args">Some event arguments.</param>
        public void HandleApplicationEvent(SceneRemovedEvent args)
        {
            IScene scene = args.Scene;
            ISceneView sceneView = TryGetView(scene);

            if (sceneView != null)
            {
                _scenes.Remove(scene);
                _view.HideScene(sceneView);
            }
        }

        #endregion
    }
}
