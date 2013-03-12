#region Using Statements

using System;

#endregion

namespace HoneyCube.Editor.Commands
{
    /// <summary>
    /// Represents a simple stack of commands ordered by their execution time.
    /// </summary>
    public interface ICommandHistory<T> where T : ICommand
    {
        /// <summary>
        /// Saves and executes the given command.
        /// </summary>
        /// <param name="command">The command to save and execute.</param>
        void SaveAndExecute(T command);

        /// <summary>
        /// Reverts the actions performed by the latest command.
        /// </summary>
        void Undo();

        /// <summary>
        /// Executes the lastest undone command in the history.
        /// </summary>
        void Redo();

        /// <summary>
        /// Flushes the entire history.
        /// </summary>
        void Clear();

        /// <summary>
        /// Is raised every time the history runs out of elements or retrieves 
        /// new elements to undo/redo.
        /// </summary>
        event EventHandler StateChanged;
    }
}
