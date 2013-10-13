#region Using Statements

using System;
using System.Collections;
using System.Collections.Generic;

#endregion

namespace HoneyCube.Components
{
    /// <summary>
    /// The IEntityComponentCollection interface describes additional methods 
    /// to query for entity components.
    /// </summary>
    public interface IEntityComponentCollection : IEnumerable<EntityComponent>, IEnumerable
    {
        /// <summary>
        /// Get the element at the specified index position.
        /// </summary>
        /// <param name="i">The zero-based index of the element.</param>
        /// <returns>The component at the specified index position.</returns>
        EntityComponent this[int i]
        {
            get;
        }

        /// <summary>
        /// The total number of components available .
        /// </summary>
        int NumberOfComponents
        {
            get;
        }

        /// <summary>
        /// Adds a new component to the collection.
        /// </summary>
        /// <param name="component">The component to add.</param>
        void AddComponent(EntityComponent component);

        /// <summary>
        /// Removes a component from the collection.
        /// </summary>
        /// <param name="component">The component to remove.</param>
        /// <returns>True if the component was removed successfully.</returns>
        bool RemoveComponent(EntityComponent component);

        /// <summary>
        /// Removes a component of a certain type from the collection. Only removes the
        /// first appearance of the type.
        /// </summary>
        /// <typeparam name="T">The type of component to remove.</typeparam>
        /// <returns>True if the component type was removed successfully.</returns>
        bool RemoveComponent<T>() where T : EntityComponent;

        /// <summary>
        /// Checks whether a component of the specified type is present in 
        /// the current collection. 
        /// </summary>
        /// <typeparam name="T">The type to search for.</typeparam>
        /// <returns>True if a component with the specified type exists.</returns>
        bool HasComponent<T>() where T : EntityComponent;

        /// <summary>
        /// Checks whether a component of the specified type is present in 
        /// the current collection.
        /// </summary>
        /// <param name="type">The type to search for.</param>
        /// <returns>True if a component with the specified type exists.</returns>
        bool HasComponent(Type type);

        /// <summary>
        /// Checks whether a component with the specified name is present in 
        /// the current collection.
        /// </summary>
        /// <param name="name">The name of the component to search for.</param>
        /// <returns>True if a component with the specified name exists.</returns>
        bool HasComponent(string name);

        /// <summary>
        /// Tries to retrieve a component of the specified type. Returns only the 
        /// first appearance of the type.
        /// </summary>
        /// <typeparam name="T">The component type to retrieve.</typeparam>
        /// <returns>A reference to the component. Null if not found.</returns>
        T GetComponent<T>() where T : EntityComponent;

        /// <summary>
        /// Tries to retrieve all components of the specified type. Performs a 
        /// sequential search on the list [O(1, ..., n)].
        /// </summary>
        /// <typeparam name="T">The component type to retrieve.</typeparam>
        /// <param name="collection">The collection the components should be added to.</param>
        void GetAllComponents<T>(ICollection<T> collection) where T : EntityComponent;

        /// <summary>
        /// Tries to retrieve a component of the specified type. Returns only the
        /// first appearance of the type.
        /// </summary>
        /// <param name="type">The component type to retrieve.</param>
        /// <returns>A reference to the component. Null if not found.</returns>
        EntityComponent GetComponent(Type type);

        /// <summary>
        /// Tries to retrieve all components of the specified type. Performs a 
        /// sequential search on the list [O(1, ..., n)].
        /// </summary>
        /// <param name="type">The component type to retrieve.</param>
        /// <param name="collection">The collection the components should be added to.</param>
        void GetAllComponents(Type type, ICollection<EntityComponent> collection);

        /// <summary>
        /// Tries to find a component with the specified name. Returns only the 
        /// first appearance of the name.
        /// </summary>
        /// <param name="name">The name of the component to retrieve.</param>
        /// <returns>A reference to the component. Null if not found.</returns>
        EntityComponent GetComponentByName(string name);

        /// <summary>
        /// Tries to find all component with the specified name.
        /// </summary>
        /// <param name="name">The name of the components to retrieve.</param>
        /// <param name="collection">The collection to add the component to.</param>
        void GetAllComponentsWithName(string name, ICollection<EntityComponent> collection);

        /// <summary>
        /// Tries to find a component with the specified tag. Returns only the
        /// first appearance of the tag.
        /// </summary>
        /// <param name="tag">The tag to search for.</param>
        /// <returns>A reference to the component. Null if not found.</returns>
        EntityComponent GetComponentWithTag(string tag);

        /// <summary>
        /// Tries to find all components which share the specified tag. Adds all
        /// instances to the specified collection.
        /// </summary>
        /// <param name="tag">The tag to search for.</param>
        /// <param name="collection">The collection holding all components.</param>
        void GetAllComponentsWithTag(string tag, ICollection<EntityComponent> collection);
    }
}
