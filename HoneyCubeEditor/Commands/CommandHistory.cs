#region Using Statements

using System.Collections.Generic;
using System;

#endregion

namespace HoneyCube.Editor.Commands
{
    /// <summary>
    /// A simple implementation of a CommandHistory. Allows to log a sequence 
    /// of commands and to perform basic undo/redo functionality.
    /// </summary>
    public class CommandHistory : ICommandHistory<IUndoableCommand>
    {
        #region Fields

        private LinkedList<IUndoableCommand> _undos = new LinkedList<IUndoableCommand>();
        private LinkedList<IUndoableCommand> _redos = new LinkedList<IUndoableCommand>();
        
        private int _limit;

        #endregion

        #region Properties

        /// <summary>
        /// TODO
        /// </summary>
        public bool HasUndoableCommands
        {
            get { return _undos.Count > 0; }
        }

        /// <summary>
        /// TODO
        /// </summary>
        public bool HasRedoableCommands
        {
            get { return _redos.Count > 0; }
        }

        /// <summary>
        /// The maximum number of elements logged in the command history. Once 
        /// the number of elements exceeds the specified limit, the oldest 
        /// commands in the history will be discarded.
        /// </summary>
        public int Limit
        {
            get { return _limit; }
            set 
            {
                if (_limit > 0)
                {
                    _limit = value;
                    TrimHistoryLength();
                }
            }
        }

        /// <summary>
        /// TODO
        /// </summary>
        public event EventHandler StateChanged;

        #endregion

        #region Constructor

        /// <summary>
        /// Public constructor. Creates a command history keeping track of a 
        /// sequence of commands.
        /// </summary>
        public CommandHistory()
        {
            _limit = int.MaxValue;
        }

        /// <summary>
        /// Public constructor. Creates a command history keeping track of a 
        /// sequence of commands.
        /// </summary>
        /// <param name="limit">The maximum number of commands to hold in the history.</param>
        public CommandHistory(int limit)
        {
            _limit = limit;
        }

        #endregion

        #region ICommandHistory Members

        /// <summary>
        /// Saves the command in a sorted list (by execution time) and executes it.
        /// </summary>
        /// <param name="command">The command to save in history.</param>
        public void SaveAndExecute(IUndoableCommand command)
        {
            if (command != null && !command.IsClone)
            {
                // Ensure that the history does not contain more elements than
                // specified as limit.
                TrimHistoryLength();

                // Remember the current history state
                bool hadUndoableCommandsBefore = HasUndoableCommands;
                bool hadRedoableCommandsBefore = HasRedoableCommands;

                // Execute the command.
                command.Execute();

                // Include the command only in the history if it was executed 
                // successfully
                if (command.IsExecuted)
                {
                    // Flush the redo history
                    _redos.Clear();

                    // Copy the state of the current command and push it to the 
                    // history
                    _undos.AddLast((UndoableCommand)command.Clone());

                    // Check for state changed of the history
                    if (hadUndoableCommandsBefore != HasUndoableCommands
                            && hadRedoableCommandsBefore != HasRedoableCommands)
                    {
                        OnStateChanged(EventArgs.Empty);
                    }
                }
            }
        }

        /// <summary>
        /// Reverts the last command executed.
        /// </summary>
        public void Undo()
        {
            Undo(1);
        }

        /// <summary>
        /// Reverts the latest commands executed.
        /// </summary>
        /// <param name="numCommandsToUndo">The number of commands to revert.</param>
        public void Undo(int numCommandsToUndo)
        {
            int numCommandsUndone = 0;
            LinkedListNode<IUndoableCommand> node = _undos.Last;

            while (node != null && numCommandsUndone < numCommandsToUndo)
            {
                bool hadRedoableCommandsBefore = HasRedoableCommands;

                // Perform the undo operations. As only already executed commands
                // should be present on the list, we do not need to check if the
                // command is undoable.
                node.Value.Undo();

                // Count the number of commands we have undone so far
                numCommandsUndone++;

                // Continue with the previous node in the chain
                node = node.Previous;
                
                // Remove the current node from the list (a pitty the function 
                // does not return the node removed)
                _undos.RemoveLast();

                // Register the command for a redo operation
                _redos.AddLast(node.Value);

                // Check for state changes
                if (!HasUndoableCommands || hadRedoableCommandsBefore != HasRedoableCommands)
                    OnStateChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Executes a undone command a second time.
        /// </summary>
        public void Redo()
        {
            Redo(1);
        }

        /// <summary>
        /// Executes undone commands again. 
        /// </summary>
        /// <param name="numCommandsToRedo">The number of commands to redo.</param>
        public void Redo(int numCommandsToRedo)
        {
            int numCommandsRedone = 0;
            LinkedListNode<IUndoableCommand> node = _redos.Last;

            while (node != null && numCommandsRedone < numCommandsToRedo)
            {
                bool hadUndoableCommandsBefore = HasUndoableCommands;

                // Perform the redo operation. We do not check whether the command
                // is undoable, as it wouldn't be on the list then.
                node.Value.Redo();

                // Count the number of redo operations we have performed
                numCommandsToRedo++;

                // Continue with the previous element undone
                node = node.Previous;

                // Remove the current processed node from the chain
                _redos.RemoveLast();

                // Allow to undo the command again
                _undos.AddLast(node.Value);

                if (!HasRedoableCommands || hadUndoableCommandsBefore != HasUndoableCommands)
                    OnStateChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Flushes the entire command history.
        /// </summary>
        public void Clear()
        {
            _undos.Clear();
            _redos.Clear();

            OnStateChanged(EventArgs.Empty);
        }

        #endregion

        #region Event Handler

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="e"></param>
        private void OnStateChanged(EventArgs e)
        {
            if (StateChanged != null)
                StateChanged(this, e);
        }

        #endregion

        #region Helper

        /// <summary>
        /// A small helper function to ensure that the number of commands tracked within 
        /// the history does not exceed the given limit.
        /// </summary>
        private void TrimHistoryLength()
        {
            int length = _undos.Count;
            while (length >= _limit)
                _undos.RemoveLast();
        }

        #endregion
    }
}
