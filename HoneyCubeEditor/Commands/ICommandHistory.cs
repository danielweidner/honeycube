namespace HoneyCube.Editor.Commands
{
    /// <summary>
    /// Represents a simple stack of commands ordered by their execution time.
    /// </summary>
    public interface ICommandHistory
    {
        /// <summary>
        /// Saves and executes the given command.
        /// </summary>
        /// <param name="command">The command to save and execute.</param>
        void SaveAndExecute(ICommand command);

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
    }
}
