#region Using Statements

using System;
using System.Collections;
using System.Collections.Generic;

#endregion

namespace HoneyCube.Components
{
    /// <summary>
    /// EntityComponentCollection is a simple wrapper for a generic list. It 
    /// provides additional methods to easily query for entity components.
    /// </summary>
    public class EntityComponentCollection : IEntityComponentCollection, IEnumerable<EntityComponent>
    {
        #region Fields

        private List<EntityComponent> _components;

        #endregion

        #region Indexer

        /// <summary>
        /// Ge the element at the specified index position.
        /// </summary>
        /// <param name="i">The zero-based index of the element.</param>
        /// <returns>The component at the specified index position.</returns>
        public EntityComponent this[int i]
        {
            get { return _components[i]; }
        }

        #endregion

        #region Properties

        /// <summary>
        /// The total number of components available in the current collection.
        /// </summary>
        public int NumberOfComponents
        {
            get { return _components.Count; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Internal constructor. Creates a new entity component collection.
        /// </summary>
        public EntityComponentCollection()
        {
            _components = new List<EntityComponent>();
        }

        #endregion

        #region IEntityComponentCollection

        // <summary>
        /// Adds a new component to the end of the collection.
        /// </summary>
        /// <param name="component">The component to add.</param>
        /// <remarks>
        /// TODO: Account for the case where a component is already attached 
        /// to another entity. Avoid adding a component twice.</remarks>
        public void AddComponent(EntityComponent component)
        {
            _components.Add(component);
        }

        /// <summary>
        /// Removes a component from the collection.
        /// </summary>
        /// <param name="component">The component to remove.</param>
        /// <returns>True if the component was removed successfully.</returns>
        public bool RemoveComponent(EntityComponent component)
        {
            return _components.Remove(component);
        }

        /// <summary>
        /// Removes a component of a certain type from the collection. Only removes the
        /// first appearance of the type.
        /// </summary>
        /// <typeparam name="T">The type of component to remove.</typeparam>
        /// <returns>True if the component type was removed successfully.</returns>
        public bool RemoveComponent<T>() where T : EntityComponent
        {
            T component = GetComponent<T>();
            return component != default(T) && _components.Remove(component);
        }

        /// <summary>
        /// Checks whether a component of the specified type is present in 
        /// the current collection. Performs a sequential search [O(1, ..., n)] 
        /// on the internal list.
        /// </summary>
        /// <typeparam name="T">The type to search for.</typeparam>
        /// <returns>True if a component with the specified type exists.</returns>
        public bool HasComponent<T>() where T : EntityComponent
        {
            for (int i = _components.Count - 1; i >= 0; i--)
                if (_components[i] is T)
                    return true;

            return false;
        }

        /// <summary>
        /// Checks whether a component of the specified type is present in 
        /// the current collection. Performs a sequential search [O(1, ..., n)] 
        /// on the internal list.
        /// </summary>
        /// <param name="type">The type to search for.</param>
        /// <returns>True if a component with the specified type exists.</returns>
        public bool HasComponent(Type type)
        {
            for (int i = _components.Count - 1; i >= 0; i--)
                if (type.IsAssignableFrom(_components[i].GetType()))
                    return true;

            return false;
        }

        /// <summary>
        /// Checks whether a component with the specified name is present in 
        /// the current collection. Performs a sequential search [O(1, ..., n)] 
        /// on the internal list.
        /// </summary>
        /// <param name="name">The name of the component to search for.</param>
        /// <returns>True if a component with the specified name exists.</returns>
        public bool HasComponent(string name)
        {
            for (int i = _components.Count - 1; i >= 0; i--)
                if (_components[i].Name.Equals(name))
                    return true;

            return false;
        }

        /// <summary>
        /// Tries to retrieve a component of the specified type. Performs a 
        /// sequential search on the list [O(1, ..., n)]. Returns only the first
        /// appearance of the type.
        /// </summary>
        /// <typeparam name="T">The component type to retrieve.</typeparam>
        /// <returns>A reference to the component. Null if not found.</returns>
        public T GetComponent<T>() where T : EntityComponent
        {
            for (int i = _components.Count - 1; i >= 0; i--)
                if (_components[i] is T)
                    return _components[i] as T;

            return default(T);
        }

        /// <summary>
        /// Tries to retrieve all components of the specified type. Performs a 
        /// sequential search on the list [O(1, ..., n)].
        /// </summary>
        /// <typeparam name="T">The component type to retrieve.</typeparam>
        /// <param name="collection">The collection the components should be added to.</param>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="collection"/> is null.
        /// </exception>
        public void GetAllComponents<T>(ICollection<T> collection) where T : EntityComponent
        {
            if (collection == null)
                throw new ArgumentNullException("The specified collection is null.");

            for (int i = _components.Count - 1; i >= 0; i--)
                if (_components[i] is T)
                    collection.Add(_components[i] as T);
        }

        /// <summary>
        /// Tries to retrieve a component of the specified type. Performs a 
        /// sequential search on the list [O(1, ..., n)]. Returns only the first
        /// appearance of the type.
        /// </summary>
        /// <param name="type">The component type to retrieve.</param>
        /// <returns>A reference to the component. Null if not found.</returns>
        public EntityComponent GetComponent(Type type)
        {
            for (int i = _components.Count - 1; i >= 0; i--)
                if (type.IsAssignableFrom(_components[i].GetType()))
                    return _components[i];

            return null;
        }

        /// <summary>
        /// Tries to retrieve all components of the specified type. Performs a 
        /// sequential search on the list [O(1, ..., n)].
        /// </summary>
        /// <param name="type">The component type to retrieve.</param>
        /// <param name="collection">The collection the components should be added to.</param>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="collection"/> is null.
        /// </exception>
        public void GetAllComponents(Type type, ICollection<EntityComponent> collection)
        {
            if (collection == null)
                throw new ArgumentNullException("The specified collection is null.");

            for (int i = _components.Count - 1; i >= 0; i--)
                if (type.IsAssignableFrom(_components[i].GetType()))
                    collection.Add(_components[i]);
        }

        /// <summary>
        /// Tries to find a component with the specified name. Performs a sequential
        /// search on the list [O(1, ..., n)]. Returns only the first appearance of
        /// the name.
        /// </summary>
        /// <param name="name">The name of the component to retrieve.</param>
        /// <returns>A reference to the component. Null if not found.</returns>
        public EntityComponent GetComponentByName(string name)
        {
            for (int i = _components.Count - 1; i >= 0; i--)
                if (_components[i].Name.Equals(name))
                    return _components[i];

            return null;
        }

        /// <summary>
        /// Tries to find all component with the specified name.
        /// </summary>
        /// <param name="name">The name of the components to retrieve.</param>
        /// <param name="collection">The collection to add the component to.</param>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="collection"/> is null.
        /// </exception>
        public void GetAllComponentsWithName(string name, ICollection<EntityComponent> collection)
        {
            if (collection == null)
                throw new ArgumentNullException("The specified collection is null.");

            for (int i = _components.Count - 1; i >= 0; i--)
                if (_components[i].Name.Equals(name))
                    collection.Add(_components[i]);
        }

        /// <summary>
        /// Tries to find a component with the specified tag. Performs a sequential
        /// search on the list [O(1, ..., n)]. Returns only the first appearance of
        /// the tag.
        /// </summary>
        /// <param name="tag">The tag to search for.</param>
        /// <returns>A reference to the component. Null if not found.</returns>
        public EntityComponent GetComponentWithTag(string tag)
        {
            for (int i = _components.Count - 1; i >= 0; i--)
                if (_components[i].Tag.Equals(tag))
                    return _components[i];

            return null;
        }

        /// <summary>
        /// Tries to find all components which share the specified tag. Performs
        /// a sequential search on the list [O(n)]. Adds all instances to the 
        /// specified collection.
        /// </summary>
        /// <param name="tag">The tag to search for.</param>
        /// <param name="collection">The collection holding all components.</param>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="collection"/> is null.
        /// </exception>
        public void GetAllComponentsWithTag(string tag, ICollection<EntityComponent> collection)
        {
            if (collection == null)
                throw new ArgumentNullException("The specified collection is null.");

            for (int i = _components.Count - 1; i >= 0; i--)
                if (_components[i].Tag.Equals(tag))
                    collection.Add(_components[i]);
        }

        #endregion

        #region IEnumerable

        /// <summary>
        /// Returns the enumerator of the current collection.
        /// </summary>
        /// <returns>The enumerator.</returns>
        public IEnumerator<EntityComponent> GetEnumerator()
        {
            return _components.GetEnumerator();
        }

        /// <summary>
        /// Returns the enumerator of the current collection.
        /// </summary>
        /// <returns>The enumerator.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _components.GetEnumerator();
        }

        #endregion
    }
}
