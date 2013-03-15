#region Using Statements

using System.Collections.Generic;
using System.Windows.Forms;
using StructureMap;


#endregion

namespace HoneyCube.Editor.Commands
{
    /// <summary>
    /// A CommandMap assigns an executable command to a unique string identifier 
    /// or key combination.
    /// </summary>
    public class CommandMap : ICommandMap
    {
        #region Fields

        private readonly Dictionary<string, CommandBinding> _ids = new Dictionary<string, CommandBinding>();
        private readonly Dictionary<int, CommandBinding> _shortcuts = new Dictionary<int, CommandBinding>();
        private readonly IContainer _container;

        #endregion

        #region Constructors

        /// <summary>
        /// Public constructor. Creates a new CommandMap associating commands to
        /// a unique identifier or key combination.
        /// </summary>
        public CommandMap()
        {
            // Empty
        }

        /// <summary>
        /// Public constructor. Creates a new CommandMap associating commands to
        /// a unique identifier or key combination.
        /// </summary>
        /// <param name="container">An IoC container used for object instantiation.</param>
        public CommandMap(IContainer container)
        {
            _container = container;
        }

        #endregion

        /// <summary>
        /// Get the CommandBinding for the given identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>A reference to the instance bound to the identifier. Null if not found.</returns>
        protected CommandBinding Get(string id)
        {
            CommandBinding binding = null;
            _ids.TryGetValue(id, out binding);
            return binding;
        }

        /// <summary>
        /// Get the CommandBinding for the given key combination.
        /// </summary>
        /// <param name="keys">The key combination.</param>
        /// <returns>A reference to the instance bound to the key combi. Null if not found.</returns>
        protected CommandBinding Get(Keys keys)
        {
            CommandBinding binding = null;
            _shortcuts.TryGetValue((int)keys, out binding);
            return binding;
        }

        /// <summary>
        /// Get the CommandBinding for the given key combination.
        /// </summary>
        /// <param name="shortcut">The key combination.</param>
        /// <returns>A reference to the instance bound to the key combi. Null if not found.</returns>
        protected CommandBinding Get(Shortcut shortcut)
        {
            CommandBinding binding = null;
            _shortcuts.TryGetValue((int)shortcut, out binding);
            return binding;
        }

        /// <summary>
        /// Creates a new binding object or returns an existing one for the given
        /// string identifier.
        /// </summary>
        /// <example>
        /// Usage example to bind an identifier to a certain command:
        /// If("RunTestCommand").ThenExecute(new MyCommand());
        /// </example>
        /// <param name="id">The identifier to bind the command to.</param>
        /// <returns>A reference to the binding object.</returns>
        public CommandBinding If(string id)
        {
            CommandBinding binding = Get(id);

            if (binding == null)
            {
                binding = new CommandBinding(_container);
                _ids.Add(id, binding);
            }

            return binding;
        }

        /// <summary>
        /// Creates a new binding object or returns an existing one for the given
        /// key combination.
        /// </summary>
        /// <example>
        /// Usage example to bind a key combination to a certain command:
        /// If(Keys.Control | Keys.T).ThenExecute(new MyCommand());
        /// </example>
        /// <param name="keys">The key combination to bind the command to.</param>
        /// <returns>A reference to the binding object.</returns>
        public CommandBinding If(Keys keys)
        {
            CommandBinding binding = Get(keys);

            if (binding == null)
            {
                binding = new CommandBinding(_container);
                _shortcuts.Add((int)keys, binding);
            }

            return binding;
        }

        /// <summary>
        /// Creates a new binding object or returns an existing one for the given
        /// key combination.
        /// </summary>
        /// <example>
        /// Usage example to bind a key combination to a certain command:
        /// If(Shortcut.CtrlT).ThenExecute(new MyCommand());
        /// </example>
        /// <param name="shortcut">The key combination to bind the command to.</param>
        /// <returns>A reference to the binding object.</returns>
        public CommandBinding If(Shortcut shortcut)
        {
            CommandBinding binding = Get(shortcut);

            if (binding == null)
            {
                binding = new CommandBinding(_container);
                _shortcuts.Add((int)shortcut, binding);
            }

            return binding;
        }

        /// <summary>
        /// Tries to execute all commands bound to the given identifier.
        /// </summary>
        /// <param name="id">The identifier the commands are bound to.</param>
        /// <returns>True if any commands have been bound to the identifier.</returns>
        public bool TryToExecute(string id)
        {
            CommandBinding binding = Get(id);

            if (binding != null)
            {
                binding.Trigger();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Tries to execute all commands bound to the given key combination.
        /// </summary>
        /// <param name="key">The key combination the commands are bound to.</param>
        /// <returns>True if any commands have been bound to the key combination.</returns>
        public bool TryToExecute(Keys key)
        {
            CommandBinding binding = Get(key);

            if (binding != null)
            {
                binding.Trigger();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Tries to execute all commands bound to the given key combination.
        /// </summary>
        /// <param name="shortcut">The key combination the commands are bound to.</param>
        /// <returns>True if any commands have been bound to the key combination.</returns>
        public bool TryToExecute(Shortcut shortcut)
        {
            CommandBinding binding = Get(shortcut);

            if (binding != null)
            {
                binding.Trigger();
                return true;
            }

            return false;
        }
    }
}
