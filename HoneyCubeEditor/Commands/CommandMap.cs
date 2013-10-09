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

        private readonly List<CommandBinding> _bindings = new List<CommandBinding>();
        private readonly Dictionary<string, int> _ids = new Dictionary<string, int>();
        private readonly Dictionary<int, int> _shortcuts = new Dictionary<int, int>();
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
        /// Determines the unique id of the given command binding.
        /// </summary>
        /// <param name="binding">The command binding to retrieve the id for.</param>
        /// <returns>The unique id of the command binding</returns>
        private int GetBindingId(CommandBinding binding)
        {
            return _bindings.IndexOf(binding);
        }

        /// <summary>
        /// Get the CommandBinding for the given identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>A reference to the instance bound to the identifier. Null if not found.</returns>
        public CommandBinding Get(string id)
        {
            int bindingId = -1;
            if (_ids.TryGetValue(id, out bindingId))
                return _bindings[bindingId];

            return null;
        }

        /// <summary>
        /// Get the CommandBinding for the given key combination.
        /// </summary>
        /// <param name="keys">The key combination.</param>
        /// <returns>A reference to the instance bound to the key combi. Null if not found.</returns>
        public CommandBinding Get(Keys keys)
        {
            int bindingId = -1;
            if (_shortcuts.TryGetValue((int)keys, out bindingId))
                return _bindings[bindingId];

            return null;
        }

        /// <summary>
        /// Get the CommandBinding for the given key combination.
        /// </summary>
        /// <param name="shortcut">The key combination.</param>
        /// <returns>A reference to the instance bound to the key combi. Null if not found.</returns>
        public CommandBinding Get(Shortcut shortcut)
        {
            int bindingId = -1;
            if (_shortcuts.TryGetValue((int)shortcut, out bindingId))
                return _bindings[bindingId];

            return null;
        }

        /// <summary>
        /// Connects an existing binding object with the specified command id.
        /// </summary>
        /// <param name="binding">The binding object to connect.</param>
        /// <param name="id">The command id that should execute the binding.</param>
        public void Connect(CommandBinding binding, string id)
        {
            int bindingId = GetBindingId(binding);
            if (bindingId >= 0)
                _ids.Add(id, bindingId);
        }

        /// <summary>
        /// Connects an existing binding object with the specified key combination.
        /// </summary>
        /// <param name="binding">The binding object to connect.</param>
        /// <param name="key">The key combination that should execute the binding.</param>
        public void Connect(CommandBinding binding, Keys key)
        {
            int bindingId = GetBindingId(binding);
            if (bindingId >= 0)
                _shortcuts.Add((int)key, bindingId);
        }

        /// <summary>
        /// Connects an existing binding object with the specified shortcut.
        /// </summary>
        /// <param name="binding">The binding object to connect.</param>
        /// <param name="shortcut">The shortcut that should execute the binding.</param>
        public void Connect(CommandBinding binding, Shortcut shortcut)
        {
            int bindingId = GetBindingId(binding);
            if (bindingId >= 0)
                _shortcuts.Add((int)shortcut, bindingId);
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
                binding = new CommandBinding(_container, this);

                _bindings.Add(binding);
                _ids.Add(id, _bindings.Count - 1);
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
                binding = new CommandBinding(_container, this);

                _bindings.Add(binding);
                _shortcuts.Add((int)keys, _bindings.Count - 1);
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
                binding = new CommandBinding(_container, this);

                _bindings.Add(binding);
                _shortcuts.Add((int)shortcut, _bindings.Count - 1);
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