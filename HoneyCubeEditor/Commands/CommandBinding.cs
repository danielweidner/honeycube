#region Using Statements

using System;
using System.Collections.Generic;
using StructureMap;
using System.Windows.Forms;

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

        private ICommandMap _map;
        private IContainer _container;

        private List<ICommand> _commands;
        private List<Action<IList<ICommand>>> _callbacks;

        #endregion

        #region Constructor

        /// <summary>
        /// Internal constructor. Creates a collection of commands which are 
        /// bound to a certain identifier/key combination.
        /// </summary>
        /// <param name="container">A reference to an IoC container used for object creation.</param>
        /// <param name="map">A reference to the command map maintaining all bindings.</param>
        internal CommandBinding(IContainer container, ICommandMap map)
        {
            _map = map;
            _container = container;

            _commands = new List<ICommand>();
            _callbacks = new List<Action<IList<ICommand>>>();
        }

        #endregion

        /// <summary>
        /// Allows to specify multiple triggers for the resulting command binding.
        /// </summary>
        /// <param name="id">The command id triggering the binding.</param>
        /// <returns>A reference to the command binding.</returns>
        public CommandBinding Or(string id)
        {
            _map.Connect(this, id);
            return this;
        }

        /// <summary>
        /// Allows to specify multiple triggers for the resulting command binding.
        /// </summary>
        /// <param name="keys">The key combination triggering the binding.</param>
        /// <returns>A reference to the command binding.</returns>
        public CommandBinding Or(Keys keys)
        {
            _map.Connect(this, keys);
            return this;
        }

        /// <summary>
        /// Allows to specify multiple triggers for the resulting command binding.
        /// </summary>
        /// <param name="id">The shortcut triggering the binding.</param>
        /// <returns>A reference to the command binding.</returns>
        public CommandBinding Or(Shortcut shortcut)
        {
            _map.Connect(this, shortcut);
            return this;
        }

        /// <summary>
        /// Adds a command to execute once the current binding is triggered.
        /// </summary>
        /// <param name="command">The command to execute.</param>
        /// <returns>A reference to the current binding to allow for method chaining.</returns>
        public CommandBinding ThenExecute(ICommand command)
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
        public CommandBinding ThenExecute<T>() where T : ICommand
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
