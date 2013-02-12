#region Using Statements

using System;

#endregion

namespace HoneyCube.Editor.Commands
{
    /// <summary>
    /// A command performs a certain operation on a receiver.
    /// </summary>
    public interface ICommand : ICloneable
    {
        /// <summary>
        /// TODO
        /// </summary>
        string Text { get; }

        /// <summary>
        /// Executes the command and performs the associated action.
        /// </summary>
        void Execute();
    }
}
