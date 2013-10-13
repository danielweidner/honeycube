#region Using Statements

using System;
using System.Collections.Generic;
using HoneyCube.Components;


#endregion

namespace HoneyCube
{
    /// <summary>
    /// Describes a scene within the game. A scene represents the root node 
    /// within the entity hierarchy.
    /// </summary>
    public interface IScene
    {
        /// <summary>
        /// A human readable name for the current scene (not necessarily unique).
        /// </summary>
        string Name
        {
            get;
            set;
        }

        /// <summary>
        /// The active camera which determines the perspective view on
        /// the scene.
        /// </summary>
        ICamera Camera
        {
            get;
            set;
        }

        /// <summary>
        /// Adds the specified entity to the scene. The scene will maintain all
        /// available entities and call update on their components.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        void AddEntity(Entity entity);

        /// <summary>
        /// Removes the specified entity and all its components from the scene.
        /// </summary>
        /// <param name="entity">The entity to remove.</param>
        void RemoveEntity(Entity entity);

        /// <summary>
        /// Tries to return the entity with the specified unique identifier.
        /// Returns null if no entity uses the specified id. Causes a dictionary
        /// look-up.
        /// </summary>
        /// <param name="id">The id of the entity to retrieve.</param>
        /// <returns>A reference to the entity. Null if not found.</returns>
        Entity GetEntityById(int id);

        /// <summary>
        /// Tries to find an entity with the specified name. Returns only the 
        /// first appearance of the name.
        /// </summary>
        /// <param name="name">The name of the entity to retrieve.</param>
        /// <returns>A reference to the entity. Null if not found.</returns>
        Entity GetEntityByName(string name);

        /// <summary>
        /// Tries to find all entites with the specified name. Adds all 
        /// entities to the specified collection.
        /// </summary>
        /// <param name="name">The name to search for.</param>
        /// <param name="collection">The collection the entites should be added to.</param>
        void GetAllEntitiesWithName(string name, ICollection<Entity> collection);

        /// <summary>
        /// Tries to find an entity that has the specified component attached.
        /// Will only return the first appearance of an entity using that 
        /// component.
        /// </summary>
        /// <typeparam name="T">The type of the component.</typeparam>
        /// <returns>A reference to the entity using that component.</returns>
        Entity GetEntityWith<T>() where T : EntityComponent;

        /// <summary>
        /// Tries to find an entity that has the specified component attached.
        /// Will only return the first appearance of an entity using that 
        /// component.
        /// </summary>
        /// <param name="type">The type of the component.</param>
        /// <returns>A reference to the entity using that component.</returns>
        Entity GetEntityWith(Type type);

        /// <summary>
        /// Tries to find all entities that have the specified component 
        /// attached. 
        /// </summary>
        /// <typeparam name="T">The type of the component.</typeparam>
        /// <param name="collection">The collection to add the entities to.</param>
        void GetAllEntitiesWith<T>(ICollection<Entity> collection) where T : EntityComponent;

        /// <summary>
        /// Tries to find all entities that have the specified component 
        /// attached.
        /// </summary>
        /// <param name="type">The type of the component.</param>
        /// <param name="collection">The collection to add the entities to.</param>
        void GetAllEntitiesWith(Type type, ICollection<Entity> collection);

        /// <summary>
        /// Tries to find an entity with the specified tag. Will only return 
        /// the first instance using the specified tag.
        /// </summary>
        /// <param name="tag">The tag to search for.</param>
        /// <returns>An entity using the specified tag.</returns>
        Entity GetEntityWithTag(string tag);

        /// <summary>
        /// Tries to find all entities which share the specified tag. Adds all
        /// instances to the specified collection.
        /// </summary>
        /// <param name="tag">The tag to search for.</param>
        /// <param name="collection">The collection holding all components.</param>
        void GetAllEntitiesWithTag(string tag, ICollection<Entity> collection);

        /// <summary>
        /// Checks whether an entity with the specified name is present in the 
        /// scene.
        /// </summary>
        /// <param name="name">The name of the entity to search for.</param>
        /// <returns>True if an entity with the specified name exists.</returns>
        bool ContainsEntity(string name);

        /// <summary>
        /// Checks whether an entity with the specified id is present in the
        /// scene.
        /// </summary>
        /// <param name="id">The id of the entity to search for.</param>
        /// <returns>True if the entity with the specified id exists.</returns>
        bool ContainsEntity(int id);

        /// <summary>
        /// Checks whether the specified entity is added to the scene.
        /// </summary>
        /// <param name="entity">The entity to search for.</param>
        /// <returns>True if the entity is added to the scene.</returns>
        bool ContainsEntity(Entity entity);
    }
}
