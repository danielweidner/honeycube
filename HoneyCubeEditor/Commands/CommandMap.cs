#region Using Statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HoneyCube.Editor.Services;
using System.Windows.Forms;

#endregion

namespace HoneyCube.Editor.Commands
{
    /// <summary>
    /// TODO
    /// </summary>
    public class CommandMap : ICommandService
    {
        #region Fields

        private Dictionary<string, ICommand> _map = new Dictionary<string, ICommand>();

        #endregion

        #region Constructors

        /// <summary>
        /// TODO
        /// </summary>
        public CommandMap()
        {
            // Empty
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="file"></param>
        /// <param name="service"></param>
        public CommandMap(string file, IControlService service)
        {
            ReadFromXML(file, service);
        }

        #endregion

        /// <summary>
        /// TODO
        /// </summary>
        public void ReadFromXML(string path, IControlService service)
        {
            // TODO
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
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
        /// TODO
        /// </summary>
        /// <param name="id"></param>
        public void Remove(string id)
        {
            _map.Remove(id);
        }

        #region ICommandService Members

        /// <summary>
        /// TODO
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetCommand<T>(string id) where T : ICommand
        {
            ICommand command = null;
            _map.TryGetValue(id, out command);
            return (T)command;
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="id"></param>
        public bool ExecuteCommand(string id)
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
