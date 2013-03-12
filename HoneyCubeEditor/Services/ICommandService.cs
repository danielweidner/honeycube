#region Using Statements

using HoneyCube.Editor.Commands;

#endregion

namespace HoneyCube.Editor.Services
{
    /// <summary>
    /// Describes a service which allows to retrieve a generic command 
    /// by its name or identifier.
    /// </summary>
    public interface ICommandService
    {
        /// <summary>
        /// Returns a command with the given name.
        /// </summary>
        /// <typeparam name="T">The type of the command to retrieve.</typeparam>
        /// <param name="id">The name or id of the command to retrieve.</param>
        /// <returns>A reference to the command. Null if not found or of wrong type.</returns>
        T GetCommand<T>(string id) where T : ICommand;

        /// <summary>
        /// Tries to executed the specified command. Will do nothing if no 
        /// command with the given id is available.
        /// </summary>
        /// <param name="id">The name or id of the command to execute.</param>
        bool TryToExecuteCommand(string id);
    }
}
