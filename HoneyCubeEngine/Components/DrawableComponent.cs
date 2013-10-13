#region Using Statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

#endregion

namespace HoneyCube.Components
{
    /// <summary>
    /// A generic drawable game component that mimics the interface of 
    /// <see cref="XNA.Framework.DrawableGameComponent"/> but without an
    /// dependency for the Game class.
    /// </summary>
    public class DrawableComponent : Component, IDrawable
    {
        #region Fields

        private bool _visible;
        private int _drawOrder;

        #endregion

        #region Properties

        /// <summary>
        /// Determines whether the component is included in the rendering loop.
        /// </summary>
        public bool Visible
        {
            get { return _visible; }
            set
            {
                if (_visible != value)
                {
                    _visible = value;
                    OnVisibleChanged();
                }
            }
        }

        /// <summary>
        /// Determines the order in which 
        /// </summary>
        public int DrawOrder
        {
            get { return _drawOrder; }
            set
            {
                if (_drawOrder != value)
                {
                    _drawOrder = value;
                    OnDrawOrderChanged();
                }
            }
        }

        #endregion

        #region Events

        /// <summary>
        /// Is triggered when the draw order changes.
        /// </summary>
        public event EventHandler<EventArgs> DrawOrderChanged;

        /// <summary>
        /// Is triggered when the visible property changes.
        /// </summary>
        public event EventHandler<EventArgs> VisibleChanged;

        #endregion

        #region Constructor

        /// <summary>
        /// Public constructor. Initializes a new drawable component.
        /// </summary>
        public DrawableComponent()
        {
            _visible = true;
        }

        #endregion

        #region IDrawable

        /// <summary>
        /// Is called when the component needs to draw itself.
        /// </summary>
        /// <param name="gameTime">Snapshot of the game time.</param>
        public virtual void Draw(GameTime gameTime)
        {
            // Empty
        }

        #endregion

        #region Event Handler

        /// <summary>
        /// Is raised when the visible property changes. Fires the 
        /// corresponding event.
        /// </summary>
        private void OnVisibleChanged()
        {
            if (VisibleChanged != null)
                VisibleChanged(this, EventArgs.Empty);
        }

        /// <summary>
        /// Is raised when the draw order changes. Fires the corresponding 
        /// event.
        /// </summary>
        private void OnDrawOrderChanged()
        {
            if (DrawOrderChanged != null)
                DrawOrderChanged(this, EventArgs.Empty);
        }

        #endregion
    }
}
