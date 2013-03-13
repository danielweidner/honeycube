#region Using Statements

using System;
using System.Collections.Generic;
using StructureMap;

#endregion

namespace HoneyCube.Editor.Commands
{
    /// <summary>
    /// A CommandBinding is a collection of executable commands which are 
    /// triggered by the same identifier or key combination.
    /// </summary>
    public class CommandBinding
    {
        #region Fields

        private IContainer _container;
        private List<ICommand> _commands;
        private List<Action<IList<ICommand>>> _callbacks;

        #endregion

        #region Constructors

        /// <summary>
        /// Internal constructor. Creates a collection of commands which are 
        /// bound to a certain identifier/key combination.
        /// </summary>
        internal CommandBinding()
            : this(null)
        {
            //Empty
        }

        /// <summary>
        /// Internal constructor. Creates a collection of commands which are 
        /// bound to a certain identifier/key combination.
        /// </summary>
        /// <param name="container">A reference to an IoC container used for object creation.</param>
        internal CommandBinding(IContainer container)
        {
            _container = container;
            _commands = new List<ICommand>();
            _callbacks = new List<Action<IList<ICommand>>>();
        }

        #endregion

        /// <summary>
        /// Adds a command to execute once the current binding is triggered.
        /// </summary>
        /// <param name="command">The command to execute.</param>
        /// <returns>A reference to the current binding to allow for method chaining.</returns>
        public CommandBinding Execute(ICommand command)
        {
            _commands.Add(command);
            
            // Return the current binding instance to allow for 
            // method chaining
            return this;
        }

        /// <summary>
        /// Tries to retrieve a given command from the IoC Framework factory.
        /// Adds the retrieved instance to the current binding to execute it
        /// once the binding is triggered.
        /// </summary>
        /// <typeparam name="T">The type of command to execute on trigger.</typeparam>
        /// <returns>A reference to the current binding to allow for method chaining.</returns>
        public CommandBinding Execute<T>() where T : ICommand
        {
            // Try to get an instance from the IoC Container/Object factory
            ICommand command = _container != null ? 
                                    _container.GetInstance<T>() : 
                                    ObjectFactory.GetInstance<T>();

            if (command != null)
                _commands.Add(command);

            // Return the current binding instance to allow for 
            // method chaining
            return this;
        }

        /// <summary>
        /// Allows to register a function to call once the binding is executed.
        /// </summary>
        /// <param name="callback">The callback function to register.</param>
        /// <returns>A reference to the current binding to allow for method chaining.</returns>
        public CommandBinding OnExecute(Action<IList<ICommand>> callback)
        {
            _callbacks.Add(callback);

            // Return the current binding instance to allow for 
            // method chaining
            return this;
        }

        /// <summary>
        /// Internal function to trigger the current binding. Executes all 
        /// assigned commands and calls each registered callback function
        /// afterwards.
        /// </summary>
        internal void Trigger()
        {
            // Execute each command added to the current binding
            foreach (ICommand command in _commands)
                command.Execute();

            // Notify all registered callback functions about execution
            foreach (Action<IList<ICommand>> callback in _callbacks)
                callback(_commands);
        }
    }
}
