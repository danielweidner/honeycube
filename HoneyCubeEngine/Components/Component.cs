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
    /// A generic game component that mimics the interface of 
    /// <see cref="XNA.Framework.GameComponent"/> but without an
    /// dependency for the Game class.
    /// </summary>
    public class Component : IGameComponent, IUpdateable
    {
        #region Fields

        private bool _enabled;
        private int _updateOrder;

        #endregion

        #region Properties

        /// <summary>
        /// Determines whether the current component is enabled and therefor
        /// included in the update cycle.
        /// </summary>
        public bool Enabled
        {
            get { return _enabled; }
            set 
            {
                if (_enabled != value)
                {
                    _enabled = value;
                    OnEnabledChanged();
                }
            }
        }

        /// <summary>
        /// Determines the order in which enabled components are updated.
        /// </summary>
        public int UpdateOrder
        {
            get { return _updateOrder; }
            set
            {
                if (_updateOrder != value)
                {
                    _updateOrder = value;
                    OnUpdateOrderChanged();
                }
            }
        }

        #endregion

        #region Events

        /// <summary>
        /// Is triggered when the value of the enabled property changes.
        /// </summary>
        public event EventHandler<EventArgs> EnabledChanged;

        /// <summary>
        /// Is triggered when the value of the update order property changes.
        /// </summary>
        public event EventHandler<EventArgs> UpdateOrderChanged;

        #endregion

        #region Constructor

        /// <summary>
        /// Public constructor. Creates a generic component.
        /// </summary>
        public Component()
        {
            _enabled = true;
        }

        #endregion

        #region IGameComponent

        /// <summary>
        /// Allows the game component to initialize itself.
        /// </summary>
        public virtual void Initialize()
        {
            // Empty
        }

        #endregion

        #region IUpdateable

        /// <summary>
        /// Called when the component needs to update its state.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of the game time.</param>
        public virtual void Update(GameTime gameTime)
        {
            // Empty
        }

        #endregion

        #region Event Handler

        /// <summary>
        /// Is raised when the enabled property changes. Fires the 
        /// corresponding event.
        /// </summary>
        protected virtual void OnEnabledChanged()
        {
            if (EnabledChanged != null)
                EnabledChanged(this, EventArgs.Empty);
        }

        /// <summary>
        /// Is raised when the update order changes. Fires the corresponding 
        /// event.
        /// </summary>
        protected virtual void OnUpdateOrderChanged()
        {
            if (UpdateOrderChanged != null)
                UpdateOrderChanged(this, EventArgs.Empty);
        }

        #endregion
    }
}
