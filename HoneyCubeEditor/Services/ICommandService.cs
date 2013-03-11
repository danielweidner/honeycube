#region Using Statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HoneyCube.Editor.Commands;

#endregion

namespace HoneyCube.Editor.Services
{
    /// <summary>
    /// TODO
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICommandService
    {
        /// <summary>
        /// TODO
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetCommand<T>(string id) where T : ICommand;

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="id"></param>
        bool ExecuteCommand(string id);
    }
}
