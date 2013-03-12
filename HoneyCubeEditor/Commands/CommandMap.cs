#region Using Statements

using System.Collections.Generic;
using HoneyCube.Editor.Services;


#endregion

namespace HoneyCube.Editor.Commands
{
    /// <summary>
    /// A CommandMap assigns an executable command to a unique string identifier.
    /// </summary>
    public class CommandMap : ICommandService
    {
        #region Fields

        private Dictionary<string, ICommand> _map = new Dictionary<string, ICommand>();

        #endregion

        #region Constructors

        /// <summary>
        /// Public constructor. Creates a new CommandMap.
        /// </summary>
        public CommandMap()
        {
            // Empty
        }

        /// <summary>
        /// Public constructor. Creates a new CommandMap.
        /// </summary>
        /// <param name="file">The xml file to retrieve the key-value pairs from.</param>
        /// <param name="service">A service provider which allows to retrieve control references by their names.</param>
        public CommandMap(string file, IControlService service)
        {
            ReadFromXML(file, service);
        }

        #endregion

        /// <summary>
        /// Reads a collection of commands and their associated identifiers from 
        /// a xml formated file.
        /// </summary>
        /// <param name="file">The xml file to retrieve the key-value pairs from.</param>
        /// <param name="service">A service provider which allows to retrieve control references by their names.</param>
        public void ReadFromXML(string path, IControlService service)
        {
            // TODO: Allow to read map of commands from an xml file
        }

        /// <summary>
        /// Add a new association between the given identifier and a command instance.
        /// </summary>
        /// <param name="id">The identifier assigned to the command.</param>
        /// <param name="command">The command to execute when the identifier is given.</param>
        public void Add(string id, ICommand command)
        {
            if (_map.ContainsKey(id))
            {
                _map[id] = command;
            }
            else
            {
                _map.Add(id, command);
            }
        }

        /// <summary>
        /// Removes the command saved for the given identifier.
        /// </summary>
        /// <param name="id">The command to remove.</param>
        public void Remove(string id)
        {
            _map.Remove(id);
        }

        #region ICommandService Members

        /// <summary>
        /// Returns a command with the given name.
        /// </summary>
        /// <typeparam name="T">The type of the command to retrieve.</typeparam>
        /// <param name="id">The name or id of the command to retrieve.</param>
        /// <returns>A reference to the command. Null if not found or of wrong type.</returns>
        public T GetCommand<T>(string id) where T : ICommand
        {
            ICommand command = null;
            _map.TryGetValue(id, out command);
            return (T)command;
        }

        /// <summary>
        /// Tries to executed the specified command. Will do nothing if no 
        /// command with the given id is available.
        /// </summary>
        /// <param name="id">The name or id of the command to execute.</param>
        public bool TryToExecuteCommand(string id)
        {
            ICommand command = GetCommand<ICommand>(id);
            if (command != null)
            {
                command.Execute();
                return command.IsExecuted;
            }

            return false;
        }

        #endregion
    }
}
