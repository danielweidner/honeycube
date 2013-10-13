#region Using Statements

using System;
using System.Globalization;
using System.Threading;
using Microsoft.Xna.Framework;

#endregion

namespace HoneyCube.Components
{
    /// <summary>
    /// An EntityComponent represents a certain behavior or property of the 
    /// entity. By composing several EntityComponents you can create totally
    /// new kinds of entities.
    /// </summary>
    public abstract class EntityComponent : Component, IEntityComponent, IDisposable
    {
        #region Fields

        private static int _totalNumberOfComponents = 0;

        private int _id;
        private string _name;
        private string _tag;

        private bool _initialized;
        private bool _started;

        private Entity _entity;

        #endregion

        #region Properties

        /// <summary>
        /// The unique id of the entity component.
        /// </summary>
        public int Id
        {
            get { return _id; }
        }

        /// <summary>
        /// The human readable name of the current component. Is not 
        /// necessarily unique!
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// A tag value that can be assigned to the current component. E.g. this 
        /// can be useful to query for a group of components sharing the same
        /// tag value.
        /// </summary>
        public string Tag
        {
            get { return _tag; }
            set { _tag = value; }
        }

        /// <summary>
        /// Indicates whether the current component is already initialized.
        /// </summary>
        public bool Initialized
        {
            get { return _initialized; }
            protected set { _initialized = value; }
        }

        /// <summary>
        /// Indicates whether the current component has been started already.
        /// </summary>
        public bool Started
        {
            get { return _started; }
            protected set { _started = value; }
        }

        /// <summary>
        /// The the current component is attached to.
        /// </summary>
        public Entity Entity
        {
            get { return _entity; }
            internal set { _entity = value; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Public constructor. Creates a new component.
        /// </summary>
        public EntityComponent() : this(string.Empty)
        {
            // Empty
        }

        /// <summary>
        /// Public constructor. Creates a new component.
        /// </summary>
        /// <param name="name">A name for the component.</param>
        public EntityComponent(string name) : base()
        {
            _id = _totalNumberOfComponents++;
            _name = name;
            _tag = string.Empty;
        }

        #endregion

        #region IEntityComponent

        /// <summary>
        /// Allows to initialize all properties of the component is called after
        /// the creation of the object instance.
        /// </summary>
        public override void Initialize()
        {
            _initialized = true;
        }

        /// <summary>
        /// Is called once before the first call of Update(). As an example it 
        /// could be used to query for components.
        /// </summary>
        public virtual void Start()
        {
            _started = true;
        }

        #endregion

        #region Object Members

        /// <summary>
        /// Converts the current component to a string representation.
        /// </summary>
        /// <returns>The current entity as string value.</returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture,
                "{Type: {0} Name: {1} Tag: {2}}",
                new object[] { GetType().Name, Name, Tag });
        }

        #endregion

        #region IDisposable

        /// <summary>
        /// Destructor.
        /// </summary>
        ~EntityComponent()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// Allows to dispose the current component.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// The actual worker method. Determines whether dispose has been called 
        /// by the finalizer or by the user. Will allow to clean up the component.
        /// </summary>
        /// <param name="userInitiated">Indicates whether dispose was called by the finalizer (false) or the user (true).</param>
        public virtual void Dispose(bool userInitiated)
        {
            if (userInitiated)
            {
                // Tracks whether we could lock the object instance
                bool lockTaken = false;

                try
                {
                    // Try to lock the current component instance
                    Monitor.Enter(this, ref lockTaken);

                    // Remove the current component from the entity
                    if (Entity != null)
                        Entity.RemoveComponent(this);
                }
                finally
                {
                    // If we have locked the current instance, we need to 
                    // release it
                    if (lockTaken) Monitor.Exit(this);
                }
            }
        }

        #endregion
    }
}
