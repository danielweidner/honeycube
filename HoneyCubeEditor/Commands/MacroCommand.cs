#region Using Statements

using System.Collections.Generic;

#endregion

namespace HoneyCube.Editor.Commands
{
    /// <summary>
    /// Bundles a series of commands into a single one.
    /// </summary>
    public class MacroCommand : UndoableCommand
    {
        #region Fields

        protected LinkedList<IUndoableCommand> _commands;

        #endregion

        #region Constructor

        /// <summary>
        /// Public constructor. Creates a new macro command combining several 
        /// commands into one managable chunk.
        /// </summary>
        public MacroCommand()
        {
            _commands = new LinkedList<IUndoableCommand>();
        }

        /// <summary>
        /// Public constructor. Creates a new macro command combining several 
        /// commands into one managable chunk.
        /// </summary>
        /// <param name="commands">A list of commands representing the current macro.</param>
        public MacroCommand(IEnumerable<IUndoableCommand> commands)
        {
            _commands = new LinkedList<IUndoableCommand>(commands);
        }

        #endregion

        /// <summary>
        /// Pushes a new command to the stack.
        /// </summary>
        /// <param name="command">The command to execute within this macro.</param>
        public void Push(IUndoableCommand command)
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

        #region UndoableCommand Members

        /// <summary>
        /// TODO
        /// </summary>
        /// <returns></returns>
        protected override bool OnExecute()
        {
            bool allExecuted = false;
            LinkedListNode<IUndoableCommand> node = _commands.First;

            while (node != null)
            {
                IUndoableCommand command = node.Value;
                command.Execute();
                allExecuted |= command.IsExecuted;
            }

            return allExecuted;
        }

        /// <summary>
        /// TODO
        /// </summary>
        protected override void OnUndo()
        {
            LinkedListNode<IUndoableCommand> node = _commands.Last;
            while (node != null)
            {
                node.Value.Undo();
                node = node.Previous;
            }
        }

        /// <summary>
        /// TODO
        /// </summary>
        protected override void OnRedo()
        {
            LinkedListNode<IUndoableCommand> node = _commands.First;
            while (node != null)
            {
                node.Value.Redo();
                node = node.Next;
            }
        }

        #endregion

        #region ICloneable Members

        /// <summary>
        /// Creates a deep copy of the current macro. All commands added are cloned 
        /// as well.
        /// </summary>
        /// <returns>A copy of the current macro. Null if not cloneable.</returns>
        public override object Clone()
        {
            // Ensure that the macro is cloneable at all (already executed)
            if (!IsExecuted)
                return null;

            // Create a shallow copy
            MacroCommand macro = (MacroCommand)base.Clone();

            // Replace the list with reference to the original commands, as we are 
            // going to clone each command individually (deep copy)
            macro._commands = new LinkedList<IUndoableCommand>();

            // Clone all commands in the list
            foreach (IUndoableCommand command in _commands)
            {
                if (command.IsExecuted)
                    macro.Push((IUndoableCommand)command.Clone());
            }

            return macro;
        }
        
        #endregion
    }
}
