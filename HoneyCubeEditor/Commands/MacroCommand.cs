#region Using Statements

using System.Collections.Generic;

#endregion

namespace HoneyCube.Editor.Commands
{
    /// <summary>
    /// Bundles a series of commands into a single one.
    /// </summary>
    public class MacroCommand : ICommand
    {
        #region Fields

        protected LinkedList<ICommand> _commands;

        #endregion

        #region Constructor

        /// <summary>
        /// Public constructor. Creates a new macro command combining several 
        /// commands into one managable chunk.
        /// </summary>
        public MacroCommand()
        {
            _commands = new LinkedList<ICommand>();
        }

        /// <summary>
        /// Public constructor. Creates a new macro command combining several 
        /// commands into one managable chunk.
        /// </summary>
        /// <param name="commands">A list of commands representing the current macro.</param>
        public MacroCommand(IEnumerable<ICommand> commands)
        {
            _commands = new LinkedList<ICommand>(commands);
        }

        #endregion

        /// <summary>
        /// Pushes a new command to the stack.
        /// </summary>
        /// <param name="command">The command to execute within this macro.</param>
        public void Push(ICommand command)
        {
            _commands.AddLast(command);
        }

        /// <summary>
        /// Resets the current macro and removes all commands from the stack.
        /// </summary>
        public void Reset()
        {
            _commands.Clear();
        }

        /// <summary>
        /// Is called after all commands on the stack have been executed.
        /// </summary>
        public virtual void OnExecute()
        {
            // Empty
        }

        /// <summary>
        /// Is called right after all commands of the macro have been undone.
        /// </summary>
        public virtual void OnUndo()
        {
            // Empty
        }

        /// <summary>
        /// Is called after all commands of the macro have been executed again.
        /// </summary>
        public virtual void OnRedo()
        {
            // Empty
        }

        #region ICommand Members

        /// <summary>
        /// Executes all commands added to the current macro.
        /// </summary>
        public void Execute()
        {
            foreach (ICommand command in _commands)
                command.Execute();

            OnExecute();
        }

        /// <summary>
        /// Reverts all actions of the commands that belong to the current 
        /// macro.
        /// </summary>
        public void Undo()
        {
            foreach (ICommand command in _commands)
                command.Undo();

            OnUndo();
        }

        /// <summary>
        /// Executes all commands of the macro again in case they have been 
        /// reverted before.
        /// </summary>
        public void Redo()
        {
            foreach (ICommand command in _commands)
                command.Redo();

            OnRedo();
        }

        #endregion

        #region ICloneable Members

        /// <summary>
        /// Creates a shallow copy of the current macro.
        /// </summary>
        /// <returns>The shallow copy.</returns>
        public virtual object Clone()
        {
            return new MacroCommand(_commands);
        }

        #endregion
    }
}
