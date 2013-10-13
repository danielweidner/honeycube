#region Using Statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Microsoft.Xna.Framework;
using HoneyCube.Components;

#endregion

namespace HoneyCube
{
    /// <summary>
    /// The Scene game component makes life easier. It maintains all entities
    /// which are added to the internal collections of the component. 
    /// Furthermore it allows to easily query for game objects mostly at the 
    /// cost of a simple dictionary look-up. Just add the game component to
    /// your game instance and register your entities using AddEntity().
    /// </summary>
    /// <remarks>
    /// TODO: Implement an EntityFactory. The scene should hold a reference to
    /// such a factory. The Factory should allow to load entities from a template
    /// file.
    /// </remarks>
    public class Scene : DrawableComponent, IScene, IEnumerable<Entity>
    {
        #region Fields

        private static int _totalNumberOfScenes = 0;

        private bool _initialized;

        private List<Entity> _entities;
        private Queue<Entity> _entitiesToAdd;
        private Queue<Entity> _entitiesToRemove;
        private Dictionary<int, Entity> _idMap;
        private Dictionary<string, List<Entity>> _nameMap;

        #endregion

        #region Indexer

        /// <summary>
        /// Returns the entity at the specified index position.
        /// </summary>
        /// <param name="i">The index position of the entity to retrieve.</param>
        /// <returns>A reference to the entity.</returns>
        public Entity this[int i]
        {
            get { return _entities[i]; }
        }

        #endregion

        #region Properties

        /// <summary>
        /// A human readable name for the current scene (not necessarily unique).
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// The total number of entities added to the scene.
        /// </summary>
        public int NumberOfEntities
        {
            get { return _entities.Count; }
        }

        /// <summary>
        /// Get or set the active camera which determines the perspective view
        /// on the current scene.
        /// </summary>
        public ICamera Camera
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Public constructor. Creates a new game scene.
        /// </summary>
        public Scene() : this(string.Empty)
        {
            // Empty
        }

        /// <summary>
        /// Public constructor. Creates a new game scene.
        /// </summary>
        /// <param name="name">A human readable name for the scene.</param>
        public Scene(string name)
        {
            _totalNumberOfScenes++;

            Name = name;

            // Autogenerate a name if none is given
            if (name == string.Empty)
                Name = "Scene" + string.Format("{0:00}", _totalNumberOfScenes);

            // Initialize resources
            _entities = new List<Entity>();
            _entitiesToAdd = new Queue<Entity>();
            _entitiesToRemove = new Queue<Entity>();
            _idMap = new Dictionary<int, Entity>();
            _nameMap = new Dictionary<string, List<Entity>>();
        }

        #endregion

        #region Component

        /// <summary>
        /// Allows to initialize non-graphics related scene properties. Will 
        /// query for essential game components.
        /// </summary>
        public override void Initialize()
        {
            _initialized = true;
        }

        #endregion

        #region IScene

        /// <summary>
        /// Adds the specified entity to the scene. Will not add the entity directly 
        /// but within the next update cycle.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        public void AddEntity(Entity entity)
        {
            if (!_entitiesToAdd.Contains(entity))
                _entitiesToAdd.Enqueue(entity);
        }

        /// <summary>
        /// Adds the specified entity to the scene. This is the actual worker method
        /// which will be called on all entities that are waiting for addition. It
        /// ensures that the specified entity is not already maintained by the scene.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <exception cref="T:System.ArgumentException">
        ///     <paramref name="entity"/> is already added to the scene.
        /// </exception>
        private void AddPendingEntity(Entity entity)
        {
            if (!ContainsEntity(entity.Id))
            {
                // Add all components attached to the entity
                if (entity.NumberOfComponents > 0)
                {
                    for (int i = 0, n = entity.NumberOfComponents; i != n; i++)
                        AddEntityComponent(entity[i]);
                }

                // Add the entity to the scene collection
                _entities.Add(entity);

                // Register the component in the name and id map
                AddToNameMap(entity.Name, entity);
                AddToIdMap(entity.Id, entity);

                // Set a reference to the scene component
                entity.Scene = this;
            }
            else
            {
                // Ensure that an entity is just added once
                throw new ArgumentException(
                    "The specified entity was already added to the current scene.");
            }
        }

        /// <summary>
        /// Adds a component to the current scene. Will register the component
        /// so that it will be updated automatically by the scene.
        /// </summary>
        /// <param name="component">The component to register.</param>
        /// <param name="checkForDependencies">Optional boolean that forces the method to check for the availability of dependencies on the component.</param>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="component"/> is null.
        /// </exception>
        /// <remarks>TODO: Ensure that a component is just added once.</remarks>
        private void AddEntityComponent(EntityComponent component, bool checkForDependencies = true)
        {
            if (component == null)
                throw new ArgumentNullException("The specified component is null");

            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates an entry for the entity within the name map. This allows to
        /// query for an entity at the cost of a simple dictionary look-up.
        /// </summary>
        /// <param name="name">The name of the entity to add.</param>
        /// <param name="entity">The entity to add.</param>
        private void AddToNameMap(string name, Entity entity)
        {
            List<Entity> entities;

            // Check whether the specified name is already used
            if (_nameMap.TryGetValue(name, out entities))
            {
                // If the name is already used by another entity, simply 
                // register the second one in the same list.
                entities.Add(entity);
            }
            else
            {
                // Otherwise create a new entry for the name and add the
                // current entity as the first instance
                entities = new List<Entity>();
                entities.Add(entity);
                _nameMap.Add(name, entities);
            }
        }

        /// <summary>
        /// Creates an entry for the entity within the id map. This allows to 
        /// query for an entity at the cost of a simple dictionary look-up.
        /// </summary>
        /// <param name="id">The id of the entity.</param>
        /// <param name="entity">The entity to add.</param>
        private void AddToIdMap(int id, Entity entity)
        {
            _idMap.Add(id, entity);
        }

        /// <summary>
        /// Removes the specified entity and all its components from the scene.
        /// Will not remove the entity directly but more register it for removal.
        /// All registered entities get removed within the next update cycle.
        /// </summary>
        /// <param name="entity">The entity to remove.</param>
        public void RemoveEntity(Entity entity)
        {
            if (!_entitiesToRemove.Contains(entity))
                _entitiesToRemove.Enqueue(entity);
        }

        /// <summary>
        /// Removes the specified entity and all its components from the scene. 
        /// This is the actual worker method which will be called on all entities 
        /// that are waiting for removal. It ensures that the specified entity 
        /// is maintained by the scene before it tries to remove all its resources.
        /// </summary>
        /// <param name="entity">The entity to remove.</param>
        /// <returns>True if the entity has been removed successfully.</returns>
        private bool RemovePendingEntity(Entity entity)
        {
            if (ContainsEntity(entity.Id))
            {
                // Remove all components
                if (entity.NumberOfComponents > 0)
                {
                    for (int i = 0, n = entity.NumberOfComponents; i != n; i++)
                        RemoveEntityComponent(entity[i]);
                }

                // Remove the entity from the general list
                _entities.Remove(entity);

                // Remove the map entries of the entity
                RemoveFromNameMap(entity.Name, entity);
                RemoveFromIdMap(entity.Id);

                // Remove the reference to the scene component
                entity.Scene = this;

                // We have successfully removed all reference from the scene
                return true;
            }

            return false;
        }

        /// <summary>
        /// Removes the component from the current scene. The component will no
        /// longer be updated by the scene.
        /// </summary>
        /// <param name="component">The component to remove.</param>
        private void RemoveEntityComponent(EntityComponent component)
        {
            // TODO: Allow to remove a component from the scene
            // 1. Check whether some other components still depend on the current one
            // 2. Remove the component AND register components which have been dependent on the removed one to the proper list
            // 3. Check whether we have to notify the RenderSystem
            // 4. Let the component clean up itself (?)
            // Problem: What if another component is dependent on the current one?

            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes the entry from the name map.
        /// </summary>
        /// <param name="name">The name the entity is registered as.</param>
        /// <param name="entity">The entity to remove.</param>
        private void RemoveFromNameMap(string name, Entity entity)
        {
            // Retrieve the list of registered entities with that name
            List<Entity> entities;
            if (_nameMap.TryGetValue(name, out entities))
            {
                // Remove the entity from that list
                entities.Remove(entity);

                // Account for the case where this is the last entity 
                // registered 
                if (entities.Count == 0)
                {
                    // Remove the entire entry as no instances use this 
                    // name any longer
                    _nameMap.Remove(name);
                }
            }
        }

        /// <summary>
        /// Removes the entry from the id map.
        /// </summary>
        /// <param name="id">The id of the entity to remove.</param>
        private void RemoveFromIdMap(int id)
        {
            _idMap.Remove(id);
        }

        /// <summary>
        /// Checks whether an entity with the specified name is present in the 
        /// scene. Causes a dictionary look-up.
        /// </summary>
        /// <param name="name">The name of the entity to search for.</param>
        /// <returns>True if an entity with the specified name exists.</returns>
        public bool ContainsEntity(string name)
        {
            return _nameMap.ContainsKey(name);
        }

        /// <summary>
        /// Checks whether an entity with the specified id is present in the
        /// scene. Causes a dictionary look-up.
        /// </summary>
        /// <param name="id">The id of the entity to search for.</param>
        /// <returns>True if the entity with the specified id exists.</returns>
        public bool ContainsEntity(int id)
        {
            return _idMap.ContainsKey(id);
        }

        /// <summary>
        /// Checks whether the specified entity is added to the scene. Causes
        /// a sequential search on the list of available entities [O(1, ..., n/2)].
        /// </summary>
        /// <param name="entity">The entity to search for.</param>
        /// <returns>True if the entity is added to the scene.</returns>
        public bool ContainsEntity(Entity entity)
        {
            return _idMap.ContainsKey(entity.Id);
        }

        /// <summary>
        /// Tries to return the entity with the specified unique identifier.
        /// Returns null if no entity uses the specified id. Causes a dictionary
        /// look-up.
        /// </summary>
        /// <param name="id">The id of the entity to retrieve.</param>
        /// <returns>A reference to the entity. Null if not found.</returns>
        public Entity GetEntityById(int id)
        {
            Entity entity;
            _idMap.TryGetValue(id, out entity);

            return entity;
        }

        /// <summary>
        /// Tries to find an entity with the specified name. Causes a dictionary
        /// look up. Returns only the first appearance of the name.
        /// </summary>
        /// <param name="name">The name of the entity to retrieve.</param>
        /// <returns>A reference to the entity. Null if not found.</returns>
        public Entity GetEntityByName(string name)
        {
            List<Entity> entities;

            // Check whether any entities with the specified name exist
            // Remark: The way we add and remove entities from the map 
            // ensures that all entries have a list with at least one 
            // entry.
            if (_nameMap.TryGetValue(name, out entities))
                return _entities[0];

            return null;
        }

        /// <summary>
        /// Tries to find all entites with the specified name. Causes a 
        /// dictionary look-up. Adds all entities to the specified collection.
        /// </summary>
        /// <param name="name">The name to search for.</param>
        /// <param name="collection">The collection the entites should be added to.</param>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="collection"/> is null.
        /// </exception>
        public void GetAllEntitiesWithName(string name, ICollection<Entity> collection)
        {
            if (collection == null)
                throw new ArgumentNullException("The specified collection is null");

            List<Entity> entities;

            // Check whether any entities with the specified name exist
            // Remark: The way we add and remove entities from the map 
            // ensures that all entries have a list with at least one 
            // entry.
            if (_nameMap.TryGetValue(name, out entities))
            {
                // Look up the entities from the list and add them to
                // the collection
                for (int i = 0, n = entities.Count; i != n; i++)
                    collection.Add(_entities[i]);
            }
        }

        /// <summary>
        /// Tries to find an entity that has the specified component attached.
        /// Will only return the first appearance of an entity using that 
        /// component. Performs a sequential search on all available entities
        /// [O(1, ..., n)].
        /// </summary>
        /// <typeparam name="T">The type of the component.</typeparam>
        /// <returns>A reference to the entity using that component.</returns>
        public Entity GetEntityWith<T>() where T : EntityComponent
        {
            for (int i = 0, n = _entities.Count; i != n; i++)
            {
                // Cache the current entity
                Entity entity = _entities[i];

                // Check whether the entity has the specified component
                if (entity.HasComponent<T>())
                    return entity;
            }

            return null;
        }

        /// <summary>
        /// Tries to find an entity that has the specified component attached.
        /// Will only return the first appearance of an entity using that 
        /// component. Performs a sequential search on all available entities
        /// [O(1, ..., n)].
        /// </summary>
        /// <param name="type">The type of the component.</param>
        /// <returns>A reference to the entity using that component.</returns>
        public Entity GetEntityWith(Type type)
        {
            for (int i = 0, n = _entities.Count; i != n; i++)
            {
                // Cache the current entity
                Entity entity = _entities[i];

                // Check whether the entity has the specified component
                if (entity.HasComponent(type))
                    return entity;
            }

            return null;
        }

        /// <summary>
        /// Tries to find all entities that have the specified component 
        /// attached. Performs a sequential search on all available entities
        /// [O(n)].
        /// </summary>
        /// <typeparam name="T">The type of the component.</typeparam>
        /// <param name="collection">The collection to add the entities to.</param>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="collection"/> is null.
        /// </exception>
        public void GetAllEntitiesWith<T>(ICollection<Entity> collection) where T : EntityComponent
        {
            if (collection == null)
                throw new ArgumentNullException("The specified collection is null");

            for (int i = 0, n = _entities.Count; i != n; i++)
            {
                // Cache the current entity
                Entity entity = _entities[i];

                // Check whether the entity has the specified component
                if (entity.HasComponent<T>())
                    collection.Add(entity);
            }
        }

        /// <summary>
        /// Tries to find all entities that have the specified component 
        /// attached. Performs a sequential search on all available entities
        /// [O(n)].
        /// </summary>
        /// <param name="type">The type of the component.</param>
        /// <param name="collection">The collection to add the entities to.</param>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="collection"/> is null.
        /// </exception>
        public void GetAllEntitiesWith(Type type, ICollection<Entity> collection)
        {
            if (collection == null)
                throw new ArgumentNullException("The specified collection is null");

            for (int i = 0, n = _entities.Count; i != n; i++)
            {
                // Cache the current entity entry
                Entity entity = _entities[i];

                // Check whether the entity has the specified component
                if (entity.HasComponent(type))
                    collection.Add(entity);
            }
        }

        /// <summary>
        /// Tries to find an entity with the specified tag. Performs a 
        /// sequential search on all available entities [O(1, ..., n)].
        /// Will only return the first instance using the specified tag.
        /// </summary>
        /// <param name="tag">The tag to search for.</param>
        /// <returns>An entity using the specified tag.</returns>
        public Entity GetEntityWithTag(string tag)
        {
            for (int i = 0, n = _entities.Count; i != n; i++)
            {
                // Cache the current entity entry
                Entity entity = _entities[i];

                // Check whether the entity has the specified tag
                if (entity.Tag.Equals(tag))
                    return entity;
            }

            return null;
        }

        /// <summary>
        /// Tries to find all entities which share the specified tag. Performs
        /// a sequential search on the list [O(n)]. Adds all instances to the 
        /// specified collection.
        /// </summary>
        /// <param name="tag">The tag to search for.</param>
        /// <param name="collection">The collection holding all components.</param>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="collection"/> is null.
        /// </exception>
        public void GetAllEntitiesWithTag(string tag, ICollection<Entity> collection)
        {
            if (collection == null)
                throw new ArgumentNullException("The specified collection is null");

            for (int i = 0, n = _entities.Count; i != n; i++)
            {
                // Cache the current entity entry
                Entity entity = _entities[i];

                // Check whether the entity has the specified tag
                if (entity.Tag.Equals(tag))
                    collection.Add(entity);
            }
        }

        #endregion

        #region IEnumerable

        /// <summary>
        /// Returns the enumerator of the current collection.
        /// </summary>
        /// <returns>The enumerator.</returns>
        public IEnumerator<Entity> GetEnumerator()
        {
            return _entities.GetEnumerator();
        }

        /// <summary>
        /// Returns the enumerator of the current collection.
        /// </summary>
        /// <returns>The enumerator.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _entities.GetEnumerator();
        }

        #endregion
    }
}
