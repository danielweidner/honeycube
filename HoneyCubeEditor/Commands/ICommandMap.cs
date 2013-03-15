#region Using Statements

using System.Windows.Forms;
using StructureMap;

#endregion

namespace HoneyCube.Editor.Commands
{
    /// <summary>
    /// The ICommandMap interface describes a collection of CommandBindings 
    /// which assigns a executable command to an identifier or key combination.
    /// </summary>
    public interface ICommandMap
    {
        /// <summary>
        /// Creates a new binding object or returns an existing one for the given
        /// string identifier.
        /// </summary>
        /// <param name="id">The identifier to bind the command to.</param>
        /// <returns>A reference to the binding object.</returns>
        CommandBinding If(string id);

        /// <summary>
        /// Creates a new binding object or returns an existing one for the given
        /// key combination.
        /// </summary>
        /// <param name="keys">The key combination to bind the command to.</param>
        /// <returns>A reference to the binding object.</returns>
        CommandBinding If(Keys shortcut);

        /// <summary>
        /// Creates a new binding object or returns an existing one for the given
        /// key combination.
        /// </summary>
        /// <param name="keys">The key combination to bind the command to.</param>
        /// <returns>A reference to the binding object.</returns>
        CommandBinding If(Shortcut shortcut);

        /// <summary>
        /// Tries to execute all commands bound to the given identifier.
        /// </summary>
        /// <param name="id">The identifier the commands are bound to.</param>
        /// <returns>True if any commands have been bound to the identifier.</returns>
        bool TryToExecute(string id);

        /// <summary>
        /// Tries to execute all commands bound to the given key combination.
        /// </summary>
        /// <param name="key">The key combination the commands are bound to.</param>
        /// <returns>True if any commands have been bound to the key combination.</returns>
        bool TryToExecute(Keys key);

        /// <summary>
        /// Tries to execute all commands bound to the given key combination.
        /// </summary>
        /// <param name="shortcut">The key combination the commands are bound to.</param>
        /// <returns>True if any commands have been bound to the key combination.</returns>
        bool TryToExecute(Shortcut shortcut);
    }
}
