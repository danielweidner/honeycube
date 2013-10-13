#region Using Statements

using System;
using System.Globalization;
using HoneyCube.Components;

#endregion

namespace HoneyCube
{
    /// <summary>
    /// An Entity is a unified game object instance that can be identified by a 
    /// unique id. The overall functionality of an entity is composed by its 
    /// components.
    /// </summary>
    public class Entity : EntityComponentCollection, IEntity
    {
        #region Fields

        private static int _totalNumberOfEntities = 0;
        private int _id;
        private string _name;
        private string _tag;

        private IScene _scene;
        private TransformComponent _transform;

        #endregion

        #region Properties

        /// <summary>
        /// The unique id of the entity.
        /// </summary>
        public int Id
        {
            get { return _id; }
        }

        /// <summary>
        /// A human readable name for the entity. Defaults to string.Empty if
        /// not specified.
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// A tag value that can be assigned to the entity. E.g. this can be 
        /// useful to query for a group of entities sharing the same tag value.
        /// </summary>
        public string Tag
        {
            get { return _tag; }
            set { _tag = value; }
        }

        /// <summary>
        /// Every entity should be assigned to a scene which from the concept 
        /// represents the current game world. The Scene maintains and updates
        /// all entities and its components.
        /// </summary>
        public IScene Scene
        {
            get { return _scene; }
            internal set { _scene = value; }
        }

        /// <summary>
        /// A transformation component which allows to position the current 
        /// entity within 3d space (relative to its parent).
        /// </summary>
        public TransformComponent Transform
        {
            get
            {
                // Cache the transformation component as it will be used quite 
                // often in most cases
                if (_transform == null)
                    _transform = GetComponent<TransformComponent>();

                return _transform;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Public constructor. Creates a new entity.
        /// </summary>
        public Entity()
        {
            _id = _totalNumberOfEntities++;
            _name = string.Empty;
            _tag = string.Empty;
        }

        /// <summary>
        /// Public constructor. Creates a new entity with the specified name.
        /// </summary>
        /// <param name="name">The name of the entity.</param>
        public Entity(string name)
        {
            _id = _totalNumberOfEntities++;
            _name = name;
            _tag = string.Empty;
        }

        #endregion

        #region Object Members

        /// <summary>
        /// Returns an hash code value for the current collection.
        /// </summary>
        /// <returns>The hash code value.</returns>
        public override int GetHashCode()
        {
            return _id;
        }

        /// <summary>
        /// Converts the current entity to a string representation.
        /// </summary>
        /// <returns>The current entity as string value.</returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture,
                "{Id: {0} Name: {1} Tag: {2}}",
                new object[] { Id.ToString(), Name, Tag });
        }

        #endregion
    }
}
