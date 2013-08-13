#region Using Statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using System.Threading;

#endregion

#pragma warning disable 67

namespace HoneyCube.Editor.Services
{
    /// <summary>
    /// A custom implementation of the IGraphicsDeviceService interface. 
    /// Creates and manages the actual GraphicsDevice instance. All form
    /// controls share the same GraphicsDeviceService to ensure there will only
    /// ever be a single underlying GraphicsDevice.
    /// </summary>
    public class GraphicsDeviceService : IGraphicsDeviceService
    {
        #region Singleton

        /// <summary>
        /// A singleton instance.
        /// </summary>
        private static GraphicsDeviceService _instance;

        /// <summary>
        /// Indicates how many controls are sharing the current device instance.
        /// </summary>
        private static int _referenceCount;

        /// <summary>
        /// Get access to the singleton instance.
        /// </summary>
        /// <param name="handle">A pointer to window handle.</param>
        /// <param name="width">The width of the devices back-buffer.</param>
        /// <param name="height">The height of the devices back-buffer.</param>
        /// <returns>A reference to the graphics device service.</returns>
        public static GraphicsDeviceService GetInstance(IntPtr handle, int width, int height)
        {
            // Create a new singleton instance of the graphics device if this is the 
            // first component which wants to perform calculations on the GPU
            if (Interlocked.Increment(ref _referenceCount) == 1)
                _instance = new GraphicsDeviceService(handle, width, height);

            return _instance;
        }

        #endregion

        #region Fields

        /// <summary>
        /// An abstraction layer of the graphics device. Allows to perform 
        /// primitive-based rendering.
        /// </summary>
        private GraphicsDevice _graphicsDevice;

        /// <summary>
        /// Holds the current settings of the graphics device.
        /// </summary>
        private PresentationParameters _parameters;

        #endregion

        #region Events

        // Implements the events of IGraphicsDeviceService
        public event EventHandler<EventArgs> DeviceCreated;
        public event EventHandler<EventArgs> DeviceDisposing;
        public event EventHandler<EventArgs> DeviceReset;
        public event EventHandler<EventArgs> DeviceResetting;

        #endregion

        #region Properties

        /// <summary>
        /// Get a reference to the currently used graphics device.
        /// </summary>
        public GraphicsDevice GraphicsDevice
        {
            get { return _graphicsDevice; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Private constructor. Creates a new instance of GraphicsDeviceService.
        /// </summary>
        /// <param name="handle">A pointer to window handle.</param>
        /// <param name="width">The width of the devices back-buffer.</param>
        /// <param name="height">The height of the devices backbuffer.</param>
        private GraphicsDeviceService(IntPtr handle, int width, int height)
        {
            _parameters = new PresentationParameters();

            // Setup the backbuffer of the graphics device
            _parameters.BackBufferWidth = Math.Max(width, 1);
            _parameters.BackBufferHeight = Math.Min(height, 1);
            _parameters.BackBufferFormat = SurfaceFormat.Color;
            _parameters.DepthStencilFormat = DepthFormat.Depth24;
            _parameters.PresentationInterval = PresentInterval.Immediate;

            // Setup the device window handle
            _parameters.DeviceWindowHandle = handle;
            _parameters.IsFullScreen = false;

            // Setup the graphics device
            _graphicsDevice = new GraphicsDevice(
                                        GraphicsAdapter.DefaultAdapter,
                                        GraphicsProfile.Reach,
                                        _parameters);
        }

        #endregion

        /// <summary>
        /// Forces the back-buffer of the graphics device to fit the given
        /// resolution. Can be used to ensure that the back-buffer is large
        /// enough to handle the dimensions of a new control element.
        /// </summary>
        /// <param name="width">The desired width of the back-buffer.</param>
        /// <param name="height">The desired height of the back-buffer.</param>
        public void Fit(int width, int height)
        {
            if (DeviceResetting != null)
                DeviceResetting(this, EventArgs.Empty);

            _parameters.BackBufferWidth = Math.Max(_parameters.BackBufferWidth, width);
            _parameters.BackBufferHeight = Math.Max(_parameters.BackBufferHeight, height);

            _graphicsDevice.Reset(_parameters);

            if (DeviceReset != null)
                DeviceReset(this, EventArgs.Empty);
        }

        /// <summary>
        /// Releases all resources used by the singleton instance.
        /// </summary>
        /// <param name="disposing">True if managed resources should be disposed.</param>
        public void Release(bool disposing)
        {
            // Ensure that no other control is using the singleton instance any longer
            if (Interlocked.Decrement(ref _referenceCount) == 0)
            {
                if (disposing)
                {
                    if (DeviceDisposing != null)
                        DeviceDisposing(this, EventArgs.Empty);

                    _graphicsDevice.Dispose();
                }
                _graphicsDevice = null;
            }
        }
    }
}

#pragma warning restore 67