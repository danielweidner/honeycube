#region Using Statements

using HoneyCube.Editor.Commands;

#endregion

namespace HoneyCube.Editor
{
    /// <summary>
    /// The IAppHub Interface creates a contract for a controller 
    /// which allows to manage the general flow of an application.
    /// </summary>
    public interface IAppHub
    {
        /// <summary>
        /// Tries to execute the associated command. Will do nothing when no
        /// command is available for the given identifier.
        /// </summary>
        /// <param name="identifier">The id of the command to execute.</param>
        void Execute(string identifier);

        /// <summary>
        /// Executes the given command.
        /// </summary>
        /// <param name="command">The command to execute.</param>
        void Execute(UndoableCommand command);

        /// <summary>
        /// Reverts the latest command executed.
        /// </summary>
        /// <returns>True on success.</returns>
        void Undo();

        /// <summary>
        /// Redo the last command executed.
        /// </summary>
        /// <returns>True on success.</returns>
        void Redo();

        /// <summary>
        /// Clears the command history entirely.
        /// </summary>
        void ClearHistory();

        /// <summary>
        /// Raise a certain event on application level.
        /// </summary>
        /// <typeparam name="T">The type of the event to raise.</typeparam>
        /// <param name="eventData">Some event data.</param>
        void Raise<T>(T eventData);
    }
}
