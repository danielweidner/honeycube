#region Using Statements

using System;

#endregion

namespace HoneyCube.Editor.Commands
{
    /// <summary>
    /// A collection of flags that represent the allowed states of a command.
    /// </summary>
    [Flags]
    public enum CommandState : short
    {
        /// <summary>
        /// The command is waiting for execution.
        /// </summary>
        Waiting = 1 << 0,

        /// <summary>
        /// The command is a clone of an already executed command.
        /// </summary>
        Cloned = 1 << 1,

        /// <summary>
        /// The command is executed by the application controller.
        /// </summary>
        Executed = 1 << 2,

        /// <summary>
        /// The command was undone by the user.
        /// </summary>
        Undone = 1 << 3
    }
}
