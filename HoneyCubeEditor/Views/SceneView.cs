#region Using Statements

using System;
using System.Drawing;
using System.Windows.Forms;
using HoneyCube.Editor.Presenter;
using HoneyCube.Editor.Services;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Color = System.Drawing.Color;
using Xna = Microsoft.Xna.Framework;

#endregion

namespace HoneyCube.Editor.Views
{
    /// <summary>
    /// A custom control that uses the XNA GraphicsDevice to render a scene
    /// onto a TabPage control element.
    /// </summary>
    public partial class SceneView : TabPage, ISceneView
    {
        #region Fields

        /// <summary>
        /// The scene displayed by the current view.
        /// </summary>
        private IScene _scene;

        /// <summary>
        /// A reference to the graphics device service maintaining the unique
        /// graphics device instance.
        /// </summary>
        private GraphicsDeviceService _graphicsDeviceService;

        /// <summary>
        /// The background color of the backbuffer (CornflowerBlue by default).
        /// </summary>
        private Xna.Color _backgroundColor = Xna.Color.CornflowerBlue;

        #endregion

        #region Properties

        /// <summary>
        /// Returns the scene associated with the current view.
        /// </summary>
        public IScene Scene
        {
            get { return _scene; }
        }

        /// <summary>
        /// Holds a reference to the associated presenter which controlls the 
        /// overall behavior of the SceneView.
        /// </summary>
        public ISceneViewPresenter Presenter
        {
            get;
            set;
        }

        /// <summary>
        /// Get a reference to the currently used graphics device.
        /// </summary>
        public GraphicsDevice GraphicsDevice
        {
            get { return _graphicsDeviceService.GraphicsDevice; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Public constructor. Creates a scene view that is able to render
        /// all scene entities in a custom graphics control.
        /// </summary>
        /// <param name="scene">Scene to render.</param>
        public SceneView(IScene scene)
        {
            InitializeComponent();

            _scene = scene;

            Name = scene.Name;
            Text = scene.Name;
        }

        #endregion

        #region Initialization

        /// <summary>
        /// Initializes the control. Retrieves a reference to the graphics device.
        /// </summary>
        protected override void OnCreateControl()
        {
            if (!DesignMode)
            {
                _graphicsDeviceService = GraphicsDeviceService.GetInstance(Handle, ClientSize.Width, ClientSize.Height);

                Initialize();
            }

            base.OnCreateControl();
        }

        /// <summary>
        /// Allows derived classes to run initialization routines when the 
        /// control element is created.
        /// </summary>
        protected virtual void Initialize()
        {
            _backgroundColor = new Xna.Color(BackColor.R, BackColor.G, BackColor.B);
        }

        #endregion

        #region Draw

        /// <summary>
        /// Is called every time the form element should be repainted.
        /// </summary>
        /// <param name="e">Holds information about the area that should be redrawn.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            string error = BeginDraw();

            if (string.IsNullOrEmpty(error))
            {
                Draw();
                EndDraw();
            }
            else
            {
                DrawFallback(e.Graphics, error);
            }
        }

        /// <summary>
        /// Tries to draw the current control element if everything is setup 
        /// correctly.
        /// </summary>
        /// <returns>
        /// Returns an error message, if the graphics device is not setup 
        /// correctly. Otherwise null.
        /// </returns>
        private string BeginDraw()
        {
            // Should only occur if we are in the Windows Form Designer
            if (_graphicsDeviceService == null)
                return "No Preview available in DesignMode\n" + Text + " (" + GetType().Name + ")";

            // Ensure that the graphics device is big enough
            string error = ResetBackBuffer();

            // Stop drawing if the device is not setup properly
            if (!string.IsNullOrEmpty(error))
                return error;

            // We adjust the graphics device viewport to avoid stretching as 
            // the back buffer size fits the largest control
            Viewport viewport = new Viewport(0, 0, ClientSize.Width, ClientSize.Height);
            viewport.MinDepth = 0;
            viewport.MaxDepth = 1;
            GraphicsDevice.Viewport = viewport;

            // Everything was set up correctly.
            return null;
        }

        /// <summary>
        /// Allow deriving classes to perform some draw operations.
        /// </summary>
        protected virtual void Draw()
        {
            GraphicsDevice.Clear(_backgroundColor);
        }

        /// <summary>
        /// Allows to draw text messages, even if we do not have a proper 
        /// reference to the graphics device. Uses the default methods provided
        /// by the System.Drawing namespace.
        /// </summary>
        /// <param name="graphics">An abstraction layer for the GDI+ drawing surface.</param>
        /// <param name="text">The text message to draw on the control.</param>
        protected virtual void DrawFallback(System.Drawing.Graphics graphics, string text)
        {
            graphics.Clear(BackColor);

            using (Brush brush = new SolidBrush(ForeColor))
            {
                using (StringFormat format = new StringFormat())
                {
                    format.Alignment = StringAlignment.Center;
                    format.LineAlignment = StringAlignment.Center;
                    graphics.DrawString(text, Font, brush, ClientRectangle, format);
                }
            }
        }

        /// <summary>
        /// Ends the drawing process and displays the contents of the back 
        /// buffer on the current control.
        /// </summary>
        private void EndDraw()
        {
            try
            {
                // Display the contents of the back buffer
                Xna.Rectangle source = new Xna.Rectangle(0, 0, ClientRectangle.Width, ClientRectangle.Height);
                GraphicsDevice.Present(source, null, Handle);
            }
            catch
            {
                // Swallow the device lost exception as it gets handled with the
                // next Draw period.
            }
        }

        /// <summary>
        /// The SceneRenderer control needs to ignore the OnPaintBackground event as it 
        /// will lead to undesired flickering due to concurring draw processes (OnPaint
        /// vs Draw).
        /// </summary>
        /// <param name="pevent">Holds information about the area that should be drawn.</param>
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            // Empty
        }

        /// <summary>
        /// Checks whether the back buffer of the graphics device is large 
        /// enough to draw the contents for the current control. Returns an
        /// error message if the device reference is lost or other problems
        /// occured.
        /// </summary>
        /// <returns>An error message. Null if the back buffer is setup properly.</returns>
        private string ResetBackBuffer()
        {
            bool deviceNeedsReset = false;

            switch (GraphicsDevice.GraphicsDeviceStatus)
            {
                case GraphicsDeviceStatus.Lost:
                    // If the graphics device is lost, we cannot use it at all.
                    return "Graphics device lost.";

                case GraphicsDeviceStatus.NotReset:
                    // If device is in the not-reset state, we should try to reset it.
                    deviceNeedsReset = true;
                    break;

                default:
                    // If the device state is ok, check whether it is big enough.
                    PresentationParameters pp = GraphicsDevice.PresentationParameters;
                    deviceNeedsReset = (ClientSize.Width > pp.BackBufferWidth) || (ClientSize.Height > pp.BackBufferHeight);
                    break;
            }

            if (deviceNeedsReset)
            {
                try
                {
                    _graphicsDeviceService.Fit(ClientSize.Width, ClientSize.Height);
                }
                catch (Exception e)
                {
                    return "Could not enlarge the back buffer of the graphics device.\n\n" + e;
                }
            }

            return null;
        }

        #endregion

        #region ISceneView

        /// <summary>
        /// Changes the label used to display the current scene view.
        /// </summary>
        /// <param name="text">Text to display.</param>
        public void UpdateLabel(string text)
        {
            Text = text;
        }

        /// <summary>
        /// Closes the current scene view.
        /// </summary>
        public void Close()
        {
            TabControl tabControl = Parent as TabControl;
            if (tabControl != null)
                tabControl.TabPages.Remove(this);
        }

        #endregion

        #region EventHandler

        /// <summary>
        /// Changes the color of the backbuffer when the background color of
        /// the control is changed.
        /// </summary>
        /// <param name="sender">The control element changed.</param>
        /// <param name="e">Empty event arguments.</param>
        private void SceneViewer_BackColorChanged(object sender, EventArgs e)
        {
            _backgroundColor = new Xna.Color(BackColor.R, BackColor.G, BackColor.B);
        }

        #endregion
    }
}
